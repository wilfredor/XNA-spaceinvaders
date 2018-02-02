using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Linq;
namespace SpaceInvaders
{
	public class Bullet : DrawableGameComponent
	{
        
        public Texture2D Texture { get; set; }
        public Boolean Delete { get; set; }

        public Vector2 Position;
        private Vector2 _navePosition = Vector2.Zero;
		private Vector2 _velocity = Vector2.One;		
		private SpriteBatch spriteBatch;

        public Bullet (Game game, Vector2 positionNave) : base (game)
		{
			_navePosition = positionNave;
            //should only ever be one player, all value defaults set in Initialize()
        }

        private Explosion BulletExplosion() {
            return new Explosion(Game,new Vector2(Position.X, Position.Y - Texture.Height));
        }

        private void DestroyMe()
        {
            Game.Components.Remove(this);
        }

		public override void Update (GameTime gameTime)
		{			
			Delete = Collision.CheckCollision<Enemie>(Position, Game,true);

            if (Delete)
            {
                Game.Components.Add(BulletExplosion());
                GameInfo.Score++;
                DestroyMe();
            }
            else if (Common.IsBulletOutOfRange(this))
            {
                Position.Y -= _velocity.Y;
            }
            else
            {
                DestroyMe();
            }

            base.Update(gameTime);
            
		}

		private void SetInitPosition (Vector2 positionNave)
		{
            Position.Y = positionNave.Y;
            Position.X = positionNave.X;
		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			spriteBatch = new SpriteBatch (Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();
            Position = Vector2.Zero;
            Delete = false;
			Texture = Game.Content.Load<Texture2D> ("bullet"); 
			_velocity = new Vector2 (10, 10);            
            SetInitPosition (_navePosition);
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);
			spriteBatch.Begin ();
			spriteBatch.Draw (Texture, Position, Color.White);
			spriteBatch.End ();
		}
	}
}

