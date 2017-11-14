using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.Ui
{
    public abstract class Element
    {
        public string text { get; set; }
        public SpriteFont font { get; set; }
        public Vector2 pos { get; set; } //Real position used for drawing.
        public Rectangle rRect { get; set; } //Real rectangle used for drawing.
        public Rectangle lRect; //Logical rectangle used for mouse interaction.
        public UIElementType eType; //Specifics what the type is
        public UILocation location; //Allows the Location to be Relative or Absolute
        public Panel parentPanelRef; //Reference to the panel containing the element
        public Boolean isGrouped; //Lets the class know if the element is part of a group and effects the way the element is interacted with.

        //Used for buttons
        public Boolean isSelected { get; set; }

        public virtual void Initialize() { }

        public virtual void Load(ContentManager Content) { }

        public virtual void Update(MouseState m, KeyboardState k) { }

        public virtual void Draw(SpriteBatch spriteBatch) { }

        public void setParentPanel(Panel p)
        { parentPanelRef = p; }
    }
}
