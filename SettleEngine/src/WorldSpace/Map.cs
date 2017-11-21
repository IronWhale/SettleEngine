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
        private int mapLength;
        private int mapWidth;
        private float Scale;
        private Tile[,] tiles;
        private int loadWidth = 34; //16:9 doubled and add two for a buffer
        private int loadHeight = 20;



        public void Initialize()
        {

        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale)
        {
            int x = (-1) * (int)(pos.X - ((loadWidth / 2))); //start tile coord for drawing
            int y = (-1) * (int)(pos.Y - ((loadHeight / 2)));

            for (int i = x; i < mapWidth; i++)
            {
                for (int j = y; j < mapLength; j++)
                {
                    if(i >= 0 && j >= 0 && i <= mapWidth && j <= mapLength ) { //prevent trying to draw tiles that are outside of the bounds of the map data
                        tiles[i, j].Draw(spriteBatch, pos, scale);
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
            mapWidth = 100;
            mapLength = 100;
            Tile[,] testMap = new Tile[mapWidth, mapLength];
            

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {
                    testMap[i, j] = new Tile(new Vector2(i,j), t);
                }
            }
            tiles = testMap;
        }
    }
}
