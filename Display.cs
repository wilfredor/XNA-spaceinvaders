using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace SpaceInvaders
{
    
    public class Display: Microsoft.Xna.Framework.DrawableGameComponent
	{
		
		SpriteBatch spriteBatch;
		SpriteFont Font1;
		Game1 game;

        StringBuilder infoLabel;

        public Display (Game1 game1) : base (game1)
		{
			this.game = game1;

			 
			//should only ever be one player, all value defaults set in Initialize()
		}



		public override void Update (GameTime gameTime)
		{


		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			spriteBatch = new SpriteBatch (this.Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

			spriteBatch = new SpriteBatch(GraphicsDevice);

			Font1 = Game.Content.Load<SpriteFont>("Font");
            

            // TODO: Load your game content here            

        }

		public override void Draw (GameTime gameTime)
		{
            infoLabel = new StringBuilder();
            infoLabel.Append(Constant.scoreLabel).Append(": ").Append(game.score.ToString()).Append("   ");
            infoLabel.Append(Constant.levelLabel).Append(": ").Append(game.level.ToString()).Append("   ");
            infoLabel.Append(Constant.livesLabel).Append(": ").Append(game.nave.lives.ToString()).Append("   ");
            infoLabel.Append(Constant.shotsLabel).Append(": ").Append(game.nave.numShotsFromCurrentMagazine.ToString ());
            

            base.Draw (gameTime);

			spriteBatch.Begin();
			spriteBatch.DrawString(Font1,
                                    infoLabel, 
				                   new Vector2(
					                           Game.GraphicsDevice.Viewport.Width /1.3f  
											   - Font1.MeasureString(infoLabel).Length() / 2.5f, 0
				                              ), 
				                   Color.White, 
				                   0, 
				                   new Vector2(0, Font1.MeasureString(infoLabel).Length() / Game.GraphicsDevice.Viewport.Height), 
				                   0.8f, 
				                   SpriteEffects.None, 
				                   0f);
			spriteBatch.End();
		}
	}
}

