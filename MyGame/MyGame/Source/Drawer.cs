using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
	class Drawer
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

        #region ctor
        public Drawer(Texture2D texture, Vector2 position, Color color, Vector2 scale)
        {
            this.texture = texture;
            this.position = position;
            this.color = color;
            this.scale = scale;
        }

		public Drawer(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth) : this(texture, position, color, scale)
		{
			
			this.sourceRectangle = new Rectangle((int)position.X, (int)this.position.Y, texture.Width, texture.Height);			
			this.rotation = rotation;
			this.origin = origin;		
			this.effects = effects;
			this.layerDepth = layerDepth;
            Game1.Drawed += Draw;
        }
        #endregion

        void Draw()
		{			
			G.spriteBatch.Draw(texture, position, sourceRectangle,color, rotation, origin, scale, effects, layerDepth);
		}
	}
}
