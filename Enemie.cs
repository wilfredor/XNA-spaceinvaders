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
      

        public Enemie (SpaceInvaders game, Vector2 enemiePosition) : base (game)
		{
            Position = enemiePosition;
        }

		public override void Update (GameTime gameTime)
		{
            Position = Common.SpaceInvadersMovement(gameTime, Position, ref _directionX, LimitWidth, LimitHeight);

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

            LimitHeight = GameInfo.Height - (Texture.Height);
			LimitWidth = GameInfo.Width - (Texture.Width);

            _directionX = 1;

        }

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			SpriteBatch.Begin ();

			    SpriteBatch.Draw (Texture,Position, Color.White);

			SpriteBatch.End ();
		}
	}
}

