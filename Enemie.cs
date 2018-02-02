using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class Enemie : GameObject
    {		
		private int _directionX;
        public Vector2 _position4;

        public Enemie (SpaceInvaders game, Vector2 enemiePosition) : base (game)
		{
            _position4 = enemiePosition;
        }

        private Boolean IsBorderX(int positionX, int limitWidth)
        {
            return (positionX >= limitWidth) || (positionX <= 0);
        }

        private Boolean IsBorderY(int positionY, int limitHeight)
        {
            return (positionY >= limitHeight);
        }

        private Vector2 SpaceInvadersMovement(GameTime gameTime, float X, float Y, int limitX, int limitY) {

            Random rnd = new Random();
            
            Vector2 _position = new Vector2(X, Y);

            float time = (float)gameTime.TotalGameTime.TotalSeconds;
                       
            //Center origin position x,y
            if (IsBorderY((int)_position.Y, limitY))
            {
                _position.Y = 0;
            }

            if (IsBorderX((int)_position.X, limitX))
            {
                //Change movement to back (-1) or forward (1) if the Enemi is in the border X
                _directionX *= -1;
            }

            _position.Y += 0.1f;

            Vector2 _position2 = new Vector2(_position.X + _directionX, _position.Y);


            return new Vector2(
                 _position2.X,
                (float)(Math.Sin(time * 5) * 10 + _position2.Y)
               
            );
        }

		public override void Update (GameTime gameTime)
		{
            Vector2 tempPosition = SpaceInvadersMovement(gameTime, Position.X, Position.Y, LimitWidth, LimitHeight);
            Position.X = tempPosition.X;
            Position.Y = tempPosition.Y;



        }

		protected override void LoadContent ()
		{
			base.LoadContent ();

			SpriteBatch = new SpriteBatch (Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

            Texture = Game.Content.Load<Texture2D> ("enemie0"); 
			Velocity = new Vector2 (1, 1);
			Width = Texture.Width;
			Height = Texture.Height;

            Position = new Vector2(
                GameInfo.Width / 2 - Texture.Width,
                (Texture.Width + Texture.Width / 2)
            );

            LimitHeight = GameInfo.Height - (Texture.Height);
			LimitWidth = GameInfo.Width - (Texture.Width);

            _directionX = 1;

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

