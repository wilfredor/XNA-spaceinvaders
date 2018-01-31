using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class GameObject : DrawableGameComponent, IGameObject
    {
        public Vector2 Position;        
        public Vector2 Velocity;        
        public SpaceInvaders GameN;
        public Texture2D Texture;
        public SpriteBatch SpriteBatch;

        public int LimitHeight { get; set; }
        public int LimitWidth { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }

        public GameObject(SpaceInvaders game) : base (game)
		{
            GameN = game;
            Position = Vector2.Zero;
            Velocity = Vector2.One;
        }

        public GraphicObject ToGraphicObject()
        {
            return new GraphicObject()
            {
                Y = Position.Y,
                X = Position.X,
                Width = Width,
                Height = Height,
            };
        }
    }
}
