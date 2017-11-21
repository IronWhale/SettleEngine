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
        public Vector2 pos;
        public ActorDirection dir { get; set; }

        public Player(Vector2 p, float mSpeed, ActorDirection dir)
        {
            this.pos = p;
            this.moveSpeed = mSpeed;
            this.dir = dir;
        }

        public void Initialize()
        {

        }

        public void Load(ContentManager Content)
        {

        }

        public void Update(GameTime gameTime, MouseState m, KeyboardState k) {

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




        public Vector2 getPos()
        { return pos; }

        public void setPos(Vector2 p)
        { pos = p; }
    }
}
