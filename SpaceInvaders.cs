#region Using Statements

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System;
using System.Runtime.InteropServices;

#endregion

namespace SpaceInvaders
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    [ComVisibleAttribute(false)]
    public class SpaceInvaders : Game
    {

        GraphicsDeviceManager graphics;

        public Nave nave;

        private Random rnd;

        public SpaceInvaders()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = Constant.RootContentDirectory;	            
			graphics.IsFullScreen = false;
            
            // Create new renderer and set its graphics devide to "this" device                     
        }

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			// Nave image.
			
            //level map
            Components.Add(new Map(this));
            GameInfo.Level = 1;
            GameInfo.Score = 0;
            GameInfo.Lives = Constant.DefaultLivesQuantity;
            GameInfo.Shots = Constant.DefaultShootsQuantity;
            GameInfo.Height = GraphicsDevice.Viewport.Height;
            GameInfo.Width = GraphicsDevice.Viewport.Width;

            //Add a enemie 
            Components.Add (new Enemie (this, new Vector2( 10, 10) ));

            //Add ship
			Components.Add (nave = new Nave(this));

            //Label info 
			Components.Add (new Display(this));

            base.Initialize ();

            rnd = new Random();

        }

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch (GraphicsDevice);

            //TODO: use this.Content to load your game content here 

        }

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS

            //Next Level
            if (Components.OfType<Enemie>().Count().Equals(0))
            {
                GameInfo.Level++;
                for (int i = 0; i <= GameInfo.Level; i++)
                {
                    Components.Add(new Enemie(this, Collision.GetNoCollisionPlace(this,rnd)));
                }
            }

            Components.OfType<BulletPackage>().ToList().RemoveAll(x => x.Delete);
            Components.OfType<LivePackage>().ToList().RemoveAll(x => x.Delete);
            //Components.OfType<Enemie>().ToList().

            //win bullets
            if (Components.OfType<BulletPackage>().Count().Equals(0))
            {
                if (GameInfo.Shots == 0)
                {
                    Components.Add(new BulletPackage(this));
                }

            }

            //win a live
            if (Components.OfType<LivePackage>().Count().Equals(0))
            {
                if (GameInfo.Lives == 1)
                {
                    Components.Add(new LivePackage(this));
                }
            }

            //wake up
            if ((Components.OfType<Nave>().Count().Equals(0)) && GameInfo.Lives >0)
            {
                //Add ship
                Components.Add(new Nave(this));
            }
            else if (Components.OfType<Nave>().Count().Equals(0))
            {
                //gameover
                Components.Add(new GameOver(this));
            }

            #if !__IOS__
            if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			#endif

			// TODO: Add your update logic here			
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{

			graphics.GraphicsDevice.Clear (Color.Black);
            
			base.Draw (gameTime);

		}
	}
}

