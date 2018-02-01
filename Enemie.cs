using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class Enemie : GameObject
    {
        int originX;
		int originY;		
		int directionX;

		public Enemie (SpaceInvaders game,int originX,int originY) : base (game)
		{
			this.originX = originX;
			this.originY = originY;
			//should only ever be one player, all value defaults set in Initialize()
		}

		private void Circular(GameTime gameTime){

			Random rnd = new Random();

			int move = rnd.Next(8, 9);

			float time = (float)gameTime.TotalGameTime.TotalSeconds; 
			float speed = move;
			float radius = 100;
            //Center origin position x,y
            if ((originX == LimitWidth) || (originX == 0))
            {
                directionX *= -1;
            }

			originX=originX+directionX;

			Vector2 origin = new Vector2(originX,0);

			Position.X = (float)(Math.Cos(time * speed) * radius + origin.X);
			Position.Y = (float)(Math.Sin(time*speed) * radius + origin.Y);
			
		}

        private void SpaceInvadersMovement(GameTime gameTime) {

            Random rnd = new Random();
            int move = rnd.Next(8, 9); // speed

            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            float speed = move;
            float radius = 10;

            if ((originX == LimitWidth) || (originX == 0)) {
                directionX *= -1;
                originY += 50;
            }
            originX += directionX;
            //Center origin position x,y
            Vector2 origin = new Vector2(originX, originY);
            Position.Y = (float)(Math.Sin(time * speed) * radius + origin.Y);
            Position.X = originX;
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
			Position.Y = (Texture.Width + Texture.Width / 2);
			Position.X = Game.GraphicsDevice.Viewport.Width / 2 - Texture.Width;			
			LimitHeight = Game.GraphicsDevice.Viewport.Height - (Texture.Height);
			LimitWidth = Game.GraphicsDevice.Viewport.Width - (Texture.Width);

            directionX = 1;

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

