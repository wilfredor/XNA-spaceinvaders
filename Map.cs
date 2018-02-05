using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SpaceInvaders
{
    class Map : DrawableGameComponent
    {
        public Vector2 position = Vector2.Zero;

        Vector2 velocity = Vector2.One;
        private Texture2D map;
        SpriteBatch spriteBatch;

        SpaceInvaders game;

        Color backgroundColor;

        private int _oldLevel;
        private int _alphaFactor;
        

        public Map(SpaceInvaders game1) : base(game1)
        {
            
            this.game = game1;

            //should only ever be one player, all value defaults set in Initialize()
        }


        public override void Update(GameTime gameTime)
        {

            if (((position.Y >= -(map.Height-GameInfo.Height))))
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
            
            map = Game.Content.Load<Texture2D>(Constant.MapsPath + "map001");
            velocity = new Vector2(5, 5);
            position = new Vector2(0, 0);


            _oldLevel = GameInfo.Level;

            _alphaFactor = -1;

            backgroundColor = Color.White;

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin();

            if (GameInfo.Level % 10 ==0) //repete the map color each 10 game levels
            {
                _alphaFactor *= -1;
            }
          

            if (_oldLevel != GameInfo.Level)
            {
                backgroundColor = Tool.ChangeColorBrightness(backgroundColor, 0.2f*_alphaFactor);
                GraphicsDevice.Clear(backgroundColor);                
                _oldLevel = GameInfo.Level;
            }

            if (GameInfo.Level == 5)
            {
                map = Game.Content.Load<Texture2D>(Constant.MapsPath + "map002");
            }
                       
            spriteBatch.Draw(map, position, backgroundColor);
            spriteBatch.End();
        }
    }
}

