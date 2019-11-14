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

		readonly GraphicsDeviceManager graphics;
		MovableObject car;
		public static int windowWidth;
		public static int windowHeight;


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

 
		protected override void Initialize()
		{

			graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
			graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
			graphics.ApplyChanges();

			windowWidth = graphics.PreferredBackBufferWidth;
			windowHeight = graphics.PreferredBackBufferHeight;

			Drawer.showRectangle = true;

			base.Initialize();
		}

 
		protected override void LoadContent()
		{
			G.init(GraphicsDevice);

			Texture2D carTexture = Content.Load<Texture2D>("car_image");

			//texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth, speed
			car = new MovableObject(carTexture, new Vector2(0.5f, 0.5f), null, Color.White, 0, new Vector2(carTexture.Width / 4f, carTexture.Height / 2f), new Vector2(0.07f, 0.05f), SpriteEffects.None, 0, 5);

			Updated += car.Update;
		}

 
		protected override void Update(GameTime gameTime)
		{

			KeyboardState state = Keyboard.GetState();

			if (state.IsKeyDown(Keys.Up)) // increase spped
			{
				car.speed += 0.15F;
			}

			if (car.speed > 1) // only turn and reduce speed if car is not standing still(or very close to standing still)
			{
				
				if (state.IsKeyDown(Keys.Down)) // decrease speed
				{
					car.speed -= 0.2F;
				}


				if (state.IsKeyDown(Keys.Right))// rotate right
				{
					car.rotation += 0.04F * car.speed / 10; // increase rotation by 2 degrees
				}
				else if (state.IsKeyDown(Keys.Left))
				{ // rotate left

					car.rotation -= 0.04F * car.speed / 10; // increase rotation by 2 degrees
				}
			}

			Updated(this, EventArgs.Empty);

			base.Update(gameTime);
		}

 
		protected override void Draw(GameTime gameTime)
		{

			graphics.GraphicsDevice.Clear(Color.WhiteSmoke);
			G.spriteBatch.Begin();

			car.Draw();

			G.spriteBatch.End();
		}

	}
}
