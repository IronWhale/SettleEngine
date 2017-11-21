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

namespace SettleEngine.src.Ui
{
    public class Button : Element
    {

        //color of text
        public Color baseColor { get; set; }
        public Color selectedColor { get; set; }
        //
        public Boolean isClicked { get; set; }


        //Clicked action
        private Action<string> action;
        private string gameAction;
        private MouseState oldM;

        public Button(string text, Boolean isGrouped, Fonts font ,UILocation location, Vector2 pos, Color bColor, Color sColor, Action<string> action, string inAction)
        {
            this.text = text;
            this.isGrouped = isGrouped;
            this.font = Loader.LoadFont(font);
            this.location = location;
            this.pos = pos;
            this.baseColor = bColor;
            this.selectedColor = sColor;
            this.action = action;
            this.gameAction = inAction;
        }

        public override void Initialize()
        {
            eType = UIElementType.Button;
            rRect = new Rectangle((int)pos.X, (int)pos.Y, (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y); //Generate the rectangle for positioning
            lRect = new Rectangle((int)(pos.X * Game1.scale.X), (int)(pos.Y * Game1.scale.Y), (int)(font.MeasureString(text).X * Game1.scale.X), (int)(font.MeasureString(text).Y * Game1.scale.Y));

            if (location == UILocation.Relative)
            {  //Generates the logical rectangle based on relative positioning and repositions from panel position. GOOD FOR MOVABLE PANELS
                rRect = new Rectangle((int)(parentPanelRef.rec.X + pos.X), (int)(parentPanelRef.rec.Y + pos.Y), (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y);
                lRect = new Rectangle((int)((parentPanelRef.rec.X * Game1.scale.X) + lRect.X), (int)((parentPanelRef.rec.Y * Game1.scale.Y) + lRect.Y), lRect.Width, lRect.Height);
            }
        }

        public override void Update(MouseState m, KeyboardState k)
        {
            if (!isGrouped)
            { isSelected = checkCollison(m); }

            isClicked = checkClick(m,k);

            if (isClicked)
            { action(gameAction); }

            //Update old mouse
            oldM = m;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isSelected)
            { spriteBatch.DrawString(font, text, new Vector2(rRect.X, rRect.Y), selectedColor); }
            else
            { spriteBatch.DrawString(font, text, new Vector2(rRect.X, rRect.Y), baseColor); }

        }

        //Button Specific Methods
        public Boolean checkCollison(MouseState m)
        {
            return lRect.Contains(m.X, m.Y);
        }

        public Boolean checkClick(MouseState m, KeyboardState k)
        {
            return (((checkCollison(m) && m.LeftButton == ButtonState.Pressed) && oldM.LeftButton == ButtonState.Released) || (isSelected && k.IsKeyDown(Keys.Enter)));
        }

       
    }
}
