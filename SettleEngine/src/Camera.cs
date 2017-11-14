using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleEngine.src
{
    public class Camera
    {

        private Vector3 Position;
        private Vector3 Up;
        private Vector3 Forward;
        public float nearClip = 1;
        public float farClip = 200;
        private float fieldOfView = MathHelper.PiOver4;
        private GraphicsDeviceManager graphics = Game1.graphics;

        public Vector3 getPos()
        { return Position; }
        public Vector3 getUp()
        { return Up; }
        public Vector3 getForward()
        { return Forward; }
        public float getFieldOfView()
        { return fieldOfView; }
        public float getAspect()
        { return graphics.PreferredBackBufferWidth / (float)graphics.PreferredBackBufferHeight; }
        public float getNearClip()
        { return nearClip; }
        public float getFarClip()
        { return farClip; }

        public Matrix getViewMatrix()
        {
            return Matrix.CreateLookAt(Position, Forward + Position, Up);
            
        }

        
        public Camera(Vector3 position, Vector3 forward, Vector3 up)
        {
            Position = position;
            Forward = forward;
            Up = up;
        }

 
        public void Thrust(float amount)
        {
            Forward.Normalize();
            Position += Forward * amount;
        }


        public void StrafeHorz(float amount)
        {
            var left = Vector3.Cross(Up, Forward);
            left.Normalize();
            Position += left * amount;
        }

        /// <param name="amount"></param>
        public void StrafeVert(float amount)
        {
            Up.Normalize();
            Position += Up * amount;
        }

        public void Roll(float amount)
        {
            Up.Normalize();
            var left = Vector3.Cross(Up, Forward);
            left.Normalize();

            Up = Vector3.Transform(Up, Matrix.CreateFromAxisAngle(Forward, MathHelper.ToRadians(amount)));
        }

        public void Yaw(float amount)
        {
            Forward.Normalize();

            Forward = Vector3.Transform(Forward, Matrix.CreateFromAxisAngle(Up, MathHelper.ToRadians(amount)));
        }

        public void Pitch(float amount)
        {
            Forward.Normalize();
            var left = Vector3.Cross(Up, Forward);
            left.Normalize();

            Forward = Vector3.Transform(Forward, Matrix.CreateFromAxisAngle(left, MathHelper.ToRadians(amount)));
            Up = Vector3.Transform(Up, Matrix.CreateFromAxisAngle(left, MathHelper.ToRadians(amount)));
        }
    }
}

