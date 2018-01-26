using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Linq;
namespace SpaceInvaders
{
    class Map : DrawableGameComponent
    {
        public Vector2 position = Vector2.Zero;

        Vector2 velocity = Vector2.One;
        private Texture2D map;
        SpriteBatch spriteBatch;
  
        Game1 game;

        Color backgroundColor;

        private int oldLevel;

        public Map(Game1 game1) : base(game1)
        {
            
            this.game = game1;

            //should only ever be one player, all value defaults set in Initialize()
        }


        public override void Update(GameTime gameTime)
        {

            if (((position.Y >= -(map.Height-Game.GraphicsDevice.Viewport.Height))))
                position.Y -= velocity.Y;
            else
            {
                position = new Vector2(0, 0);

            }
            base.Update(gameTime);
            
        }
    

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
        }

        public override void Initialize()
        {
            base.Initialize();
            
            map = Game.Content.Load<Texture2D>("mars001");
            velocity = new Vector2(5, 5);
            position = new Vector2(0, 0);


            oldLevel = game.level;

            backgroundColor = Color.White;

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin();
            if (oldLevel != game.level)
            {
                backgroundColor = Tool.ChangeColorBrightness(backgroundColor, -0.5f);
                GraphicsDevice.Clear(backgroundColor);                
                oldLevel = game.level;
            }
                       
            spriteBatch.Draw(map, position, backgroundColor);
            spriteBatch.End();
        }
    }
}

