using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Linq;
using System.Collections.Generic;

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

        private Explosion DestroyEnemie(IGameComponent enemie)
        {
            Game.Components.Remove((IGameComponent)enemie);
            GameInfo.Score+= GameInfo.Level;
            return new Explosion(Game, new Vector2(Position.X, Position.Y - Texture.Height), GameInfo.Level);
        }

		public override void Update (GameTime gameTime)
		{
            List<Enemie> listEnemie = Collision.CheckCollision<Enemie>(Position, Game);//,true);

            Delete = (listEnemie.Count > 0);

            if (Delete)
            {
                Game.Components.Add(BulletExplosion());
                //Remove Lives
                listEnemie.ForEach(x => x.Lives-=1);
                //Remove the Enemie from the game if Live <=0
                listEnemie.Where(e => (e.Lives <= 0)).ToList().ForEach(x => Game.Components.Add(DestroyEnemie(x)));

                DestroyMe();

            }
            else if (Common.IsBulletOutOfRange(this))
            {
                _velocity.Y+=0.3f; 
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
			Texture = Game.Content.Load<Texture2D> (Constant.BulletsPath + "bullet"); 
			_velocity = new Vector2 (0.1f, 0.1f);            
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

