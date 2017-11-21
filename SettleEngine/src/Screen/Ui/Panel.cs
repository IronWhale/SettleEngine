using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SettleEngine.src.Ui
{
    public class Panel
    {

        public Boolean show;
        public Rectangle rec { get; set; }
        public Color baseColor;
        public Boolean hasBorder;
        public int borderSize;
        public Rectangle borderRec; //Calculated during initialize
        public Color borderColor;

        public Texture2D texture;
        public List<Element> elements = new List<Element>();

        //Constructor for having a nice border
        public Panel(Boolean s, Rectangle r, Color baseC, int bSize, Color borColor )
        {
            this.show = s;
            this.rec = r;
            this.baseColor = baseC;
            this.hasBorder = true;
            this.borderSize = bSize;
            this.borderColor = borColor;
        }

        //Constructor for no border but panel is drawn
        public Panel(Boolean s, Rectangle r, Color baseC)
        {
            this.show = s;
            this.rec = r;
            this.baseColor = baseC;
            this.hasBorder = false;
            this.borderSize = 0;
            this.borderColor = Color.Transparent;
        }

        //Constructor for no panel and no border
        public Panel(Boolean s, Rectangle r)
        {
            this.show = s;
            this.rec = r;
            this.baseColor = Color.Transparent;
            this.hasBorder = false;
            this.borderSize = 0;
            this.borderColor = Color.Transparent;
        }

        public Panel ()
        { }

        public virtual void Initialize()
        {
            //Calculate the border box size
            borderRec = new Rectangle(rec.X - borderSize, rec.Y - borderSize, rec.Width + 2* borderSize, rec.Height + 2 * borderSize);


            foreach (var element in elements)
            { element.Initialize(); }
        }

        public virtual void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Textures/White_Square");

            foreach (var element in elements)
            { element.Load(Content); }
        }

        public virtual void Add(Element e)
        { elements.Add(e); }

        public virtual void Update(GameTime gameTime, MouseState m, KeyboardState k)
        {
            foreach (var element in elements)
            { element.Update(m, k); }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //Draw the panel first including the border
            if (hasBorder)
            { spriteBatch.Draw(texture, borderRec, borderColor); }

            spriteBatch.Draw(texture, rec, baseColor);

            //Draw all the elements 
            foreach (var element in elements)
            { element.Draw(spriteBatch); }
        }

        public void passRefernce()
        {
            foreach (var element in elements)
            {
                element.setParentPanel(this);//Pass refernce to parent panel for relative positioning}
            }

        }
    }
}
