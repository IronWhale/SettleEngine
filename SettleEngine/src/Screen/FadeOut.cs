using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using SettleEngine.src.Tools;

namespace SettleEngine.src.Screen
{
    public class FadeOut : Transition
    {
        private Rectangle rec;
        private Texture2D texture;
        private Color color = Color.TransparentBlack;

        private float delay = 1.0f;
        private float delayToBlk = .5f;
        private float delta;
        private float alpha;



        public FadeOut(Action<string> action, string input)
        {
            this.action = action;
            this.input = input;
        }

        public FadeOut(Action<string> action, string input, float delay, float delayTo)
        {
            this.action = action;
            this.input = input;
            this.delay = delay;
            this.delayToBlk = delayTo;
        }

        public override void startTranstion()
        {
            action(input);
        }

        public override void Initialize()
        {
            isFullscreen = true;
            isComplete = false;
            canTransition = false;
            isTranistioning = false;
            rec = new Rectangle(0,0,1920,1080);
            texture = Loader.LoadTexture2D("White_square");
        }


        public override void Update(GameTime gameTime, MouseState m, KeyboardState k)
        {
            delta += (gameTime.ElapsedGameTime.Milliseconds / 1000.0f);

            if (delta >= delay)
            { isComplete = true; }
            else if (delta >= delayToBlk)
            {
                canTransition = true;
                if(!isTranistioning)
                {
                    startTranstion();
                    isTranistioning = true;
                }
                    
            }

            alpha = ((delta / delayToBlk) * 255); //Cast and calculate to alpha data
            if (alpha >= 255)
            { alpha = 255; }

            color.A = (byte)alpha;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
            if (!isComplete)
            { spriteBatch.Draw(texture, rec, color); }

        }






    }
}
