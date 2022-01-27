using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life.Fontions
{
    public class AffichagesJobs
    {
        static Texture2D cadreTex;

        static Rectangle job1Rec = new Rectangle(20,450,95,65);
     
        public static void Start(SpriteBatch spriteBatch,ContentManager Content)
        {
            cadreTex = Content.Load<Texture2D>("Logo/Cadre Logo Jobs");
            spriteBatch.Draw(cadreTex, new Rectangle(20,400,65,100),Color.White);
        }

    }
}
