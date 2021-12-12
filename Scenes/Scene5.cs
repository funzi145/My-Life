using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class Scene5
    {

        int Monnaie = Game1.Banque,
            Banque = Game1.Banque,

            virement = Game1.virement,
            retrait = Game1.retrait,

            multiplierBanque = 1,
            selectionMultiplierBanque = Game1.selectionMultiplierBanque;

        string virementString,
            retraitString;

        Texture2D boutonBackTexture,

            cadreBanqueTexture,
            cadreBanque2Texture,
            cadreVirementTexture,
            cadreRetraitTexture,

            plus100BanqueTexture,
            moins100BanqueTexture,
            multiplier1BanqueTexture,
            zoneEcritureBanqueTexture,
            boutonValiderTexture,

            logoMonnaieTexture, 
            logoBanquePetitTexture;

        Rectangle plus100VirementRectangle = new Rectangle(170, 165, 55, 40),
            moins100VirementRectangle = new Rectangle(45, 165, 55, 40),
            multiplierRetraitRectangle = new Rectangle(335, 165, 50, 40),

            plus100RetraitRectangle = new Rectangle(395, 165, 55, 40),
            moins100RetraitRectangle = new Rectangle(270, 165, 55, 40),
            multiplierVirementRectangle = new Rectangle(112, 165, 50, 40),

            boutonValiderVirement = new Rectangle(85, 230, 100, 40),
            boutonValiderRetrait = new Rectangle(315, 230, 100, 40);

        Color backgroundColor = Color.DarkGray;

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new Scene5();

            sc.LoadContent(device, spriteBatch, Content);
            sc.Update(gametime);
            sc.Draw(device, spriteBatch, gametime);

        }

        public void Update(GameTime gameTime)
        {

            Game1.ks1 = Keyboard.GetState();
            Game1.ms1 = Mouse.GetState();

            virementString = virement.ToString();
            retraitString = retrait.ToString();


            //Bouton Multiplicateur Virement
            {
                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released) 
                    if (ClickTest(Game1.posSouris, multiplierVirementRectangle))
                        Game1.selectionMultiplierBanque++;
                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released) 
                    if (ClickTest(Game1.posSouris, multiplierVirementRectangle))
                        Game1.selectionMultiplierBanque++;
            }

            //+100$ et -100$ Virement
            {
                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released) 
                    if (ClickTest(Game1.posSouris, plus100VirementRectangle))
                        Game1.virement += 100 * multiplierBanque;

                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released)
                    if (ClickTest(Game1.posSouris, moins100VirementRectangle)) { Game1.virement -= 100 * Game1.multiplierBanque; if (virement < 0) virement = 0; }
            }

            //Bouton Multiplicateur Retrait
            {
                if (selectionMultiplierBanque > 3) Game1.selectionMultiplierBanque = 1;
                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released) 
                    if (ClickTest(Game1.posSouris, multiplierRetraitRectangle)) Game1.selectionMultiplierBanque++;
            }

            //+100$ et -100$ Retrait
            {
                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released)
                    if (ClickTest(Game1.posSouris, plus100RetraitRectangle))
                        Game1.retrait += 100 * multiplierBanque;

                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released)
                    if (ClickTest(Game1.posSouris, moins100RetraitRectangle)) { Game1.retrait -= 100 * multiplierBanque; if (retrait < 0) retrait = 0;  }
            }

            //Bouton Valider
            {
                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released)
                    if (ClickTest(Game1.posSouris, boutonValiderRetrait)) { Game1.Banque -= retrait; Game1.Monnaie += retrait; }

                if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released)
                    if (ClickTest(Game1.posSouris, boutonValiderVirement)) { Game1.Banque += virement; Game1.Monnaie -= virement; }
            }

            Game1.ks2 = Game1.ks1;
            Game1.ms2 = Game1.ms1;
        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            boutonBackTexture = Content.Load<Texture2D>("Logo/Bouton Retour");
            cadreBanqueTexture = Content.Load<Texture2D>("Scene 5/Cadre Banque");
            cadreBanque2Texture = Content.Load<Texture2D>("Scene 5/Cadre Banque 2");
            boutonValiderTexture = Content.Load<Texture2D>("Scene 5/Bouton valider banque");

            cadreVirementTexture = Content.Load<Texture2D>("Scene 5/Cadre Virement");
            cadreRetraitTexture = Content.Load<Texture2D>("Scene 5/Cadre Retrait");
            zoneEcritureBanqueTexture = Content.Load<Texture2D>("Scene 5/Zone ecriture banque");

            plus100BanqueTexture = Content.Load<Texture2D>("Scene 5/plus100dollarsBanque");
            moins100BanqueTexture = Content.Load<Texture2D>("Scene 5/moins100dollarsBanque");
            multiplier1BanqueTexture = Content.Load<Texture2D>("Scene 5/x1Banque");

            switch (selectionMultiplierBanque)
            {
                case 1:
                    multiplier1BanqueTexture = Content.Load<Texture2D>("Scene 5/x1Banque");
                    multiplierBanque = 1;
                    break;
                case 2:
                    multiplier1BanqueTexture = Content.Load<Texture2D>("Scene 5/x10Banque");
                    multiplierBanque = 10;
                    break;
                case 3:
                    multiplier1BanqueTexture = Content.Load<Texture2D>("Scene 5/x100Banque");
                    multiplierBanque = 100;
                    break;
            }

            logoBanquePetitTexture = Content.Load<Texture2D>("Logo/Logo Banque petit");
            logoMonnaieTexture = Content.Load<Texture2D>("Logo/Logo Monnaie");
        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch _spriteBatch, GameTime gametime)
        {
            device.GraphicsDevice.Clear(backgroundColor);

            _spriteBatch.Draw(cadreBanqueTexture, new Vector2(20, 60), Color.White);
            _spriteBatch.Draw(cadreVirementTexture, new Vector2(30, 70), Color.White);
            _spriteBatch.Draw(cadreRetraitTexture, new Vector2(255, 70), Color.White);
            _spriteBatch.Draw(cadreBanque2Texture, new Vector2(20, 310), Color.White);

            _spriteBatch.Draw(zoneEcritureBanqueTexture, new Vector2(45, 120), Color.White);
            _spriteBatch.Draw(zoneEcritureBanqueTexture, new Vector2(270, 120), Color.White);
            _spriteBatch.Draw(boutonValiderTexture, new Vector2(85, 230), Color.White);
            _spriteBatch.Draw(boutonValiderTexture, new Vector2(315, 230), Color.White);

            _spriteBatch.DrawString(Game1.ImpactFont24, virementString, new Vector2(55, 120), Color.Black);
            _spriteBatch.DrawString(Game1.ImpactFont24, retraitString, new Vector2(280, 120), Color.Black);

            _spriteBatch.Draw(plus100BanqueTexture, new Vector2(plus100VirementRectangle.X, plus100VirementRectangle.Y), Color.White);
            _spriteBatch.Draw(multiplier1BanqueTexture, new Vector2(multiplierVirementRectangle.X, multiplierVirementRectangle.Y), Color.White);
            _spriteBatch.Draw(moins100BanqueTexture, new Vector2(moins100VirementRectangle.X, moins100VirementRectangle.Y), Color.White);

            _spriteBatch.Draw(plus100BanqueTexture, new Vector2(plus100RetraitRectangle.X, plus100RetraitRectangle.Y), Color.White);
            _spriteBatch.Draw(multiplier1BanqueTexture, new Vector2(multiplierRetraitRectangle.X, multiplierRetraitRectangle.Y), Color.White);
            _spriteBatch.Draw(moins100BanqueTexture, new Vector2(moins100RetraitRectangle.X, moins100RetraitRectangle.Y), Color.White);

            _spriteBatch.Draw(logoMonnaieTexture, new Vector2(40, 324), Color.White);
            _spriteBatch.Draw(logoBanquePetitTexture, new Vector2(260, 318), Color.White);
            _spriteBatch.DrawString(Game1.ImpactFont24, Game1.MonnaieString, new Vector2(130, 325), Color.Black);
            _spriteBatch.DrawString(Game1.ImpactFont24, Game1.BanqueString, new Vector2(330, 325), Color.Black);
        }

        private void ChangeScene(int a)
        {
            Game1.scene = a;
        }
        private bool ClickTest(MouseState posSouris, Rectangle Button)
        {
            posSouris = Mouse.GetState();
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
