using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class Scene2
    {
        Texture2D topBarTex,boutonBackTex;
        Rectangle boutonBackRectangle = new Rectangle(350,16,120,30);

        Color backgroundColor = Game1.backgroundColor;

        public static void start(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content, GameTime gametime)
        {
            var sc = new Scene2();
            sc.LoadContent(device, spriteBatch, Content);
            sc.Draw(device, spriteBatch, gametime);
            sc.Update(gametime);
        }

        public void Update(GameTime gameTime)
        {
            if (ClickTest(Mouse.GetState(), boutonBackRectangle)) ChangeScene(1);
        }

        protected void LoadContent(GraphicsDeviceManager device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            topBarTex = Content.Load<Texture2D>("Scene 2/Top Bar");
            boutonBackTex = Content.Load<Texture2D>("Logo/Bouton Retour");
        }

        protected void Draw(GraphicsDeviceManager device, SpriteBatch spriteBatch, GameTime gametime)
        {
            device.GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Draw(topBarTex, new Vector2(20, 10), Color.White);
            spriteBatch.Draw(boutonBackTex, new Vector2(boutonBackRectangle.X,boutonBackRectangle.Y), Color.Gray);
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
