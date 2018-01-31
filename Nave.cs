using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class Nave: GameObject
    {

        public int numShotsFromCurrentMagazine = 2;
		float frequenceShotSpeed = 0.1f;
		float timeSinceLastShot = 0f;

		public Nave (SpaceInvaders game) : base (game)
		{
		}

		private void Shoot(){
			
			if (timeSinceLastShot > frequenceShotSpeed) {
				this.Game.Components.Add (
					new Bullet (
						ref GameN,
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
            
            //Check collision            
            if (Collision.CheckCollision<Enemie>(Position, Game,true))
            {
                Game.Components.Add(
                   new Explosion(
                       ref GameN,
                       new Vector2(Position.X, Position.Y - Texture.Height)
                   ));
                GameN.Lives--;

                GameN.Components.Remove(this);
                
            }

			timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
			
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

            InitialPosition();
		}

        public void InitialPosition()
        {
            Velocity = new Vector2(5, 5);
            Width = Texture.Width;
            Height = Texture.Height;
            Position.Y = Game.GraphicsDevice.Viewport.Height - (Texture.Width + Texture.Width / 2);
            Position.X = Game.GraphicsDevice.Viewport.Width / 2 - Texture.Width;
            LimitHeight = Game.GraphicsDevice.Viewport.Height - (Texture.Height);
            LimitWidth = Game.GraphicsDevice.Viewport.Width - (Texture.Width);

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

