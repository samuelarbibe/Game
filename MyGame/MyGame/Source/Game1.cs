using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MyGame
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		public static event UpdateEventHandler Updated;
        public static event DrawEventHandler Drawed;

        readonly GraphicsDeviceManager graphics;
		MovableObject car;
        Drawer background;
        Matrix mat;

		public static int windowWidth;
		public static int windowHeight;
        

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

 
		protected override void Initialize()
		{

			graphics.PreferredBackBufferWidth = 1200;  // set this value to the desired width of your window
			graphics.PreferredBackBufferHeight = 675;   // set this value to the desired height of your window
			graphics.ApplyChanges();

			windowWidth = graphics.PreferredBackBufferWidth;
			windowHeight = graphics.PreferredBackBufferHeight;

			base.Initialize();
		}

 
		protected override void LoadContent()
		{
			G.init(GraphicsDevice);

			Texture2D carTexture = Content.Load<Texture2D>("car_image");
            Texture2D backgroundTexture = Content.Load<Texture2D>("track_image_2");

            //texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth, speed
            background = new Drawer(backgroundTexture,
                new Vector2(0, 0),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                new Vector2(1.3f, 1.3f),
                SpriteEffects.None,
                0);

            car = new MovableObject(carTexture,
                new Vector2(0.5f, 0.5f),
                null,
                Color.White,
                0,
                new Vector2(carTexture.Width / 4f, carTexture.Height / 2f),
                new Vector2(0.07f, 0.05f),
                SpriteEffects.None,
                0,
                5);
		}

 
		protected override void Update(GameTime gameTime)
		{
			Updated?.Invoke();

			base.Update(gameTime);
		}

 
		protected override void Draw(GameTime gameTime)
		{

			graphics.GraphicsDevice.Clear(Color.WhiteSmoke);
			G.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                null, null, null, null,
                Matrix.CreateTranslation(-car.position.X, -car.position.Y, 0)*
                Matrix.CreateRotationZ(-car.rotation - 1.6f)*
                Matrix.CreateScale(2f)*
                Matrix.CreateTranslation(windowWidth/2, windowHeight/4 * 3, 0)
                );

            

            Drawed?.Invoke();

			G.spriteBatch.End();
		}

	}
}
