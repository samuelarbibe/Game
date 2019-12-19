using System;
using MyGame.Source;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
	class MovableObject : Drawer
	{
		public float speed;
        public BaseKeys directionKeys;


		public MovableObject(BaseKeys directionKeys, Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, float speed) : base(texture, position, sourceRectangle,color, rotation, origin, scale, effects, layerDepth)
        {
			this.speed = speed;
			this.rotation = rotation;
            this.directionKeys = directionKeys;
            Game1.Updated += Update;
		}

		void Update()
		{
            Move();

            Matrix mat = Matrix.CreateRotationZ(rotation);
            Vector2 direction = Vector2.Transform(Vector2.UnitX, mat);

            position += direction * speed;
        }

        void Move()
        {
            if (directionKeys.GoUp()) // increase spped
            {
                speed += 0.15F;

                if (speed < 0) speed = 0;
            }

            if (directionKeys.GoDown()) // decrease speed
            {
                speed -= 0.2F;
            }

            if (directionKeys.GoRight())// rotate right
            {
                rotation += 0.04F * speed / 4; // increase rotation
            }

            else if (directionKeys.GoLeft())
            { // rotate left

                rotation -= 0.04F * speed / 4; // decrease rotation 
            }
        }
	}
}
