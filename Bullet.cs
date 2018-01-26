using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Linq;
namespace SpaceInvaders
{
	class Bullet : DrawableGameComponent
	{
		public Vector2 position = Vector2.Zero;
		Vector2 navePosition = Vector2.Zero;
		Vector2 velocity = Vector2.One;
		private Texture2D bullet; 
		SpriteBatch spriteBatch;
		public Boolean delete;
        Game1 game;



        public Bullet (ref Game1 game,Vector2 positionNave) : base (game)
		{
			navePosition = positionNave;
            this.game = game;

            //should only ever be one player, all value defaults set in Initialize()
        }


		public override void Update (GameTime gameTime)
		{
			
			delete = Collision.checkCollision (position, Game);


            if (delete)
            {
                Game.Components.Add(
                    new Explosion(
                        ref this.game,
                        new Vector2(position.X, position.Y - bullet.Height)
                    ));
                game.score++;
                Game.Components.Remove(this);
            }
            else
            {
                if (((position.Y >= -bullet.Height)))
                    position.Y -= velocity.Y;
                else
                {
                    //delete = true;
                    Game.Components.Remove(this);

                }
                base.Update(gameTime);
            }
		}

		private void SetInitPosition (Vector2 positionNave)
		{
			
			position.Y = positionNave.Y;
			position.X = positionNave.X;
		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			spriteBatch = new SpriteBatch (this.Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

			delete = false;
			bullet = Game.Content.Load<Texture2D> ("bullet"); 
			velocity = new Vector2 (10, 10);
			this.SetInitPosition (navePosition);
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);
			spriteBatch.Begin ();
			spriteBatch.Draw (bullet, position, Color.White);
			spriteBatch.End ();
		}
	}
}

