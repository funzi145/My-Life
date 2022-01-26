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

        public static bool toExit {get; set;}
        public static bool isTyping { get; set;}
        public static string[] name = new string[3];

        int secondes = 0, minutes = 0, heures = 0;

        public static int TPS { get; set; }

        public static int[] TPSinfo = new int[3];
        public static string[] TPSInfoString = new string[3];
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
            selectionMultiplierBanque = 1,
            saveNbr =0;

        public static string MonnaieString,
            BanqueString,
            faimString,
            santeString,
            criminaliteString;

        public static KeyboardState ks1, ks2;
        public static MouseState ms1, ms2, posSouris;

        public static SpriteFont ImpactFont24, ImpactFont9;

        Texture2D topBarTex, boutonBackTex, boutonSaveTex, boutonParametreTex;

        Rectangle boutonBackRectangle = new Rectangle(350, 16, 120, 30),
                boutonParametreRectangle = new Rectangle(315, 15, 30, 30),
                boutonSaveRectangle = new Rectangle(280, 15, 30, 30);

        string topBarString = "MENU PRINCIPAL";
        public static bool msgSauvegarde = false;

        Color textColor = new Color(64, 64, 64);

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
            toExit = false;

            name = SaveGame.ReadSaveName();
            for (int i = 0; i < 3; i++)
            {
                name[i] = name[i].Substring(1, name[i].Length-2);
            }
            

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
            topBarTex = Content.Load<Texture2D>("Logo/Top Bar");
            boutonBackTex = Content.Load<Texture2D>("Logo/Bouton Quitter");

            boutonSaveTex = Content.Load<Texture2D>("Logo/Logo Sauvegarde");
            boutonParametreTex = Content.Load<Texture2D>("Logo/Logo Parametre");
        }

        protected override void Update(GameTime gameTime)
        {
            ks1 = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                if (ks1.IsKeyDown(Keys.Escape) && ks2.IsKeyUp(Keys.Escape))
                {
                    if (!isTyping)
                        Exit();
                    else isTyping = false;
                }
            
            if (ks1.IsKeyDown(Keys.NumPad0)) scene = 0; 
            else if (ks1.IsKeyDown(Keys.NumPad1)) scene = 1; 
            else if (ks1.IsKeyDown(Keys.NumPad2)) scene = 2; 
            else if (ks1.IsKeyDown(Keys.NumPad3)) scene = 3; 
            else if (ks1.IsKeyDown(Keys.NumPad4)) scene = 4; 
            else if (ks1.IsKeyDown(Keys.NumPad5)) scene = 5; 
            else if (ks1.IsKeyDown(Keys.NumPad6)) scene = 6; 
            else if (ks1.IsKeyDown(Keys.NumPad7)) scene = 7;
            else if (ks1.IsKeyDown(Keys.NumPad8)) scene = 8;

            

            if (msgSauvegarde) saveNbr++;

            faimString = faim.ToString();
            santeString = sante.ToString();
            criminaliteString = criminalite.ToString();

            BanqueString = Banque.ToString();
            MonnaieString = Monnaie.ToString();

            base.Update(gameTime);

            if(toExit) this.Exit();
            ks2 = ks1;

            TPS++;
            TPSCount();

            Game1.TPSInfoString[0] = "Tps : " + Game1.TPSinfo[0].ToString();
            Game1.TPSInfoString[1] = "Tps : " + Game1.TPSinfo[1].ToString();
            Game1.TPSInfoString[2] = "Tps : " + Game1.TPSinfo[2].ToString();

            TopBarClass.TopBar();

        }

        protected override void Draw(GameTime gameTime)
        {
            ms1 = Mouse.GetState();
            ks1 = Keyboard.GetState();

            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.DarkGray);

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

            topBarString = TopBarClass.StringChoose();

            if (scene != 0)
            {
                _spriteBatch.Draw(topBarTex, new Vector2(20, 10), Color.White);
                _spriteBatch.DrawString(Game1.ImpactFont24, topBarString, new Vector2(40, 10), textColor);
                _spriteBatch.Draw(boutonBackTex, new Vector2(boutonBackRectangle.X, boutonBackRectangle.Y), Color.White);
                _spriteBatch.Draw(boutonSaveTex, new Vector2(boutonSaveRectangle.X, boutonSaveRectangle.Y), Color.White);
                _spriteBatch.Draw(boutonParametreTex, new Vector2(boutonParametreRectangle.X, boutonParametreRectangle.Y), Color.White);
            }
            boutonBackTex = Content.Load<Texture2D>("Logo/Bouton Retour");
            if (scene == 1)
                boutonBackTex = Content.Load<Texture2D>("Logo/Bouton Quitter");
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

        public void TPSCount()
        {
            if (TPS > 60) secondes = TPS / 60;
            if (secondes > 60) minutes = secondes / 60;
            if (minutes > 60) heures = minutes / 60;
        }
        public int[] TPSCount(int tps)
        {
            int[] info = new int[3];
            if (tps > 60) info[0] = tps / 60;
            if (info[0] > 60) info[1] = info[0] / 60;
            if (info[1] > 60) info[2] = info[1] / 60;

            return info;
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
