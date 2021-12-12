using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class Scene6
    {
        Color backgroundColor = Color.DarkGray;

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new Scene6();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Draw(device, spriteBatch, gametime);
            sc.Update(gametime);
        }

        public void Update(GameTime gameTime)
        {

        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch spriteBatch, GameTime gametime)
        {
            device.GraphicsDevice.Clear(backgroundColor);
        }

        private void ChangeScene(int a)
        {
            Game1.scene = a;
        }

    }
}
