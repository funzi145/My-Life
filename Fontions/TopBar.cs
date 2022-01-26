using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Life
{
    class TopBarClass
    {
        Color textColor = new Color(64, 64, 64);

        static Rectangle boutonBackRectangle = new Rectangle(350, 16, 120, 30),
                boutonParametreRectangle = new Rectangle(315, 15, 30, 30),
                boutonSaveRectangle = new Rectangle(280, 15, 30, 30);

        public static void TopBar()
        {
            ClickCheck();
            StringChoose();
        }

        public static void ClickCheck()
        {
            if(Game1.ClickTest(Mouse.GetState(), boutonSaveRectangle)) { ChangeScene(-1); }
            if(Game1.ClickTest(Mouse.GetState(), boutonBackRectangle)) { ChangeScene(buttonBackTest()); }
            if (Game1.ClickTest(Mouse.GetState(), boutonParametreRectangle)) { ChangeScene(8); }
        }

        private static void ChangeScene(int a)
        {
            Game1.scene = a;
        }

        public static string StringChoose()
        {
            switch (Game1.scene)
            {
                case -1:
                    return "SAUVEGARDER";
                case 1:
                    return "MENU PRINCIPAL";
                case 2:
                    return "NOURRITURE";
                case 3:
                    return "SANTE";
                case 4:
                    return "JOB";
                case 5:
                    return "BANQUE";
                case 6:
                    return "ACHAT";
                case 7:
                    return "NESTER";
                case 8:
                    return "PARAMETRE";
                default:
                    return "Erreur";

            }

        }

        public static int buttonBackTest()
        {
            if (Game1.ClickTest(Mouse.GetState(), boutonBackRectangle))
            {
                switch(Game1.scene)
                {
                    case 1:
                        Game1.toExit = true;
                        break;
                    default :
                        return 1;
                }
            }
            return 0;
        }


    }
}
