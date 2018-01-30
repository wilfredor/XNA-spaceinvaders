using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public static class Mapper
    {
        public static GraphicObject GetGraphicObject(Object o)
        {
            GraphicObject graphicObject = null;

            if (o.GetType() == typeof(Enemie))
            {                
                graphicObject = Mapper.EnemieToGraphicObject((Enemie)o);
            }

            if (o.GetType() == typeof(Nave))
            {
                graphicObject = Mapper.NaveToGraphicObject((Nave)o);
            }

            return graphicObject;
        }

        public static GraphicObject EnemieToGraphicObject(Enemie enemie) 
        {
            return new GraphicObject()
            {
                Y = enemie.Position.Y,
                X = enemie.Position.X,
                Width = enemie.Width,
                Height = enemie.Height,
            };
        }

        public static GraphicObject NaveToGraphicObject(Nave nave)
        {
            return new GraphicObject()
            {
                Y = nave.Position.Y,
                X = nave.Position.X,
                Width = nave.Width,
                Height = nave.Height,
            };
        }
        
    }
}
