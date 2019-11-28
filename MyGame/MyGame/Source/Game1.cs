using System;

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
		MovableObject car;
        Drawer background;
        Camera cam;
        Song song;

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
            Texture2D backgroundTexture = Content.Load<Texture2D>("track_image");

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

            cam = new Camera(new Viewport(0, 0, windowWidth, windowHeight), car, Vector2.Zero, 0.5f);

            song = Content.Load<Song>("car_sound");

            MediaPlayer.Play(song);

            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);
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
