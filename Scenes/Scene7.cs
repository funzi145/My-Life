using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class Scene7
    {
        int Monnaie = Game1.Banque,
               Banque = Game1.Banque,

               sante = Game1.sante,
               faim = Game1.faim,
               criminalite = Game1.criminalite;

        Texture2D boutonParametreTex,
                cadreMoneyTexture,
                cadreInfoTexture,
                cadreBarreTexture,
                boutonQuitterTexture,
                logo2PointsTexture,
                saveTex,

                logoSantePetitTexture,
                logoNourriturePetitTexture,
                logoMenotesTexture,

                logoVoitureTexture,
                logoImmeubleTexture,

                logoMonnaieTexture,
                logoBanquePetitTexture,

                logoNesterTexture,
                logoAchatTexture,
                logoJobTexture;

        Rectangle boutonJobRectangle = new Rectangle(20, 440, 145, 100),
                boutonAchatRectangle = new Rectangle(20, 540, 145, 100),
                boutonNourritureRectangle = new Rectangle(175, 440, 145, 100),
                boutonSanteRectangle = new Rectangle(175, 540, 145, 100),
                boutonBanqueRectangle = new Rectangle(330, 440, 145, 100),
                boutonNesterRectangle = new Rectangle(330, 540, 145, 100),

                boutonParametreRectangle = new Rectangle(315, 15, 30, 30),
                boutonSaveRectangle = new Rectangle(280, 15, 30, 30);

        Color backgroundColor = Color.DarkGray;

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new Scene7();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Update(gametime);
            sc.Draw(device, spriteBatch, gametime);
        }

        public void Update(GameTime gameTime)
        {
        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            boutonQuitterTexture = Content.Load<Texture2D>("Logo/Bouton Quitter");
            boutonParametreTex = Content.Load<Texture2D>("Scene 1/Logo Parametre");
            saveTex = Content.Load<Texture2D>("Scene 1/Logo Sauvegarde");

            cadreBarreTexture = Content.Load<Texture2D>("Scene 1/Cadre Section Barre");
            cadreInfoTexture = Content.Load<Texture2D>("Scene 1/Cadre Section Info");
            cadreMoneyTexture = Content.Load<Texture2D>("Scene 1/Cadre Money");
            logo2PointsTexture = Content.Load<Texture2D>("Logo/Logo 2 Points");

            logoSantePetitTexture = Content.Load<Texture2D>("Logo/Logo Santé petit");
            logoNourriturePetitTexture = Content.Load<Texture2D>("Logo/Logo Nourriture petit");
            logoBanquePetitTexture = Content.Load<Texture2D>("Logo/Logo Banque petit");
            logoMonnaieTexture = Content.Load<Texture2D>("Logo/Logo Monnaie");
            logoMenotesTexture = Content.Load<Texture2D>("Logo/Logo Menotes");

            logoVoitureTexture = Content.Load<Texture2D>("Logo/Logo Voiture");
            logoImmeubleTexture = Content.Load<Texture2D>("Logo/Logo Imeuble");

            logoAchatTexture = Content.Load<Texture2D>("Logo/Logo Achat");
            logoNesterTexture = Content.Load<Texture2D>("Logo/Logo Nester");
            logoJobTexture = Content.Load<Texture2D>("Logo/Logo Job");
        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch _spriteBatch, GameTime gametime)
        {
            device.GraphicsDevice.Clear(backgroundColor);
            _spriteBatch.Draw(boutonParametreTex, new Vector2(boutonParametreRectangle.X, boutonParametreRectangle.Y), Color.White);
            _spriteBatch.Draw(saveTex, new Vector2(boutonSaveRectangle.X, boutonSaveRectangle.Y), Color.White);

            _spriteBatch.Draw(cadreBarreTexture, new Vector2(20, 60), Color.White);
            _spriteBatch.Draw(logoNourriturePetitTexture, new Vector2(45, 75), Color.White);
            _spriteBatch.Draw(logoSantePetitTexture, new Vector2(45, 135), Color.White);
            _spriteBatch.Draw(logoMenotesTexture, new Vector2(45, 195), Color.White);

            _spriteBatch.DrawString(Game1.ImpactFont24, Game1.faimString, new Vector2(110, 80), Color.Black);
            _spriteBatch.DrawString(Game1.ImpactFont24, Game1.santeString, new Vector2(110, 140), Color.Black);
            _spriteBatch.DrawString(Game1.ImpactFont24, Game1.criminaliteString, new Vector2(110, 200), Color.Black);

            _spriteBatch.Draw(cadreInfoTexture, new Vector2(20, 265), Color.White);
            _spriteBatch.Draw(logoVoitureTexture, new Vector2(35, 280), Color.White);
            _spriteBatch.Draw(logo2PointsTexture, new Vector2(95, 283), Color.White);
            _spriteBatch.Draw(logoImmeubleTexture, new Vector2(35, 340), Color.White);
            _spriteBatch.Draw(logo2PointsTexture, new Vector2(95, 348), Color.White);


            _spriteBatch.Draw(cadreMoneyTexture, new Vector2(255, 265), Color.White);
            _spriteBatch.Draw(cadreMoneyTexture, new Vector2(255, 345), Color.White);
            _spriteBatch.Draw(logoMonnaieTexture, new Vector2(270, 280), Color.White);
            _spriteBatch.DrawString(Game1.ImpactFont24, Game1.MonnaieString, new Vector2(365, 280), Color.Black);
            _spriteBatch.Draw(logoBanquePetitTexture, new Vector2(275, 353), Color.White);
            _spriteBatch.DrawString(Game1.ImpactFont24, Game1.BanqueString, new Vector2(365, 360), Color.Black);

        }

        protected void ChangeScene(int a)
        {
            Game1.scene = a;
        }

        private bool ClickTest(MouseState posSouris, Rectangle Button)
        {
            if (posSouris.X >= Button.Left && posSouris.X <= Button.Right)
            {
                if (posSouris.Y >= Button.Top && posSouris.Y <= Button.Bottom)
                {
                    if (posSouris.LeftButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
