using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.Tools
{
    public static class QuickDraw
    {
        public static Texture2D texture = Loader.LoadTexture2D("White_square");
        public static Rectangle rec;
        public static Color defColor = new Color(255,255,255,140);

        public static void DrawRec(SpriteBatch spriteBatch, Rectangle inRec)
        {
            Rectangle r = inRec;
            spriteBatch.Draw(texture, inRec, defColor);
        }
    }
}
