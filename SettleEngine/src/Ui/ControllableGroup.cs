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

namespace SettleEngine.src.Ui
{
    public class ControllableGroup : Panel
    {

        private List<Element> elements = new List<Element>();
        private int selected;
        private int MaxItems;

        private MouseState oldM;
        private KeyboardState oldK;

        public ControllableGroup(Rectangle r)
        {
            this.show = false;
            this.rec = r;
            this.baseColor = Color.Transparent;
            this.hasBorder = false;
            this.borderSize = 0;
            this.borderColor = Color.Transparent;
        }

        public ControllableGroup(Boolean s, Rectangle r, Color baseC)
        {
            this.show = s;
            this.rec = r;
            this.baseColor = baseC;
            this.hasBorder = false;
            this.borderSize = 0;
            this.borderColor = Color.Transparent;
        }

        public override void Initialize()
        {

            Debug.WriteLine("Scale X: " + Game1.scale.X + " Y: " + Game1.scale.Y);
            MaxItems = elements.Count;
            selected = 0;

            foreach (var element in elements)
            { element.Initialize(); }
        }

        public override void Add(Element element)
        { elements.Add(element); }

        public override void Load(ContentManager Content)
        {
            //Load the blank texture
            texture = Content.Load<Texture2D>("Textures/White_Square");

            foreach (var element in elements)
            { element.Load(Content); }
        }

        public override void Update(GameTime gameTime, MouseState m, KeyboardState k)
        {
            

            //Check if UP was pressed
            if (k.IsKeyDown(Keys.Up) && oldK.IsKeyUp(Keys.Up))//Just pressed down up
            {
                if (selected == 0)
                { selected = (MaxItems - 1); }
                else
                { selected--; }
            }

            //Check if Down was pressed
            if (k.IsKeyDown(Keys.Down) && oldK.IsKeyUp(Keys.Down))
            {
                if (selected == (MaxItems - 1))
                { selected = 0; }
                else
                { selected++; }
            }



            //Update the currently selected item and determine if the mouse pointer overrides current object
            if (elements[selected].eType == UIElementType.Button)
            { elements[selected].isSelected = true; }


            //Unselect the other options
            for (int i = 0; i < MaxItems; i++)
            {
                if (i != selected)
                    elements[i].isSelected = false;

                if (elements[selected].eType == UIElementType.Button)
                {
                    
                    Button temp = (Button)elements[i];//Create a temp
                    if (temp.checkCollison(m))//if we are mousing over
                    {
                        selected = i;
                        temp.isSelected = true;
                    }
                    elements[i] = temp;//return the button
                   
                }


            }
            foreach (var element in elements)
            { element.Update(m,k); }

            oldM = m;
            oldK = k;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //This group box is not usually drawn
            //Draw the controllabel Group first including the border if there is one
            if (hasBorder)
            { spriteBatch.Draw(texture, borderRec, borderColor); }

            //Draw rectangle
            spriteBatch.Draw(texture, rec, baseColor);

            foreach (var element in elements)
            { element.Draw(spriteBatch); }


        }

       



    }
}
