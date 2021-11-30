using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class Scene8
    {
        Texture2D topBarTex;
        Texture2D cadreSauvegardeTex;
        Texture2D boutonSonsTex, boutonMusiqueTex;

        Rectangle boutonSauvegarde1Rectangle = new Rectangle(20, 370, 460, 80),
                boutonSauvegarde2Rectangle = new Rectangle(20, 460, 460, 80),
                boutonSauvegarde3Rectangle = new Rectangle(20, 550, 460, 80),
                boutonSonsRectangle = new Rectangle(50, 150, 50, 50),
                boutonMusiqueRectangle = new Rectangle(150, 150, 50, 50);

        string topBarString = "Parametres";
        string nameSave1, nameSave2, nameSave3;

        Color backgroundColor = Color.DarkGray;
        Color textColor = new Color(64, 64, 64);

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new Scene8();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Draw(device, spriteBatch, gametime);
            sc.Update(gametime);
        }

        public void Update(GameTime gameTime)
        {
            loadSaveGame();
            if (Game1.sound) { if (Game1.ClickTest(Mouse.GetState(), boutonSonsRectangle)) Game1.sound = false; }  
            else { if (Game1.ClickTest(Mouse.GetState(), boutonSonsRectangle)) Game1.sound = true; }

            if (Game1.music) { if (Game1.ClickTest(Mouse.GetState(), boutonMusiqueRectangle)) Game1.music = false; }
            else { if (Game1.ClickTest(Mouse.GetState(), boutonMusiqueRectangle)) Game1.music = true; }
                

        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            topBarTex = Content.Load<Texture2D>("Scene 8/Top Bar");
            cadreSauvegardeTex = Content.Load<Texture2D>("Scene 8/Cadre Sauvegarde");
            boutonMusiqueTex = Content.Load<Texture2D>("Scene 8/Bouton Musique");

            if(Game1.sound)
                boutonSonsTex = Content.Load<Texture2D>("Scene 8/Bouton Sons on");
            else
                boutonSonsTex = Content.Load<Texture2D>("Scene 8/Bouton Sons off");

            if(Game1.music)
                boutonMusiqueTex = Content.Load<Texture2D>("Scene 8/Bouton Musique on");
            else
                boutonMusiqueTex = Content.Load<Texture2D>("Scene 8/Bouton Musique off");

        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch spriteBatch, GameTime gametime)
        {
            device.GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Draw(topBarTex, new Vector2(20, 10), Color.White);
            spriteBatch.DrawString(Game1.ImpactFont24,topBarString, new Vector2(40, 10), textColor);

            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 370), Color.White);
            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 460), Color.White);
            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 550), Color.White);

            spriteBatch.Draw(boutonSonsTex, new Vector2(45, 145), Color.White);
            spriteBatch.Draw(boutonMusiqueTex, new Vector2(145, 145), Color.White);

            spriteBatch.DrawString(Game1.ImpactFont24, "Sauvegarde 1", new Vector2(40, 380), textColor);
            spriteBatch.DrawString(Game1.ImpactFont24, "Sauvegarde 2", new Vector2(40, 470), textColor);
            spriteBatch.DrawString(Game1.ImpactFont24, "Sauvegarde 3", new Vector2(40, 560), textColor);

        }

        private void ChangeScene(int a)
        {
            Game1.scene = a;
        }

        private void loadSaveGame()
        {
            if (Game1.ClickTest(Mouse.GetState(),boutonSauvegarde1Rectangle)) SaveGame.ReadSettingsFromIsoStorage(1);
            if (Game1.ClickTest(Mouse.GetState(),boutonSauvegarde2Rectangle)) SaveGame.ReadSettingsFromIsoStorage(2);
            if (Game1.ClickTest(Mouse.GetState(),boutonSauvegarde3Rectangle)) SaveGame.ReadSettingsFromIsoStorage(3);
        }


    }
}
