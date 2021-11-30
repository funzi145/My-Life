using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class Scene0
    {
        Texture2D logoTex, pressSpaceTex;

        Color backgroundColor = Game1.backgroundColor;

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new Scene0();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Draw(device, spriteBatch, gametime);
            sc.Update(gametime);
        }

        public void Update(GameTime gameTime)
        {
            Game1.ks1 = Keyboard.GetState();
            if (Game1.ks1.IsKeyDown(Keys.Space) && Game1.ks2.IsKeyUp(Keys.Space))
            {
                ChangeScene();
            }
            Game1.ks2 = Game1.ks1;

            Game1.ms1 = Mouse.GetState();
            if (Game1.ms1.LeftButton == ButtonState.Pressed && Game1.ms2.LeftButton == ButtonState.Released)
                ChangeScene();
            Game1.ms2 = Game1.ms1;

        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            logoTex = Content.Load<Texture2D>("Scene 0/Logo Jeu");
            pressSpaceTex = Content.Load<Texture2D>("Scene 0/Logo Press Space");
        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch spriteBatch, GameTime gametime)
        {
            device.GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Draw(logoTex, new Vector2(182,162), Color.White);
            spriteBatch.Draw(pressSpaceTex, new Vector2(125,340), Color.White);
        }

        private void ChangeScene()
        {
            Game1.scene = 1;
        }

    }
}
