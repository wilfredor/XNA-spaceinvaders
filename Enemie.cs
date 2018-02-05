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

        public Enemie (SpaceInvaders Game, Vector2 Position) : base (Game)
		{
            this.Position = Position;
        }

		public override void Update (GameTime gameTime)
		{
            Position = Common.SpaceInvadersMovement(gameTime, Position, ref _directionX, LimitWidth, LimitHeight);
            //New level and new strong Enemi level too            
        }

		protected override void LoadContent ()
		{
			base.LoadContent ();
			SpriteBatch = new SpriteBatch (Game.GraphicsDevice);
		}

        public void SetTexture(String textureName = "enemie0")
        {
            //You will find more textures here http://millionthvector.blogspot.ca/2013/07/free-alien-top-down-spaceship-sprites.html                           
            Texture = Game.Content.Load<Texture2D>(Constant.EnemiesPath + textureName);
        }

        public void SetLive()
        {
            Lives = GameInfo.Level;
        }

		public override void Initialize ()
		{
			base.Initialize ();

            SetTexture();
            
			Velocity = new Vector2 (1, 1);
			Width = Texture.Width;
			Height = Texture.Height;

            LimitHeight = GameInfo.Height - (Texture.Height);
			LimitWidth = GameInfo.Width - (Texture.Width);

            _directionX = 1;
            SetLive();

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

