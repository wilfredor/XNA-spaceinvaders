using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders
{
    public class Package : GameObject
    {
        int originX;
        int originY;
        int directionX;
        int lifeTime = 0;
        public string TextureName;
        private Random rnd;
        public Boolean Delete { get; set; }

        public Package(SpaceInvaders game, int originX, int originY) : base(game)
        {            
            Game = game;
            this.originX = originX;
            this.originY = originY;
            rnd = new Random();
            //should only ever be one player, all value defaults set in Initialize()
        }

        public Package(SpaceInvaders game) : base(game)
        {
            rnd = new Random();
            originX = rnd.Next(200, 600);
            originY = rnd.Next(200, 300);
            Game = game;
        }

        private void CircularMovement(GameTime gameTime)
        {
            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            float speed = 3;
            float radius = 50;
            //Center origin position x,y
            if ((originX == LimitWidth) || (originX == 0))
            {
                directionX *= -4;
            }

            originX = originX + directionX;

            Vector2 origin = new Vector2(originX, 0);

            Position.X = (float)(Math.Cos(time * speed) * radius + origin.X)/2;
            Position.Y = (float)(Math.Sin(time * speed) * radius + origin.Y)*2;

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
            Position.Y = (Texture.Width + Texture.Width / 2);
            Position.X = Game.GraphicsDevice.Viewport.Width / 2 - Texture.Width;
            LimitHeight = Game.GraphicsDevice.Viewport.Height - (Texture.Height);
            LimitWidth = Game.GraphicsDevice.Viewport.Width - (Texture.Width);
 
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

