using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class Display: DrawableGameComponent
	{
		
		SpriteBatch spriteBatch;
		SpriteFont Font;
        StringBuilder mainBarText;

        public Display (Game game) : base (game)
		{
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
			Font = Game.Content.Load<SpriteFont>("Fonts/INVASION2000");
            mainBarText = Constant.InfoBar();
        }

		public override void Draw (GameTime gameTime)
		{

            base.Draw (gameTime);

			spriteBatch.Begin();

            spriteBatch.DrawString(Font, mainBarText, new Vector2(0, Common.MainBarPosition(Font,mainBarText)), Color.White);

			spriteBatch.End();
		}
	}
}

