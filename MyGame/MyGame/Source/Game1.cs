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
		public event EventHandler Updated;

		GraphicsDeviceManager graphics;
		MovableObject car;
		public static int windowWidth;
		public static int windowHeight;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			windowWidth = graphics.PreferredBackBufferWidth;
			windowHeight = graphics.PreferredBackBufferHeight;

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			G.init(GraphicsDevice);

			//TODO: use this.Content to load your game content here

			Texture2D carTexture = Content.Load<Texture2D>("car_image");

			//texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth
			car = new MovableObject(carTexture, new Vector2(0.5f, 0.5f), null, Color.White, 0, new Vector2(carTexture.Width / 4f, carTexture.Height / 2f), new Vector2(0.1f, 0.07f), SpriteEffects.None, 0, 5, 0);

			Updated += car.Update;
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// TODO: Add your update logic here

			KeyboardState state = Keyboard.GetState();

			if (state.IsKeyDown(Keys.Up)) // increase spped
			{
				car.speed += 0.15F;
			}
			else if (state.IsKeyDown(Keys.Down)) // decrease speed
			{
				car.speed -= 0.15F;
			}

			if (state.IsKeyDown(Keys.Right))// rotate right
			{
				car.rotation += 0.04F; // increase rotation by 2 degrees
			}
			else if (state.IsKeyDown(Keys.Left))
			{ // rotate left

				car.rotation -= 0.04F; // increase rotation by 2 degrees
			}

			Updated(this, EventArgs.Empty);

			//car.Update();

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			//if (FPS++ % 5 == 0) return; // slow down

			graphics.GraphicsDevice.Clear(Color.WhiteSmoke);
			G.spriteBatch.Begin();

			car.Draw();

			G.spriteBatch.End();
		}

	}
}
