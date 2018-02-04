using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public static class Common
    {

        public static Boolean IsBulletOutOfRange(Bullet bullet)
        {
            return (bullet.Position.Y >= -bullet.Texture.Height);
        }

        public static void DestroyGameObjectsByType<T>(List<T> objects, Game game)
        {
            objects.ForEach(x => game.Components.Remove((IGameComponent)x));
        }

        public static int MainBarPosition(SpriteFont Font, StringBuilder mainBarText)
        {
            //Font.MeasureString(mainBarText).Y is the font size
            //GameInfo.Height is the screen height size
            return (int)(GameInfo.Height - Font.MeasureString(mainBarText).Y);
        }

        private static Boolean IsBorderX(int positionX, int limitWidth)
        {
            return (positionX >= limitWidth) || (positionX <= 0);
        }

        private static Boolean IsBorderY(int positionY, int limitHeight)
        {
            return (positionY >= limitHeight);
        }

        public static Vector2 SpaceInvadersMovement(GameTime gameTime, Vector2 _position, ref int _directionX, int limitX, int limitY)
        {

            float time = (float)gameTime.TotalGameTime.TotalSeconds;

            //Center origin position x,y
            if (IsBorderY((int)_position.Y, limitY))
            {
                _position.Y = 0;
            }

            if (IsBorderX((int)_position.X, limitX))
            {
                //Change movement to back (-1) or forward (1) if the Enemi is in the border X
                _directionX *= -1;
            }

            _position.Y += 0.1f;

            Vector2 _position2 = new Vector2(_position.X + _directionX, _position.Y);


            return new Vector2(
                 _position2.X,
                (float)(Math.Sin(time * 5) * 2 + _position2.Y)

            );
        }


    }
}
