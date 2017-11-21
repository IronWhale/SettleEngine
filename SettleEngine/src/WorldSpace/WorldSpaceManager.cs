using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SettleEngine.src.Actor;
using MonoGame.Extended;
using SettleEngine.src.Tools;

namespace SettleEngine.src.WorldSpace
{
    public class WorldSpaceManager
    {
        private string locationName;
        private Map map;
        private Vector2 scale = new Vector2(1920 / 32, 1080 / 18); //number of pixels in each tile
        private Player player;
        private Camera2D camera;
        private GraphicsDevice device;

        public void Initialize(GraphicsDevice pDevice)
        {
            //currentCell = map.getName();
            device = pDevice;
            camera = new Camera2D(device);

            //TEST INITIALIZATION
            player = new Player(new Vector2(30,20), .1f, ActorDirection.Down);
            map = new Map();
            map.loadTEST();
            //THIS MAY NOT BE 100% accurate
            camera.Position = new Vector2((player.getPos().X * scale.X) - ((1920/2) - (scale.X/2)), (player.getPos().Y * scale.Y) - ((1080 / 2) - (scale.Y / 2)));
        }

        public void Load(String mapFile)
        {

        }
        public void Update(GameTime gameTime, MouseState m, KeyboardState k)
        {
            map.Update();
            player.Update(gameTime, m, k);

            //Use Keyboard inputs to move the camera in the map space
            if (k.IsKeyDown(Keys.Down))
            { camera.Move(new Vector2(0, 1)); }
            if (k.IsKeyDown(Keys.Up))
            { camera.Move(new Vector2(0, -1)); }
            if (k.IsKeyDown(Keys.Left))
            { camera.Move(new Vector2(-1, 0)); }
            if (k.IsKeyDown(Keys.Right))
            { camera.Move(new Vector2(1, 0)); }

            //Update the players position based on cameras position as upper left corner thing shifted over to the center tile
            player.setPos(new Vector2((camera.Position.X + ((1920/2) - (scale.X /2)))  , (camera.Position.Y + ((1080 / 2) - (scale.Y / 2))) ));
            

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointWrap, null, null, null, transformMatrix: camera.GetViewMatrix());
            map.Draw(spriteBatch, player.getPos(), scale);

            //TODO: Draw the character
            spriteBatch.End();
        }
    }
}
