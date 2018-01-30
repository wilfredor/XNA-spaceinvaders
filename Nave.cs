using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
	public class Nave: GameObject
    {

        public int numShotsFromCurrentMagazine = 2;
		float frequenceShotSpeed = 0.1f;
		float timeSinceLastShot = 0f;
		KeyboardState currentKBState;
		public int lives;


		public Nave (SpaceInvaders game) : base (game)
		{
		}

		private void Shoot(){
			
			if (timeSinceLastShot > frequenceShotSpeed) {
				this.Game.Components.Add (
					new Bullet (
						ref this.Game,
						new Vector2(Texture.Width/2+Position.X, Position.Y)
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
			Position.X = state.X;
			Position.Y = state.Y;

			// Check if Right Mouse Button pressed, if so, exit
			if ((state.LeftButton == ButtonState.Pressed)&&(numShotsFromCurrentMagazine>0))
				Shoot();
            else { timeSinceLastShot = 0f; }

			currentKBState = Keyboard.GetState ();

            //Check collision            
            if (Collision.CheckCollision<Enemie>(Position, Game,true))
            {
                Game.Components.Add(
                   new Explosion(
                       ref Game,
                       new Vector2(Position.X, Position.Y - Texture.Height)
                   ));
                lives--;
            }
            if (lives.Equals(0))
            {
                Game.Components.Remove(this);
            }
			//Movement
			if (currentKBState.IsKeyDown (Keys.Left)) {
				if (Position.X >= 0)
                    Position.X -= Velocity.X;
			} else if (currentKBState.IsKeyDown (Keys.Right)) {
				if (Position.X <= LimitWidth)
                    Position.X += Velocity.X;
			} else if (currentKBState.IsKeyDown (Keys.Up)) {
				if (Position.Y >= 0)
                    Position.Y -= Velocity.Y;
			} else if (currentKBState.IsKeyDown (Keys.Down)) {
				if (Position.Y <= LimitHeight)
                    Position.Y += Velocity.Y;
			}

			timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
			//Fire
			if (currentKBState.IsKeyDown (Keys.LeftControl))
				Shoot();
		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			SpriteBatch = new SpriteBatch (this.Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

            Texture = Game.Content.Load<Texture2D> ("nave");
            Velocity = new Vector2(5, 5);
            Width = Texture.Width;
            Height = Texture.Height;            
			Position.Y = Game.GraphicsDevice.Viewport.Height - (Texture.Width + Texture.Width / 2);
			Position.X = Game.GraphicsDevice.Viewport.Width / 2 - Texture.Width;
			LimitHeight = Game.GraphicsDevice.Viewport.Height - (Texture.Height);
			LimitWidth = Game.GraphicsDevice.Viewport.Width - (Texture.Width);

			lives = Constant.defaultLivesQuantity;
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			SpriteBatch.Begin ();

			SpriteBatch.Draw (Texture, Position, Color.White);

			SpriteBatch.End ();
		}
	}
}

