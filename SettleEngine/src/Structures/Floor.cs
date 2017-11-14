using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.Structures
{
    public class Floor : Structure
    {
        public Floor()
        { }

        public override void Initialize()
        {
            type = StructureType.Floor;
            snapsToGrid = true;

        }

        public override void Load()
        {
        }

        public override void Update(GameTime gameTime, MouseState m, KeyboardState k)
        {
        }

        
    }
}
