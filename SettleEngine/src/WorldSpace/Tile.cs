using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.WorldSpace
{
    public class Tile
    {
        private Texture2D texture;
        private Rectangle rec;
        private Vector2 iPos; //Tiles internal position in the array

        public Tile(Vector2 iP, Texture2D t)
        {
            texture = t;
            iPos = iP;
        }

        public void Update()
        { }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale)
        {
            //Recalulate the Rectangles position on screen
            int x = -1 * (int)((pos.X - iPos.X) * (scale.X)) - 960;
            int y = -1 * (int)((pos.Y - iPos.Y) * (scale.Y)) - 540;
            rec = new Rectangle(x, y,(int)scale.X, (int)scale.Y);
            //Draw the Tile
            spriteBatch.Draw(texture, rec, Color.White);
        }
    }
}
