using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class TopBarClass
    {
        Texture2D topBarTex, boutonBackTex, boutonSaveTex, boutonParametreTex;

        int scene = Game1.scene;

        string topBarString;

        Color textColor = new Color(64, 64, 64);

        Rectangle boutonBackRectangle = new Rectangle(350, 16, 120, 30),
                boutonParametreRectangle = new Rectangle(315, 15, 30, 30),
                boutonSaveRectangle = new Rectangle(280, 15, 30, 30);

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new TopBarClass();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Draw(device, spriteBatch, gametime);
            sc.Update(gametime);
        }

        public void Update(GameTime gameTime)
        {
            switch (scene)
            {
                case -1:
                    topBarString = "SAUVEGARDER";
                    break;
                case 1:
                    topBarString = "MENU PRINCIPAL";
                    break;
                case 2:
                    topBarString = "NOURRITURE";
                    break;
                case 3:
                    topBarString = "SANTE";
                    break;
                case 4:
                    topBarString = "JOB";
                    break;
                case 5:
                    topBarString = "BANQUE";
                    break;
                case 6:
                    topBarString = "ACHAT";
                    break;
                case 7:
                    topBarString = "NESTER";
                    break;
                case 8:
                    topBarString = "PARAMETRE";
                    break;
            }
        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            topBarTex = Content.Load<Texture2D>("Logo/Top Bar");
            boutonBackTex = Content.Load<Texture2D>("Logo/Bouton Retour");
            boutonSaveTex = Content.Load<Texture2D>("Logo/Logo Sauvegarde");
            boutonParametreTex = Content.Load<Texture2D>("Logo/Logo Parametre");
        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch spriteBatch, GameTime gametime)
        {
            spriteBatch.Draw(topBarTex, new Vector2(20, 10), Color.White);
            spriteBatch.DrawString(Game1.ImpactFont24,topBarString, new Vector2(40, 10), textColor);
            spriteBatch.Draw(boutonBackTex, new Vector2(boutonBackRectangle.X, boutonBackRectangle.Y), Color.White);
            spriteBatch.Draw(boutonBackTex, new Vector2(boutonBackRectangle.X, boutonBackRectangle.Y), Color.White);
            spriteBatch.Draw(boutonBackTex, new Vector2(boutonBackRectangle.X, boutonBackRectangle.Y), Color.White);
        }

        private void ChangeScene(int a)
        {
            Game1.scene = a;
        }

    }
}
