using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SettleEngine.src.Tools;

namespace SettleEngine.src.WorldSpace
{
    public class Map
    {
        private string name = "";
        private int mapHeight;
        private int mapWidth;
        private float Scale;
        private Tile[,] tiles;
        private int loadWidth = 16; //16:9 doubled and add two for a buffer
        private int loadHeight = 9;



        public void Initialize()
        {

        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale)
        {
            //@CLEANUP THIS IS EXPENSIVE
            //Needs to only draw the tiles around the camera
            /*
            int upX = (int)pos.X + loadWidth;
            int upY = (int)pos.Y + loadHeight;
            int lowX = (int)pos.X - loadWidth;
            int lowY = (int)pos.Y - loadHeight;
            */

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    //As long as i and j are not less than zero and the are between render bounds for camera Draw it.
                    //if (i >= lowX && i <= upX && j >= lowY && j <= upY && i >= 0 && j >= 0)
                    {
                        tiles[i, j].Draw(spriteBatch, scale);
                    }
                }
            }
        }

        public void saveMaptoFile(string fileName)
        { }

        internal string getName()
        { return name; }

        public void loadMapFromFile(string fileName)
        { }


        public void loadTEST()
        {
            Texture2D t = Loader.LoadTexture2D("TestTile");
            mapWidth = 50;
            mapHeight = 50;
            Tile[,] testMap = new Tile[mapWidth, mapHeight];
            

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {

                    testMap[i, j] = new Tile(new Vector2(i, j), t);
                   
                }
            }
            tiles = testMap;
        }
    }
}
