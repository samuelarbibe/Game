using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public delegate void UpdateEventHandler();
    public delegate void DrawEventHandler();

    static class G
	{
		public static SpriteBatch spriteBatch;
        public static KeyboardState keyboardState;

		public static void init(GraphicsDevice graphicsDevice)
		{
			spriteBatch = new SpriteBatch(graphicsDevice);
            Game1.Updated += Update;
		}

        public static void Update()
        {
            keyboardState = Keyboard.GetState();
        }
	}
}
