using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace My_Life
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //General
        public static Color backgroundColor = new Color(51, 51, 51);

        int secondes = 0, minutes = 0, heures = 0, min2;

        public static int TPS { get; set; }
        public static int Monnaie { get; set; }
        public static int Banque { get; set; }
        public static int scene { get; set; }
        public static bool sound { get; set; }
        public static bool music { get; set; }

        public static int sante = 100,
            faim = 100,
            criminalite,
            virement,
            retrait,
            multiplierBanque = 1,
            selectionMultiplierBanque = 1;

        public static string MonnaieString,
            BanqueString,
            faimString,
            santeString,
            criminaliteString;

        public static KeyboardState ks1, ks2;
        public static MouseState ms1, ms2, posSouris;

        public static SpriteFont ImpactFont24, ImpactFont9;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.PreferredBackBufferHeight = 650;
            _graphics.ApplyChanges();

            Monnaie = 1500;
            sound = true;
            music = true;

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Font
            {
                ImpactFont9 = Content.Load<SpriteFont>("Font/ImpactFont9");
                ImpactFont24 = Content.Load<SpriteFont>("Font/ImpactFont24");
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (scene == 1) if (ClickTest(Mouse.GetState(), boutonBackRectangle)) Exit();

            ks1 = Keyboard.GetState();
            if (ks1.IsKeyDown(Keys.NumPad0)) scene = 0; 
            else if (ks1.IsKeyDown(Keys.NumPad1)) scene = 1; 
            else if (ks1.IsKeyDown(Keys.NumPad2)) scene = 2; 
            else if (ks1.IsKeyDown(Keys.NumPad3)) scene = 3; 
            else if (ks1.IsKeyDown(Keys.NumPad4)) scene = 4; 
            else if (ks1.IsKeyDown(Keys.NumPad5)) scene = 5; 
            else if (ks1.IsKeyDown(Keys.NumPad6)) scene = 6; 
            else if (ks1.IsKeyDown(Keys.NumPad7)) scene = 7;
            else if (ks1.IsKeyDown(Keys.NumPad8)) scene = 8;

            faimString = faim.ToString();
            santeString = sante.ToString();
            criminaliteString = criminalite.ToString();

            BanqueString = Banque.ToString();
            MonnaieString = Monnaie.ToString();

            base.Update(gameTime);

            tpsJeu();

        }

        protected override void Draw(GameTime gameTime)
        {
            ms1 = Mouse.GetState();
            ks1 = Keyboard.GetState();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            GraphicsDevice.Clear(backgroundColor);

            _spriteBatch.DrawString(ImpactFont9, "Version InDev, Pre-Experimental Build", new Vector2(5, 633), Color.Black);

            switch (scene)
            {
                case -1:
                    SavePage.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 0:
                    Scene0.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 1:
                    Scene1.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 2:
                    Scene2.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 3:
                    Scene3.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 4:
                    Scene4.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 5:
                    Scene5.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 6:
                    Scene6.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 7:
                    Scene7.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
                case 8:
                    Scene8.start(_graphics, _spriteBatch, Content, gameTime);
                    break;
            }
            ks2 = ks1;
            ms2 = ms1;

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public static bool ClickTest(MouseState posSouris, Rectangle Button)
        {
            if (posSouris.X >= Button.Left && posSouris.X <= Button.Right)
            {
                if (posSouris.Y >= Button.Top && posSouris.Y <= Button.Bottom)
                {
                    ms1 = Mouse.GetState();
                    if (ms1.LeftButton == ButtonState.Pressed && ms2.LeftButton == ButtonState.Released)
                    {
                        return true;
                    }
                    ms2 = ms1;
                }
            }
            return false;
        }

        public void tpsJeu()
        {
            if (TPS > 59) secondes = TPS / 60;
            if (secondes > 59) minutes = secondes / 60;
            if (minutes > 60) heures = minutes / 60;
            if (min2 != minutes)
            {
                min2 = secondes;
            }
            min2 = minutes;
            
        }

    }
}


/*Table Des Scenes
 *-1- SavePage
 * 0- Start Screen
 * 1- Main Page
 * 2- Food
 * 3- Heal
 * 4- Job
 * 5- Banque
 * 6- Achat
 * 7- Nester
 * 8- Paramètre
*/
