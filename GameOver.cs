using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace SpaceInvaders
{

    public class GameOver : DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        SpriteFont Font1;
        SpaceInvaders game;
        Color color;
        int Y;
        float fontSize;

        public GameOver(SpaceInvaders game1) : base(game1)
        {
            this.game = game1;
        }

        public override void Update(GameTime gameTime)
        {
            if (Y <= Game.GraphicsDevice.Viewport.Height / 2)
            {
                Y++;
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

            spriteBatch = new SpriteBatch(GraphicsDevice);

            Font1 = Game.Content.Load<SpriteFont>("Font");

           

            Y = Game.GraphicsDevice.Viewport.Height / 3;


            

            // TODO: Load your game content here            

        }

        public override void Draw(GameTime gameTime)
        {
            
            base.Draw(gameTime);

            spriteBatch.Begin();

            color = Tool.ChangeColorBrightness(Color.White, -255f);
            int j = 10;
            
            for (double i = (Game.GraphicsDevice.Viewport.Height / 2.2); i <=Y; i++)
            {
                
                spriteBatch.DrawString(Font1,
                    Constant.gameOverLabel,
                    new Vector2(
                                Game.GraphicsDevice.Viewport.Width
                                - Font1.MeasureString(Constant.gameOverLabel).Length(), (float)i
                                ),
                    color,
                    0,
                    new Vector2(Game.GraphicsDevice.Viewport.Height / 2, Font1.MeasureString(Constant.gameOverLabel).Length() / Game.GraphicsDevice.Viewport.Height),
                    1.5f,
                    SpriteEffects.None,
                    0f);
                color = Tool.ChangeColorBrightness(color, +0.0002f);
            }
            spriteBatch.End();
        }
    }
}

