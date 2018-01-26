using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Xna.Framework;

namespace SpaceInvaders
{
    static class Tool
    {
        /// <summary>
        /// Creates color with corrected brightness.
        /// </summary>
        /// <param name="color">Color to correct.</param>
        /// <param name="correctionFactor">The brightness correction factor. Must be between -1 and 1. 
        /// Negative values produce darker colors.</param>
        /// <returns>
        /// Corrected <see cref="Color"/> structure.
        /// </returns>
        /// https://stackoverflow.com/questions/801406/c-create-a-lighter-darker-color-based-on-a-system-color
        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            
            return new Color(color.A, (int)red, (int)green, (int)blue);
        }

        //From http://stackoverflow.com/questions/3669760/iqueryable-oftypet-where-t-is-a-runtime-type
        public static IList OfTypeToList(this IEnumerable source, Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return
                (IList)Activator.CreateInstance(
                    typeof(List<>)
                    .MakeGenericType(type),
                    typeof(System.Linq.Enumerable)
                    .GetMethod(nameof(System.Linq.Enumerable.OfType),
                        BindingFlags.Static | BindingFlags.Public)
                    .MakeGenericMethod(type)
                    .Invoke(null, new object[] { source }));
        }
    }
}
