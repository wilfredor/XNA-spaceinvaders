using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public static class Mapper
    {
        public static GraphicObject GetGraphicObject<T>(T o)
        {
            GraphicObject graphicObject = null;

            if (IsValidGraphicObject(o))
            {
                graphicObject = (o as GameObject).ToGraphicObject();
            }

            return graphicObject;
        }

        private static Boolean IsValidGraphicObject<T>(T o)
        {            
            return ((o.GetType() == typeof(Enemie)) || (o.GetType() == typeof(Nave)));
        }
    }
}
