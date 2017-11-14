using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.Screen
{
    public abstract class Transition
    {
        public Boolean isFullscreen;
        public Boolean isComplete { get; set; }
        public Boolean canTransition { get; set; }
        public Boolean isTranistioning { get; set; }

        public Action<string> action;
        public string input;

        public virtual void Initialize(){ }

        public virtual void startTranstion() { }

        public virtual void Update(GameTime gameTime, MouseState m, KeyboardState k) { }

        public virtual void Draw(SpriteBatch spriteBatch) { }

        
    }
}
