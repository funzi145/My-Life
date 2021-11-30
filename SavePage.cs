using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class SavePage
    {
        Texture2D topBarTex;
        Texture2D cadreSauvegardeTex;

        Rectangle boutonSauvegarde1Rectangle = new Rectangle(20, 100, 460, 80),
                boutonSauvegarde2Rectangle = new Rectangle(20, 200, 460, 80),
                boutonSauvegarde3Rectangle = new Rectangle(20, 300, 460, 80);

        string topBarString = "Sauvegarde";

        Color backgroundColor = Color.DarkGray;
        Color textColor = new Color(64, 64, 64);

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new SavePage();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Draw(device, spriteBatch, gametime);
            sc.Update(gametime);
        }

        public void Update(GameTime gameTime)
        {
            saveSaveGame();
        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            topBarTex = Content.Load<Texture2D>("SavePage/Top Bar");
            cadreSauvegardeTex = Content.Load<Texture2D>("SavePage/Cadre Sauvegarde");
        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch spriteBatch, GameTime gametime)
        {
            device.GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Draw(topBarTex, new Vector2(20, 10), Color.White);
            spriteBatch.DrawString(Game1.ImpactFont24,topBarString, new Vector2(40, 10), textColor);

            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 100), Color.White);
            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 200), Color.White);
            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 300), Color.White);

            spriteBatch.DrawString(Game1.ImpactFont24, "Sauvegarde 1", new Vector2(40, 120), textColor);
            spriteBatch.DrawString(Game1.ImpactFont24, "Sauvegarde 2", new Vector2(40, 220), textColor);
            spriteBatch.DrawString(Game1.ImpactFont24, "Sauvegarde 3", new Vector2(40, 320), textColor);

        }

        private void ChangeScene(int a)
        {
            Game1.scene = a;
        }

        private void saveSaveGame()
        {
            if (Game1.ClickTest(Mouse.GetState(), boutonSauvegarde1Rectangle)) SaveGame.SaveSettingsInIsoStorage(1);
            if (Game1.ClickTest(Mouse.GetState(),boutonSauvegarde2Rectangle)) SaveGame.SaveSettingsInIsoStorage(2);
            if (Game1.ClickTest(Mouse.GetState(),boutonSauvegarde3Rectangle)) SaveGame.SaveSettingsInIsoStorage(3);
        }


    }
}
