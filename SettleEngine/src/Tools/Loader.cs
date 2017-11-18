using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SettleEngine.src.Items;
using SettleEngine.src.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleEngine.src.Tools
{
    public static class Loader
    {
<<<<<<< HEAD
=======
        
>>>>>>> 0fae8c51e05861589a43885391ae24ae0b265737

        public static Item LoadItem()
        {
            //TODO:
            return null;
        }

        public static SpriteFont LoadFont(String fileName)
        {
            return Game1.manager.Load<SpriteFont>("Fonts/"+ fileName);
        }

        public static SpriteFont LoadFont(Fonts fontName)
        {
            return Game1.manager.Load<SpriteFont>("Fonts/" + fontName.ToString());
        }

        public static Texture2D LoadTexture2D(string fileName)
        { return Game1.manager.Load<Texture2D>("Textures/" + fileName); }



    }
}
