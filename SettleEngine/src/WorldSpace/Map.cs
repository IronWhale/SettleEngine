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
    public class Map
    {
        private string name = "";
        private int mapLength;
        private int mapWidth;
        private Tile[,] tiles;



        public void saveMaptoFile(string fileName)
        {

        }

        internal string getName()
        {
            return name;
        }

        public void loadMapFromFile(string fileName)
        { }
    }
}
