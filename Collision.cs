using System;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SpaceInvaders
{
	public static class Collision
	{

        
		private static Boolean checkEllementCollision(Vector2 position, Enemie e)
		{
			return ((e.position.X <= position.X) && (position.X <= (e.position.X + e.Width))) &&
				((e.position.Y <= position.Y) && (position.Y <= (e.position.Y + e.Height)));
		}
		private static Boolean isEnemie(Type e)
		{
			return (e == typeof(Enemie));
		}
		
		public static Boolean checkCollision(Vector2 position, Game game) {

			var enemies = game.Components.OfType<Enemie>();
			//var enemies = 
			int countComp = game.Components.Count;
			//Enemie enemie = null;

			//For each enemy
			foreach (var enemie in enemies)
			{
				//Check Enemy type

					
					//Check bullet collition with Enemy
					if (checkEllementCollision(position, enemie)) {
						//Delete Enemy
						game.Components.Remove(enemie);

						//Delete bullet

						return true;


					}
				

			}

			return false;

		}
	}
}

