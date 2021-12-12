using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace My_Life
{
    class OneShotKeyboard
    {
        static KeyboardState currentState, previousState;

        public OneShotKeyboard()
        {
        }

        public static KeyboardState GetState()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
            return currentState;
        }

        public static bool IsPressed(Keys key)
        {
            return currentState.IsKeyDown(key);
        }

        public static bool HasNotBeenPressed(Keys key)
        {
            return currentState.IsKeyDown(key) && !previousState.IsKeyDown(key);
        }

    }
}
