using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.Actor
{
    public class Player
    {


        public float moveSpeed = 1;
        public Vector3 pos { get; set; }
        public ActorDirection dir { get; set; }

        public void Initialize()
        { }

        public void Load(ContentManager Content)
        { }

        public void Update(GameTime gameTime, MouseState m, KeyboardState k) {


            //Use Mouse position raycast to current ground level to get rotational orientatoin
           

            //Use Keyboard inputs to move the player in the world




            //Update the oldM and oldK for debounching
        }

        public void Draw(SpriteBatch spriteBatch) {

            //Draw player based on facing direction
            switch (dir)
            {
                case  ActorDirection.Up: //Renders the player facing up

                    break;

                case ActorDirection.Left:

                    break;

                case ActorDirection.Right:

                    break;

                case ActorDirection.Down: //Renders player facing down

                    break;




            }

        }

    }
}
