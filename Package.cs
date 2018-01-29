using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders
{
    public class Package : DrawableGameComponent
    {
        public Vector2 position = Vector2.Zero;
        Vector2 velocity = Vector2.One;
        private Texture2D package;
        public SpaceInvaders game;
        int originX;
        int originY;
        public int Width;
        public int Height;
        int directionX;
        SpriteBatch spriteBatch;
        int limitHeight;
        int limitWidth;
        int numberOfTicks = 0;
        int lifeTime = 0;
        private SpaceInvaders game1;
        public string Texture { get; set; }

        public Boolean Delete { get; set; }

        public Package(SpaceInvaders game1, int originX, int originY) : base(game1)
        {            
            game = game1;
            this.originX = originX;
            this.originY = originY;
            //should only ever be one player, all value defaults set in Initialize()
        }

       

        private void CircularMovement(GameTime gameTime)
        {
            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            float speed = 3;
            float radius = 50;
            //Center origin position x,y
            if ((originX == limitWidth) || (originX == 0))
            {
                directionX *= -4;
            }

            originX = originX + directionX;

            Vector2 origin = new Vector2(originX, 0);

            position.X = (float)(Math.Cos(time * speed) * radius + origin.X)/2;
            position.Y = (float)(Math.Sin(time * speed) * radius + origin.Y)*2;

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
                          
            if (Collision.CheckCollision<Nave>(position, Game))
            {
                ApplyRule();
                Game.Components.Remove(this);
                Delete = true;
            }
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
        }

        public override void Initialize()
        {
            base.Initialize();

            package = Game.Content.Load<Texture2D>(Texture);
            velocity = new Vector2(0.1f, 0.1f);
            Width = package.Width;
            Height = package.Height;
            position.Y = (package.Width + package.Width / 2);
            position.X = Game.GraphicsDevice.Viewport.Width / 2 - package.Width;
            limitHeight = Game.GraphicsDevice.Viewport.Height - (package.Height);
            limitWidth = Game.GraphicsDevice.Viewport.Width - (package.Width);
 
            directionX = 1;

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            spriteBatch.Begin();

                spriteBatch.Draw(package, position, Color.White);

            spriteBatch.End();
        }
    }
}

