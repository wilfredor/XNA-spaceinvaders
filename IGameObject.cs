using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    interface IGameObject 
    {
        int LimitHeight { get; set; }
        int LimitWidth { get; set; }    
        int Width { get; set; }
        int Height { get; set; }
    }
}
