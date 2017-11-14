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
    public class Structure
    {
        public Vector3 position;
        public Vector3 defaultRot;
        public Vector3 rotation;
        public Vector3 scale;
        public Model model;

        //Information on stucture typing and snapping
        public bool snapsToGrid;
        public StructureType type;
        public SnappingDirection snapDir; //Overrides Rotation

        public virtual void Initialize() { }

        public virtual void Load() { }

        public virtual void Update(GameTime gameTime, MouseState m, KeyboardState k) { }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (var mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.World = Matrix.CreateTranslation(position);
                    effect.View = camera.getViewMatrix();
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(camera.getFieldOfView(), camera.getAspect(), camera.getNearClip(), camera.getFarClip());
                }
                mesh.Draw();
            }
        }


    }
}
