using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class Enemie : GameObject
    {		
		int directionX;
        int directionY;
        private Vector2 _enemiePosition;

        public Enemie (SpaceInvaders game, Vector2 enemiePosition) : base (game)
		{
            _enemiePosition = enemiePosition;
            //should only ever be one player, all value defaults set in Initialize()
        }

        private void GetOriginPosition()
        {
            int stepY = 0;
            //Center origin position x,y
            if ((_enemiePosition.Y >= LimitHeight))
            {
                //directionY *= -1;
                _enemiePosition.Y = 0;
            }
            
            if ((_enemiePosition.X >= LimitWidth) || (_enemiePosition.X <= 0)) 
            {
                directionX *= -1;
                stepY = 50;
            }

            _enemiePosition = new Vector2(_enemiePosition.X + directionX, _enemiePosition.Y + stepY* directionY);

            stepY = 0;

        }
        private void SpaceInvadersMovement(GameTime gameTime) {

            Random rnd = new Random();
            int move = rnd.Next(8, 9); // speed

            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            float speed = move;
            float radius = 10;

            //Center origin position x,y
            GetOriginPosition();


            Position = new Vector2(
                 _enemiePosition.X,
                (float)(Math.Sin(time * speed) * radius + _enemiePosition.Y)
               
            );
        }

		public override void Update (GameTime gameTime)
		{			
			SpaceInvadersMovement (gameTime);
		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			SpriteBatch = new SpriteBatch (this.Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

            Texture = Game.Content.Load<Texture2D> ("enemie0"); 
			Velocity = new Vector2 (1, 1);
			Width = Texture.Width;
			Height = Texture.Height;

            Position = new Vector2(
                Game.GraphicsDevice.Viewport.Width / 2 - Texture.Width,
                (Texture.Width + Texture.Width / 2)                
            );

            LimitHeight = Game.GraphicsDevice.Viewport.Height - (Texture.Height);
			LimitWidth = Game.GraphicsDevice.Viewport.Width - (Texture.Width);

            directionX = 1;
            directionY = 1;

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

