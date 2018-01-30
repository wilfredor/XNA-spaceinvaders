using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class GameObject : DrawableGameComponent, IGameObject
    {
        public Vector2 Position;        
        public Vector2 Velocity;        
        public SpaceInvaders Game;
        public Texture2D Texture;
        public SpriteBatch SpriteBatch;

        public int LimitHeight { get; set; }
        public int LimitWidth { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }

        public GameObject(SpaceInvaders game) : base (game)
		{
            Game = game;
            Position = Vector2.Zero;
            Velocity = Vector2.One;
        }
    }
}
