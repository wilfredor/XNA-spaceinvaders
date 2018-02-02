using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class Package : GameObject
    {
        int directionX;
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

        private void CircularMovement(GameTime gameTime)
        {
            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            float speed = 3;
            float radius = 50;
            //Center origin position x,y
            if ((_positionPackage.X == LimitWidth) || (_positionPackage.X == 0))
            {
                directionX *= -4;
            }

            _positionPackage = new Vector2(_positionPackage.X + directionX,0);

            Position = new Vector2(
                (float)(Math.Cos(time * speed) * radius + _positionPackage.X) / 2,
                (float)(Math.Sin(time * speed) * radius + _positionPackage.Y) * 2
            );
        }

        public virtual void ApplyRule()
        {

        }    
        public override void Update(GameTime gameTime)
        {

            CircularMovement(gameTime);

            lifeTime++;

            if (lifeTime == 2000)
            {
                Game.Components.Remove(this);
                Delete = true;
             
            }
                          
            if (Collision.CheckCollision<Nave>(Position, Game))
            {
                ApplyRule();
                Game.Components.Remove(this);
                Delete = true;
            }
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
            Velocity = new Vector2(0.1f, 0.1f);
            Width = Texture.Width;
            Height = Texture.Height;

            Position = new Vector2(
                (Texture.Width + Texture.Width / 2),
                Game.GraphicsDevice.Viewport.Width / 2 - Texture.Width
            );
           
            LimitHeight = GameInfo.Height - (Texture.Height);
            LimitWidth = GameInfo.Width - (Texture.Width);
 
            directionX = 1;

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

