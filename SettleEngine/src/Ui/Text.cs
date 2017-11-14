using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SettleEngine.src.Tools;
using System.Diagnostics;

namespace SettleEngine.src.Ui
{
    public class Text : Element
    {
        public Color textColor { get; set; }
        public Vector2 pos { get; set; } //Set the pos in the loader not the rRec, there is not rRec for text

        //Constructor Loads Font by string name
        public Text(string t, Fonts font, UILocation l, Vector2 p, Color tColor)
        {
            this.text = t;
            this.font = Loader.LoadFont(font);
            this.pos = p;
            this.textColor = tColor;
        }

        public override void Initialize()
        {
            eType = UIElementType.Text;
            pos = new Vector2(pos.X - font.MeasureString(text).X/2 ,pos.Y - font.MeasureString(text).Y/2);


        }

        public override void Update(MouseState m, KeyboardState k)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, pos, textColor);

        }

    }
}
