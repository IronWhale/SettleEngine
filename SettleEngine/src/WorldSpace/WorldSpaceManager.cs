using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SettleEngine.src.Actor;

namespace SettleEngine.src.WorldSpace
{
    public class WorldSpaceManager
    {
        private string locationName;
        private Map map;
        private Vector2 scale = new Vector2(1920 / 32, 1080 / 18); //number of pixels in each tile
        private Player player;

        public void Initialize()
        {
            //currentCell = map.getName();



            //TEST INITIALIZATION
            player = new Player(new Vector2(0,0), .1f, ActorDirection.Down);
            map = new Map();
            map.loadTEST();
        }

        public void Load(String mapFile)
        {

        }
        public void Update(GameTime gameTime, MouseState m, KeyboardState k)
        {
            map.Update();
            player.Update(gameTime, m, k);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch, player.getPos(), scale);
        }
    }
}
