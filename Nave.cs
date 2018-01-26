using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
	public class Nave: DrawableGameComponent
	{
		public int numShotsFromCurrentMagazine = 2;
		float frequenceShotSpeed = 0.1f;
		float timeSinceLastShot = 0f;

		public Vector2 position = Vector2.Zero;
		Vector2 velocity = Vector2.One;
		private Texture2D nave;
		Game1 game;
		SpriteBatch spriteBatch;
		KeyboardState currentKBState;
        public int Width;
        public int Height;
        int limitHeight;
		int limitWidth;
		public int lives;


		public Nave (Game1 game1) : base (game1)
		{
			this.game = game1;

			//should only ever be one player, all value defaults set in Initialize()
		}

		private void Shoot(){
			
			if (timeSinceLastShot > frequenceShotSpeed) {
				this.game.Components.Add (
					new Bullet (
						ref this.game,
						new Vector2(nave.Width/2+position.X, position.Y)
					)
				);

				numShotsFromCurrentMagazine -= 1;
				timeSinceLastShot = 0f;

			}

			//no more bullets
			if(numShotsFromCurrentMagazine <= 0)
			{
				timeSinceLastShot = -8f;//since magazine is empty, set accumulator to -8 so it will be 10 seconds before it gets to the required 2 and initiate the next shot
				numShotsFromCurrentMagazine = 0;//reset the magazine.
			}
		}

		public override void Update (GameTime gameTime)
		{
			MouseState state = Mouse.GetState();

			// Update our sprites position to the current cursor 
			position.X = state.X;
			position.Y = state.Y;

			// Check if Right Mouse Button pressed, if so, exit
			if ((state.LeftButton == ButtonState.Pressed)&&(numShotsFromCurrentMagazine>0))
				Shoot();
            else { timeSinceLastShot = 0f; }

			currentKBState = Keyboard.GetState ();

            //Check collision
            if (Collision.CheckCollision<Enemie>(position, Game))
            {
                game.Components.Add(
                   new Explosion(
                       ref game,
                       new Vector2(position.X, position.Y - nave.Height)
                   ));
                lives--;
                
            }
            if (lives.Equals(0))
            {
                Game.Components.Remove(this);
            }
			//Movement
			if (currentKBState.IsKeyDown (Keys.Left)) {
				if (position.X >= 0)
					position.X -= velocity.X;
			} else if (currentKBState.IsKeyDown (Keys.Right)) {
				if (position.X <= limitWidth)
					position.X += velocity.X;
			} else if (currentKBState.IsKeyDown (Keys.Up)) {
				if (position.Y >= 0)
					position.Y -= velocity.Y;
			} else if (currentKBState.IsKeyDown (Keys.Down)) {
				if (position.Y <= limitHeight)
					position.Y += velocity.Y;
			}

			timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
			//Fire
			if (currentKBState.IsKeyDown (Keys.LeftControl))
				Shoot();
		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			spriteBatch = new SpriteBatch (this.Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

			nave = Game.Content.Load<Texture2D> ("nave");
            this.Width = nave.Width;
            this.Height = nave.Height;
            velocity = new Vector2 (5, 5);
			position.Y = Game.GraphicsDevice.Viewport.Height - (nave.Width + nave.Width / 2);
			position.X = Game.GraphicsDevice.Viewport.Width / 2 - nave.Width;

			limitHeight = game.GraphicsDevice.Viewport.Height - (nave.Height);
			limitWidth = game.GraphicsDevice.Viewport.Width - (nave.Width);

			lives = Constant.defaultLivesQuantity;
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			spriteBatch.Begin ();

			spriteBatch.Draw (nave, position, Color.White);

			spriteBatch.End ();
		}
	}
}

