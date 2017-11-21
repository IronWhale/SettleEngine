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
using SettleEngine.src.Screen;

namespace SettleEngine.src.Ui
{
    public class StudioScreen
    {
        private String studioName = "-Iron Whale Studios-";
        private SpriteFont font;
        private FadeOut fOut = new FadeOut(Game1.UpdateGameMode, "MainMenu", 2.0f, 1.5f);


        public void Initialize()
        {
            Game1.transitionManager.Add(fOut);
        }

        public void Load(ContentManager Content)
        {
            font = Loader.LoadFont(Fonts.Studio);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointWrap, null, null, null, null);
            spriteBatch.DrawString(font, studioName, new Vector2((1920 / 2 - (font.MeasureString(studioName) / 2).X), (1080 / 2.5f - (font.MeasureString(studioName) / 2).Y)), Color.White);
            spriteBatch.End();
        }
    }
}
