using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.WorldSpace
{
    public class WorldSpaceManager
    {
        private string locationName;
        private Map map;
        


        public void Initialize()
        {
            //currentCell = map.getName();
        }

        public void Load(String mapFile)
        {
            if (map == null) { //Load the file save nothing
            }
            else {
                //TODO: Load the map file and save the old file
            }
        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
