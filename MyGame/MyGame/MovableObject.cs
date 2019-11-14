using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
	public class MovableObject : Drawer
	{
		public float velocityX;
		public float velocityY;
		public float speed;
		public float direction;

		public MovableObject(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, float speed, float direction) : base(texture, position, sourceRectangle,color, rotation, origin, scale, effects, layerDepth) {

			this.speed = speed;
			this.rotation = rotation;
		}

		public void Update()
		{
			velocityX = (float)((Math.Cos(rotation)) * speed);
			velocityY = (float)((Math.Sin(rotation)) * speed);

			move(velocityX, velocityY);
		}

		public void move(float velocityX, float velocityY)
		{
			//origin = position;
			position.X = (position.X + (int)velocityX) % Game1.windowWidth;
			position.Y = (position.Y + (int)velocityY) % Game1.windowHeight;
		}
	}
}
