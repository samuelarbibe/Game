using System;
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
	public class Drawer
	{
		protected Texture2D texture;
		protected Rectangle? sourceRectangle;
		public Vector2 position;
		protected Color color;
		public float rotation;
		protected Vector2 origin;
		protected Vector2 scale;
		protected SpriteEffects effects;
		protected float layerDepth;


		public Drawer(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			this.texture = texture;
			this.position = position;
			this.sourceRectangle = sourceRectangle;
			this.color = color;
			this.rotation = rotation;
			this.origin = origin;
			this.scale = scale;
			this.effects = effects;
			this.layerDepth = layerDepth;
		}

		public void Draw()
		{
			G.spriteBatch.Draw(texture, position, sourceRectangle,color, rotation, origin, scale, effects, layerDepth);
		}
	}
}
