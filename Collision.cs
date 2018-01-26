using System;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SpaceInvaders
{
    internal class GraphicObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

    }
    public static class Collision
    {


        private static Boolean CheckEllementCollision(Vector2 origin, Object o)
        {
            GraphicObject destiny = null;

            if (o.GetType() == typeof(Enemie))
            {
                destiny = EnemieToGraphicObject((Enemie)o);
            }

            if (o.GetType() == typeof(Nave))
            {
                destiny = NaveToGraphicObject((Nave)o);
            }

            if (destiny != null)
                return ((destiny.X <= origin.X) && (origin.X <= (destiny.X + destiny.Width))) &&
                    ((destiny.Y <= origin.Y) && (origin.Y <= (destiny.Y + destiny.Height)));

            return false;
        }

        private static GraphicObject EnemieToGraphicObject(Enemie enemie)
        {
            return new GraphicObject()
            {
                Y = enemie.position.Y,
                X = enemie.position.X,
                Width = enemie.Width,
                Height = enemie.Height,
            };
        }

        private static GraphicObject NaveToGraphicObject(Nave nave)
        {
            return new GraphicObject()
            {
                Y = nave.position.Y,
                X = nave.position.X,
                Width = nave.Width,
                Height = nave.Height,
            };
        }

        public static Boolean CheckCollision<T>(Vector2 position, Game game, Boolean remove = false) {

            //Check bullet collition with Enemy
            var objects = game.Components.OfType<T>().
                Where(e=> CheckEllementCollision(position,e));

			//For each element
			foreach (T e in objects)
			{	                
                if (remove)
				    game.Components.Remove((IGameComponent) e);
                
				return true;		
			}

			return false;

		}
	}
}

