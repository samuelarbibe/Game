using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyGame.Source;

namespace MyGame
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	class Game1 : Game
	{
		public static event UpdateEventHandler Updated;
        public static event DrawEventHandler Drawed;

        readonly GraphicsDeviceManager graphics;
        List<IFocus> cars;
        Drawer background;
        Camera cam;

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

            cars = new List<IFocus>();

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

            cars.Add(new MovableObject(
                    new UserKeys(Keys.W, Keys.S, Keys.A, Keys.D),
                    carTexture,
                    new Vector2(0.5f, 0.5f),
                    null,
                    Color.White,
                    0,
                    new Vector2(carTexture.Width / 4f, carTexture.Height / 2f),
                    new Vector2(0.07f, 0.05f),
                    SpriteEffects.None,
                    0,
                    0));

            cars.Add(new MovableObject(
                    new BotKeys(cars[0]),
                    carTexture,
                    new Vector2(0.5f, 0.5f),
                    null,
                    Color.White,
                    0,
                    new Vector2(carTexture.Width / 4f, carTexture.Height / 2f),
                    new Vector2(0.07f, 0.05f),
                    SpriteEffects.None,
                    0,
                    0));

            cam = new Camera(new Viewport(0, 0, windowWidth, windowHeight), cars, Vector2.Zero, 1f);
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
                null, null, null, null, cam.GetMatrix());

            Drawed?.Invoke();

			G.spriteBatch.End();
		}

	}
}
