using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
	public class MovableObject : Drawer
	{
		public float speed;

		public MovableObject(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, float speed) : base(texture, position, sourceRectangle,color, rotation, origin, scale, effects, layerDepth) {

			this.speed = speed;
			this.rotation = rotation;
            Game1.Updated += Update;
		}

		void Update()
		{
            Move();

            Matrix mat = Matrix.CreateRotationZ(rotation);
            Vector2 direction = Vector2.Transform(Vector2.UnitX, mat);

            position += direction * speed;

            //handle overflow
            /*
            position.X = (position.X + Game1.windowWidth)  % Game1.windowWidth;
            position.Y = (position.Y + Game1.windowHeight) % Game1.windowHeight;
            */
        }

        void Move()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up)) // increase spped
            {
                speed += 0.15F;

                if (speed < 0) speed = 0;
            }

            if (state.IsKeyDown(Keys.Down)) // decrease speed
            {
                speed -= 0.2F;
            }

            if (state.IsKeyDown(Keys.Right))// rotate right
            {
                rotation += 0.04F * speed / 4; // increase rotation
            }

            else if (state.IsKeyDown(Keys.Left))
            { // rotate left

                rotation -= 0.04F * speed / 4; // decrease rotation 
            }
        }
	}
}
