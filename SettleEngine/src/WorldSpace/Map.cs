using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SettleEngine.src.Tools;
using System.Diagnostics;

namespace SettleEngine.src.WorldSpace
{
    public class Map
    {
        private string name = "";
        private int mapHeight;
        private int mapWidth;
        private Tile[,] tiles;
        private int loadWidth = 17; //16:9 doubled and add two for a buffer
        private int loadHeight = 10;



        public void Initialize()
        {

        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale)
        {
            int tilesDrawn = 0;
            //Get the range of tiles to draw around the players position in the center of the screen
            int upX = (int)(pos.X / scale.X) + loadWidth;
            int upY = (int)(pos.Y / scale.Y) + loadHeight;
            int lowX = (int)(pos.X / scale.X) - loadWidth;
            int lowY = (int)(pos.Y / scale.Y) - loadHeight;
          

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    //As long as i and j are not less than zero and the are between render bounds for camera Draw it.
                    if (i >= lowX && i <= upX && j >= lowY && j <= upY && i >= 0 && j >= 0)
                    {
                        tilesDrawn++;
                        tiles[i, j].Draw(spriteBatch, scale);
                    }
                }
            }
            //Print the number of tiles that are drawn
            //Debug.WriteLine("Tiles Drawn: " + tilesDrawn); //should draw 735 tiles or 35 x 21
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
