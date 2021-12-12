using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace My_Life
{
    class OneShotMouseButton
    {
        static MouseState currentState, previousState;

        public OneShotMouseButton()
        {
        }

        public static MouseState GetState()
        {
            previousState = currentState;
            currentState = Mouse.GetState();
            return currentState;
        }

        public static bool IsPressed(bool left)
        {
            if (left)
                return currentState.LeftButton == ButtonState.Pressed;
            else
                return currentState.RightButton == ButtonState.Pressed;
        }

        public static bool HasNotBeenPressed(bool left)
        {
            if (left)
                return currentState.LeftButton == ButtonState.Pressed && !(previousState.LeftButton == ButtonState.Pressed);
            else
                return currentState.RightButton == ButtonState.Pressed && !(previousState.RightButton == ButtonState.Pressed);
        }
    }
}
