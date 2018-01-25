using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Particle
    {
        public Vector2 position;
        public Vector2 direction = Vector2.Zero;
        Vector2 velocity = Vector2.One;

        public Texture2D Rect { get; set; }
        Color color = Color.White; 
        public Color[] data;

        public Boolean delete;

        public int viewportHeight;

        float oldX;
        float oldY;

        public Particle(int viewportHeight, Vector2 originPosition, Vector2 direction)
        {
            data = new Color[Constant.particleWidth * Constant.particleHeight];
            
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.White;
            }
            position = originPosition;
            this.direction = direction;
         
            delete = false;
            this.viewportHeight = viewportHeight;
            

        }

        public void Move()
        {
            //this.delete = Collision.checkCollision(position, game);
            oldX = position.X;
            oldY = position.Y;
            if ((position.Y <= viewportHeight) &&(position.Y>=0)&&(!delete))
            {
                position.Y += velocity.Y * direction.Y*Constant.explosionSpeed;
                position.X += velocity.X * direction.X*Constant.explosionSpeed;
            }
            else
            {
                delete = true;
            }
              
            if ((oldX== position.X)&&(oldY== position.Y))
            {
                delete = true;
            }
        }

       
    }
}
