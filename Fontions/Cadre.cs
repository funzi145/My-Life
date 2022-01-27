using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life.Fontions
{
    class Cadre
    {
        static Texture2D CoinHautGaucheTex,
            CoinBasGaucheTex,
            CoinHautDroitTex,
            CoinBasDroitTex,
            BarreGaucheTex,
            BarreHautTex,
            BarreDroitTex,
            BarreBasTex,
            FondTex;

        public static bool Start(SpriteBatch sb, ContentManager Content, Rectangle rc)
        {
            CoinHautGaucheTex = Content.Load<Texture2D>("Cadre/Coin Haut Gauche");
            CoinBasGaucheTex = Content.Load<Texture2D>("Cadre/Coin Bas Gauche");
            CoinBasDroitTex = Content.Load<Texture2D>("Cadre/Coin Bas Droit");
            CoinHautDroitTex = Content.Load<Texture2D>("Cadre/Coin Haut Droit");
            BarreGaucheTex = Content.Load<Texture2D>("Cadre/Barre Gauche");
            BarreDroitTex = Content.Load<Texture2D>("Cadre/Barre Droit");
            BarreBasTex = Content.Load<Texture2D>("Cadre/Barre Bas");
            BarreHautTex = Content.Load<Texture2D>("Cadre/Barre Haut");
            FondTex = Content.Load<Texture2D>("Cadre/Fond");

            sb.Draw(FondTex, new Rectangle(rc.X + 13, rc.Y + 13, rc.Width - 26, rc.Height - 26), Color.White);
            sb.Draw(BarreGaucheTex, new Rectangle(rc.X, rc.Y+13, 13, rc.Height-26), Color.White);
            sb.Draw(BarreHautTex, new Rectangle(rc.X+13, rc.Y, rc.Width-26, 13), Color.White);
            sb.Draw(BarreDroitTex, new Rectangle(rc.X+rc.Width-13, rc.Y+13, 13, rc.Height-26), Color.White);
            sb.Draw(BarreBasTex, new Rectangle(rc.X+13, rc.Y+rc.Height-13, rc.Width - 26, 13), Color.White);
            sb.Draw(CoinHautGaucheTex, new Vector2(rc.X, rc.Y), Color.White);
            sb.Draw(CoinBasGaucheTex, new Vector2(rc.X, rc.Y + (rc.Height - 13)), Color.White);
            sb.Draw(CoinHautDroitTex, new Vector2(rc.X + (rc.Width - 13), rc.Y), Color.White);
            sb.Draw(CoinBasDroitTex, new Vector2(rc.X + (rc.Width - 13), rc.Y + (rc.Height - 13)), Color.White);

            if (Game1.ClickTest(Mouse.GetState(), rc)) { return true; }
            else { return false;  }

        }
        public static bool Start(SpriteBatch sb, ContentManager Content, Rectangle rc,Texture2D tex, Vector2 v2)
        {
            CoinHautGaucheTex = Content.Load<Texture2D>("Cadre/Coin Haut Gauche");
            CoinBasGaucheTex = Content.Load<Texture2D>("Cadre/Coin Bas Gauche");
            CoinBasDroitTex = Content.Load<Texture2D>("Cadre/Coin Bas Droit");
            CoinHautDroitTex = Content.Load<Texture2D>("Cadre/Coin Haut Droit");
            BarreGaucheTex = Content.Load<Texture2D>("Cadre/Barre Gauche");
            BarreDroitTex = Content.Load<Texture2D>("Cadre/Barre Droit");
            BarreBasTex = Content.Load<Texture2D>("Cadre/Barre Bas");
            BarreHautTex = Content.Load<Texture2D>("Cadre/Barre Haut");
            FondTex = Content.Load<Texture2D>("Cadre/Fond");

            sb.Draw(FondTex, new Rectangle(rc.X + 13, rc.Y + 13, rc.Width - 26, rc.Height - 26), Color.White);
            sb.Draw(BarreGaucheTex, new Rectangle(rc.X, rc.Y+13, 13, rc.Height-26), Color.White);
            sb.Draw(BarreHautTex, new Rectangle(rc.X+13, rc.Y, rc.Width-26, 13), Color.White);
            sb.Draw(BarreDroitTex, new Rectangle(rc.X+rc.Width-13, rc.Y+13, 13, rc.Height-26), Color.White);
            sb.Draw(BarreBasTex, new Rectangle(rc.X+13, rc.Y+rc.Height-13, rc.Width - 26, 13), Color.White);
            sb.Draw(CoinHautGaucheTex, new Vector2(rc.X, rc.Y), Color.White);
            sb.Draw(CoinBasGaucheTex, new Vector2(rc.X, rc.Y + (rc.Height - 13)), Color.White);
            sb.Draw(CoinHautDroitTex, new Vector2(rc.X + (rc.Width - 13), rc.Y), Color.White);
            sb.Draw(CoinBasDroitTex, new Vector2(rc.X + (rc.Width - 13), rc.Y + (rc.Height - 13)), Color.White);

            sb.Draw(tex, new Vector2(rc.X,rc.Y)+v2, Color.White);

            if (Game1.ClickTest(Mouse.GetState(), rc)) { return true; }
            else { return false; }
        }

        public static bool Start(SpriteBatch sb, ContentManager Content, Rectangle rc, Texture2D tex, Rectangle rc2)
        {
            CoinHautGaucheTex = Content.Load<Texture2D>("Cadre/Coin Haut Gauche");
            CoinBasGaucheTex = Content.Load<Texture2D>("Cadre/Coin Bas Gauche");
            CoinBasDroitTex = Content.Load<Texture2D>("Cadre/Coin Bas Droit");
            CoinHautDroitTex = Content.Load<Texture2D>("Cadre/Coin Haut Droit");
            BarreGaucheTex = Content.Load<Texture2D>("Cadre/Barre Gauche");
            BarreDroitTex = Content.Load<Texture2D>("Cadre/Barre Droit");
            BarreBasTex = Content.Load<Texture2D>("Cadre/Barre Bas");
            BarreHautTex = Content.Load<Texture2D>("Cadre/Barre Haut");
            FondTex = Content.Load<Texture2D>("Cadre/Fond");

            sb.Draw(FondTex, new Rectangle(rc.X + 13, rc.Y + 13, rc.Width - 26, rc.Height - 26), Color.White);
            sb.Draw(BarreGaucheTex, new Rectangle(rc.X, rc.Y + 13, 13, rc.Height - 26), Color.White);
            sb.Draw(BarreHautTex, new Rectangle(rc.X + 13, rc.Y, rc.Width - 26, 13), Color.White);
            sb.Draw(BarreDroitTex, new Rectangle(rc.X + rc.Width - 13, rc.Y + 13, 13, rc.Height - 26), Color.White);
            sb.Draw(BarreBasTex, new Rectangle(rc.X + 13, rc.Y + rc.Height - 13, rc.Width - 26, 13), Color.White);
            sb.Draw(CoinHautGaucheTex, new Vector2(rc.X, rc.Y), Color.White);
            sb.Draw(CoinBasGaucheTex, new Vector2(rc.X, rc.Y + (rc.Height - 13)), Color.White);
            sb.Draw(CoinHautDroitTex, new Vector2(rc.X + (rc.Width - 13), rc.Y), Color.White);
            sb.Draw(CoinBasDroitTex, new Vector2(rc.X + (rc.Width - 13), rc.Y + (rc.Height - 13)), Color.White);

            sb.Draw(tex, new Rectangle(rc.X+rc2.X,rc.Y+rc2.Y,rc2.Width,rc2.Height), Color.White);

            if (Game1.ClickTest(Mouse.GetState(), rc)) { return true; }
            else { return false; }
        }

    }
}
