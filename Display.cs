using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace SpaceInvaders
{
    
    public class Display: DrawableGameComponent
	{
		
		SpriteBatch spriteBatch;
		SpriteFont Font1;
        SpaceInvaders Game;

        StringBuilder infoLabel;

        public Display (SpaceInvaders game) : base (game)
		{
			Game = game;

			 
			//should only ever be one player, all value defaults set in Initialize()
		}



		public override void Update (GameTime gameTime)
		{


		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			spriteBatch = new SpriteBatch (Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

			spriteBatch = new SpriteBatch(GraphicsDevice);

			Font1 = Game.Content.Load<SpriteFont>("Fonts/INVASION2000");
            

            // TODO: Load your game content here            

        }

		public override void Draw (GameTime gameTime)
		{
            infoLabel = new StringBuilder();
            infoLabel.Append(Constant.scoreLabel).Append(": ").Append(Game.Score.ToString()).Append("   ");
            infoLabel.Append(Constant.levelLabel).Append(": ").Append(Game.Level.ToString()).Append("   ");
            infoLabel.Append(Constant.livesLabel).Append(": ").Append(Game.Lives.ToString()).Append("   ");
            infoLabel.Append(Constant.shotsLabel).Append(": ").Append(Game.nave.numShotsFromCurrentMagazine.ToString ());
            

            base.Draw (gameTime);

			spriteBatch.Begin();
			spriteBatch.DrawString(Font1,
                                    infoLabel, 
				                   new Vector2(
					                           Game.GraphicsDevice.Viewport.Width /1.8f  
											   - Font1.MeasureString(infoLabel).Length() / 2.5f, 0
				                              ), 
				                   Color.White, 
				                   0, 
				                   new Vector2(0, Font1.MeasureString(infoLabel).Length() / Game.GraphicsDevice.Viewport.Height), 
				                   1.3f, 
				                   SpriteEffects.None, 
				                   0f);
			spriteBatch.End();
		}
	}
}

