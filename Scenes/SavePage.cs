using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Test;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace My_Life
{
    class SavePage
    {
        Texture2D cadreSauvegardeTex,
            cadreNameSaveTex,
            cadreSaveTex;

        Rectangle boutonSauvegarde1Rectangle = new Rectangle(20, 100, 460, 80),
                boutonSauvegarde2Rectangle = new Rectangle(20, 200, 460, 80),
                boutonSauvegarde3Rectangle = new Rectangle(20, 300, 460, 80);

        string[] nameSave = new string[3];

        Color backgroundColor = Color.DarkGray;
        Color textColor = new Color(64, 64, 64);

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new SavePage();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Update(gametime);
            sc.Draw(device, spriteBatch, gametime);
        }

        public void Update(GameTime gameTime)
        {
            nameSave = SaveGame.ReadSaveName();
        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            cadreSauvegardeTex = Content.Load<Texture2D>("SavePage/Cadre Sauvegarde");
            cadreNameSaveTex = Content.Load<Texture2D>("SavePage/Enregistrer Sauvegarde");
            cadreSaveTex = Content.Load<Texture2D>("SavePage/Cadre Enregistrer Sauvegarde");
        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch spriteBatch, GameTime gametime)
        {
            device.GraphicsDevice.Clear(backgroundColor);

            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 100), Color.White);
            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 200), Color.White);
            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 300), Color.White);

            spriteBatch.DrawString(Game1.ImpactFont24, nameSave[0], new Vector2(40, 120), textColor);
            spriteBatch.DrawString(Game1.ImpactFont24, nameSave[1], new Vector2(40, 220), textColor);
            spriteBatch.DrawString(Game1.ImpactFont24, nameSave[2], new Vector2(40, 320), textColor);

            spriteBatch.DrawString(Game1.ImpactFont9, Game1.TPSinfo[0].ToString(), new Vector2(300, 120), textColor);
            spriteBatch.DrawString(Game1.ImpactFont9, Game1.TPSinfo[1].ToString(), new Vector2(300, 220), textColor);
            spriteBatch.DrawString(Game1.ImpactFont9, Game1.TPSinfo[2].ToString(), new Vector2(300, 320), textColor);

            saveSaveGame(spriteBatch);
        }

        private void saveSaveGame(SpriteBatch spriteBatch)
        {
            if (Game1.ClickTest(Mouse.GetState(), boutonSauvegarde1Rectangle))
            {
                Game1.saveNbr = 0;
                Game1.isTyping = true;
            }
            if (Game1.ClickTest(Mouse.GetState(), boutonSauvegarde2Rectangle))
            {
                Game1.saveNbr = 1;
                Game1.isTyping = true;
            }
            if (Game1.ClickTest(Mouse.GetState(), boutonSauvegarde3Rectangle))
            {
                Game1.saveNbr = 2;
                Game1.isTyping = true;
            }

            if (Game1.isTyping)
            {
                enterName(spriteBatch, Game1.saveNbr);
                if (!Game1.isTyping)
                {
                    SaveGame.SaveSettingsInIsoStorage(Game1.saveNbr + 1, Game1.name[Game1.saveNbr]);
                }
            }

        }

        private void enterName(SpriteBatch spriteBatch, int a)
        {
            Game1.name[a] = KeysList.KeyTracker(Game1.name[a]); 
            spriteBatch.Draw(cadreSaveTex, new Vector2(50, 200), Color.White);
            spriteBatch.DrawString(Game1.ImpactFont24, "Choisissez un nom", new Vector2(130, 225), textColor);
            spriteBatch.Draw(cadreNameSaveTex, new Vector2(100, 275), Color.White);
            spriteBatch.DrawString(Game1.ImpactFont24, Game1.name[a], new Vector2(120, 275), textColor);
        }

    }
}
