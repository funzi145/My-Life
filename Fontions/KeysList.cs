using Microsoft.Xna.Framework.Input;
using My_Life;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGame_Test
{
    class KeysList
    {
        static KeyboardState ks1, ks2;

        public static string KeyTracker(string str)
        {
            ks1 = Keyboard.GetState();

            if (ks1.IsKeyDown(Keys.A) && ks2.IsKeyUp(Keys.A))
                str = str + 'A';
            if (ks1.IsKeyDown(Keys.B) && ks2.IsKeyUp(Keys.B))
                str = str + 'B';
            if (ks1.IsKeyDown(Keys.C) && ks2.IsKeyUp(Keys.C))
                str = str + 'C';
            if (ks1.IsKeyDown(Keys.D) && ks2.IsKeyUp(Keys.D))
                str = str + 'D';    
            if (ks1.IsKeyDown(Keys.E) && ks2.IsKeyUp(Keys.E))
                str = str + 'E';
            if (ks1.IsKeyDown(Keys.F) && ks2.IsKeyUp(Keys.F))
                str = str + 'F';
            if (ks1.IsKeyDown(Keys.G) && ks2.IsKeyUp(Keys.G))
                str = str + 'G';
            if (ks1.IsKeyDown(Keys.H) && ks2.IsKeyUp(Keys.H))
                str = str + 'H';
            if (ks1.IsKeyDown(Keys.I) && ks2.IsKeyUp(Keys.I))
                str = str + 'I';
            if (ks1.IsKeyDown(Keys.J) && ks2.IsKeyUp(Keys.J))
                str = str + 'J';
            if (ks1.IsKeyDown(Keys.K) && ks2.IsKeyUp(Keys.K))
                str = str + 'K';
            if (ks1.IsKeyDown(Keys.L) && ks2.IsKeyUp(Keys.L))
                str = str + 'L';
            if (ks1.IsKeyDown(Keys.M) && ks2.IsKeyUp(Keys.M))
                str = str + 'M';
            if (ks1.IsKeyDown(Keys.N) && ks2.IsKeyUp(Keys.N))
                str = str + 'N';
            if (ks1.IsKeyDown(Keys.O) && ks2.IsKeyUp(Keys.O))
                str = str + 'O';
            if (ks1.IsKeyDown(Keys.P) && ks2.IsKeyUp(Keys.P))
                str = str + 'P';
            if (ks1.IsKeyDown(Keys.Q) && ks2.IsKeyUp(Keys.Q))
                str = str + 'Q';
            if (ks1.IsKeyDown(Keys.R) && ks2.IsKeyUp(Keys.R))
                str = str + 'R';
            if (ks1.IsKeyDown(Keys.S) && ks2.IsKeyUp(Keys.S))
                str = str + 'S';
            if (ks1.IsKeyDown(Keys.T) && ks2.IsKeyUp(Keys.T))
                str = str + 'T';
            if (ks1.IsKeyDown(Keys.U) && ks2.IsKeyUp(Keys.U))
                str = str + 'U';
            if (ks1.IsKeyDown(Keys.V) && ks2.IsKeyUp(Keys.V))
                str = str + 'V';
            if (ks1.IsKeyDown(Keys.W) && ks2.IsKeyUp(Keys.W))
                str = str + 'W';
            if (ks1.IsKeyDown(Keys.X) && ks2.IsKeyUp(Keys.X))
                str = str + 'X';
            if (ks1.IsKeyDown(Keys.Y) && ks2.IsKeyUp(Keys.Y))
                str = str + 'Y';
            if (ks1.IsKeyDown(Keys.Z) && ks2.IsKeyUp(Keys.Z))
                str = str + 'Z';
            if (ks1.IsKeyDown(Keys.Enter) && ks2.IsKeyUp(Keys.Enter))
                Game1.isTyping = false;
            if (ks1.IsKeyDown(Keys.Back) && ks2.IsKeyUp(Keys.Back))
                str = "";
            if (ks1.IsKeyDown(Keys.Escape) && ks2.IsKeyUp(Keys.Escape))
                str = "";

            ks2 = ks1;

            return str;

        }

    }
}
