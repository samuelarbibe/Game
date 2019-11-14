using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
	static class G
	{
		public static SpriteBatch spriteBatch;

		public static void init(GraphicsDevice graphicsDevice)
		{
			spriteBatch = new SpriteBatch(graphicsDevice);
		}


	}
}
