using System;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SpaceInvaders
{
    /// <summary>
    /// Collision element class, check if a element is in collision 
    /// </summary>
    public static class Collision
    {

        private static Boolean CheckEllementCollision(Vector2 origin, GraphicObject destiny)
        {
            Boolean ellementCollision = false;

            if (destiny != null)
            {
                ellementCollision =
                    ((destiny.X <= origin.X) && (origin.X <= (destiny.X + destiny.Width)))
                    &&
                    ((destiny.Y <= origin.Y) && (origin.Y <= (destiny.Y + destiny.Height)));
            }

            return ellementCollision;
        }

        public static Boolean CheckCollision<T>(Vector2 position, Game game, Boolean remove = false) {

            //Check bullet collition with Enemy
            List<T> objects = game.Components.OfType<T>().
                Where(e => CheckEllementCollision(position, Mapper.GetGraphicObject(e))).ToList();

            Boolean collision = (objects.Count() > 0);

            if (remove && collision)
            {
                objects.ForEach(x => game.Components.Remove((IGameComponent)x));
            }

            return collision;
        }

        public static Vector2 GetNoCollisionPlace(Game game, Random rnd)
        {            
            Vector2 noCollisionPlace = new Vector2();
            noCollisionPlace.X = rnd.Next(10, 600);
            noCollisionPlace.Y = rnd.Next(10, 50*GameInfo.Level);

            if (!CheckCollision<Enemie>(noCollisionPlace, game))
            {
                return noCollisionPlace;
            }

            return GetNoCollisionPlace(game,new Random());
         }
            
        public static List<T> ElementsInCollision<T>(Vector2 position, Game game)
        {
            //Check bullet collition with Enemy
            return (List<T>) game.Components.OfType<T>().
                Where(e => CheckEllementCollision(position, Mapper.GetGraphicObject(e)));            
        }       

    }
}

