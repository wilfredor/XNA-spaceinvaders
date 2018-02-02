using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class GameOver : DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        SpriteFont Font1;
        SpaceInvaders game;
        Color color;
        int Y;
        float alpha;
        Boolean rewrite;
        public GameOver(SpaceInvaders game1) : base(game1)
        {
            this.game = game1;
        }

        public override void Update(GameTime gameTime)
        {
            if (Y <= GameInfo.Height/ 2)
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

            Font1 = Game.Content.Load<SpriteFont>("Fonts/ARCADECLASSIC");

           

            Y = GameInfo.Height / 3;

            color = Color.White;
            alpha = 0.5f;
            rewrite = true;

            // TODO: Load your game content here            

        }

        public override void Draw(GameTime gameTime)
        {
            
            base.Draw(gameTime);
            if (rewrite)
            {
                spriteBatch.Begin();


                double i = (GameInfo.Height / 2.2);
                              
                spriteBatch.DrawString(Font1,
                    Constant.GameOverLabel,
                    new Vector2(
                                Game.GraphicsDevice.Viewport.Width
                                - Font1.MeasureString(Constant.GameOverLabel).Length(), (float)i
                                ),
                    color,
                    0,
                    new Vector2(GameInfo.Height / 3f, Font1.MeasureString(Constant.GameOverLabel).Length() / GameInfo.Height),
                    3f,
                    SpriteEffects.None,
                    0f);
                color = new Color(color, alpha);
    
                spriteBatch.End();
            }
           
            rewrite = false;
        }
    }
}

