using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
	public class Drawer
	{
		protected Texture2D texture;
		protected Texture2D rectangleTexture;
		protected Rectangle? sourceRectangle;
		public Vector2 position;
		protected Color color;
		public float rotation;
		protected Vector2 origin;
		protected Vector2 scale;
		protected SpriteEffects effects;
		protected float layerDepth;
		public static bool showRectangle;


		public Drawer(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			this.texture = texture;
			this.position = position;
			this.sourceRectangle = new Rectangle((int)position.X, (int)this.position.Y, texture.Width, texture.Height);
			this.color = color;
			this.rotation = rotation;
			this.origin = origin;
			this.scale = scale;
			this.effects = effects;
			this.layerDepth = layerDepth;

			if (showRectangle == true) // if wanting to draw a rectangle around object, create texture for it
			{
                createRectangleTexture();
			}

		}

		private void createRectangleTexture()
		{
			var colors = new List<Color>();

			for (int y = 0; y < this.texture.Height; y++)
			{
				for (int x = 0; x < this.texture.Width; x++)
				{
					if (x == 0 || y == 0 || x == texture.Width - 1 || y == texture.Height - 1)
					{
						colors.Add(Color.Black);
					}
					else
					{
						colors.Add(Color.Transparent);
					}
				}
			}
		}

		public void Draw()
		{			
			G.spriteBatch.Draw(texture, position, sourceRectangle,color, rotation, origin, scale, effects, layerDepth);

			if (showRectangle) // if wanting to draw rectangle around object
			{
				if(rectangleTexture != null) { // draw rectangle
					G.spriteBatch.Draw(rectangleTexture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
				}
			}
		}
	}
}
