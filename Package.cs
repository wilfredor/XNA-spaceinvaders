using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class Package : GameObject
    {
        private int _directionX;
        int lifeTime = 0;
        public string TextureName;
        private Random rnd;
        public Boolean Delete { get; set; }

        private Vector2 _positionPackage;

        public Package(SpaceInvaders game, Vector2 positionPackage) : base(game)
        {
            _positionPackage = positionPackage;
            rnd = new Random();
            //should only ever be one player, all value defaults set in Initialize()
        }

        public Package(SpaceInvaders game) : base(game)
        {
            
            rnd = new Random();
            _positionPackage = new Vector2(rnd.Next(200, 600), rnd.Next(200, 300));
        }

        public virtual void ApplyRule()
        {

        }    
        public override void Update(GameTime gameTime)
        {

            lifeTime++;

            if (lifeTime == Constant.LivePackageTime)
            {
                Game.Components.Remove(this);
                Delete = true;
             
            }
                          
            if (Collision.CheckCollision<Nave>(Position, Game).Count>0)
            {
                ApplyRule();
                Game.Components.Remove(this);
                Delete = true;
            }

            Position = Common.CircularMovement(gameTime, _positionPackage, ref _directionX, LimitWidth, LimitHeight);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            SpriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
        }

        public override void Initialize()
        {
            base.Initialize();

            Texture = Game.Content.Load<Texture2D>(TextureName);
            Velocity = new Vector2(1, 1);
            Width = Texture.Width;
            Height = Texture.Height;
                    
            LimitHeight = GameInfo.Height - (Texture.Height);
            LimitWidth = GameInfo.Width - (Texture.Width);
 
            _directionX = 1;
            lifeTime = 0;

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            SpriteBatch.Begin();

                SpriteBatch.Draw(Texture, Position, Color.White);

            SpriteBatch.End();
        }
    }
}

