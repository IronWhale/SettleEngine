using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleEngine.src.Inputs
{
    public static class InputManager
    {
        private static KeyboardState k;
        //private static 
        public static Boolean isFreshDown(Input i)
        {
            //TODO:
            return false;
        }

        public static Boolean isDown()
        {
          
            return false;
        }

    }


    public enum Input
    { UP, DOWN, LEFT, RIGHT, A, B, START, SELECT}
}
