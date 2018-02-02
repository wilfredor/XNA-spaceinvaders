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

       
    }
}
