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
        Texture2D cadreSauvegardeTex, cadrePartieChargeeTex;
        Texture2D boutonSonsTex, boutonMusiqueTex, boutonPoubelle;

        Rectangle boutonSauvegarde1Rectangle = new Rectangle(20, 370, 380, 80),
                boutonSauvegarde2Rectangle = new Rectangle(20, 460, 380, 80),
                boutonSauvegarde3Rectangle = new Rectangle(20, 550, 380, 80),
                boutonSonsRectangle = new Rectangle(50, 150, 50, 50),
                boutonMusiqueRectangle = new Rectangle(150, 150, 50, 50),
                boutonPoubelle1Rectangle = new Rectangle(407,378,65,65),
                boutonPoubelle2Rectangle = new Rectangle(407,468,65,65),
                boutonPoubelle3Rectangle = new Rectangle(407,558,65,65);

        string[] nameSave = new string[3];

        Color backgroundColor = Color.DarkGray;
        Color textColor = new Color(64, 64, 64);

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new Scene8();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Update(gametime);
            sc.Draw(device, spriteBatch, gametime);
        }

        public void Update(GameTime gameTime)
        {
            if (Game1.sound) { if (Game1.ClickTest(Mouse.GetState(), boutonSonsRectangle)) Game1.sound = false; }  
            else { if (Game1.ClickTest(Mouse.GetState(), boutonSonsRectangle)) Game1.sound = true; }

            if (Game1.music) { if (Game1.ClickTest(Mouse.GetState(), boutonMusiqueRectangle)) Game1.music = false; }
            else { if (Game1.ClickTest(Mouse.GetState(), boutonMusiqueRectangle)) Game1.music = true; }
        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            cadreSauvegardeTex = Content.Load<Texture2D>("Scene 8/Cadre Sauvegarde");
            cadrePartieChargeeTex = Content.Load<Texture2D>("Scene 8/Cadre Partie Chargée");
            boutonMusiqueTex = Content.Load<Texture2D>("Scene 8/Bouton Musique");
            boutonPoubelle = Content.Load<Texture2D>("Logo/Logo Poubelle");

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

            loadSaveGame(spriteBatch);

            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 370), Color.White);
            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 460), Color.White);
            spriteBatch.Draw(cadreSauvegardeTex, new Vector2(20, 550), Color.White);

            spriteBatch.Draw(boutonSonsTex, new Vector2(45, 145), Color.White);
            spriteBatch.Draw(boutonMusiqueTex, new Vector2(145, 145), Color.White);
            spriteBatch.DrawString(Game1.ImpactFont24, nameSave[0], new Vector2(40, 380), textColor);
            spriteBatch.DrawString(Game1.ImpactFont24, nameSave[1], new Vector2(40, 470), textColor);
            spriteBatch.DrawString(Game1.ImpactFont24, nameSave[2], new Vector2(40, 560), textColor);

            spriteBatch.DrawString(Game1.ImpactFont9, Game1.TPSInfoString[0], new Vector2(300, 380), textColor);
            spriteBatch.DrawString(Game1.ImpactFont9, Game1.TPSInfoString[1], new Vector2(300, 470), textColor);
            spriteBatch.DrawString(Game1.ImpactFont9, Game1.TPSInfoString[2], new Vector2(300, 560), textColor);

        }

        private void ChangeScene(int a)
        {
            Game1.scene = a;
        }

        private void loadSaveGame(SpriteBatch spriteBatch)
        {
            nameSave = SaveGame.ReadSaveName();
            if (Game1.ClickTest(Mouse.GetState(), boutonSauvegarde1Rectangle)) Game1.msgSauvegarde = true;  InfoPartie(0, spriteBatch);
            if (Game1.ClickTest(Mouse.GetState(), boutonSauvegarde2Rectangle)) if (SaveGame.ReadSettingsFromIsoStorage(1)) InfoPartie(1, spriteBatch);
            if (Game1.ClickTest(Mouse.GetState(), boutonSauvegarde3Rectangle)) if (SaveGame.ReadSettingsFromIsoStorage(2)) InfoPartie(2, spriteBatch);
        }

        private void InfoPartie(int a, SpriteBatch spriteBatch)
        {
            a++;
            if (Game1.msgSauvegarde)
            {
                if (Game1.saveNbr < 60)
                {
                    if (SaveGame.ReadSettingsFromIsoStorage(a))
                    {
                        spriteBatch.Draw(cadrePartieChargeeTex, new Vector2(100, 300), Color.White);
                        spriteBatch.DrawString(Game1.ImpactFont24, "Partie " + a + " Chargee !", new Vector2(110, 300), textColor);
                    }
                    else
                    {
                        spriteBatch.Draw(cadrePartieChargeeTex, new Vector2(100, 300), Color.White);
                        spriteBatch.DrawString(Game1.ImpactFont24, "Partie " + a + " non Chargee !", new Vector2(105, 300), textColor);
                    }
                }
                else if (Game1.saveNbr >= 60)
                {
                    Game1.saveNbr = 0;
                    Game1.msgSauvegarde = false;
                }
            }
        }
    }
}
