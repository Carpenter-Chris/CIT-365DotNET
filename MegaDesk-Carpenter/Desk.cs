using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Carpenter
{
    public class Desk
    {
        public Desk(float width, float depth, int drawers, int surfaceIndex)
        {
            this.width = width;
            this.depth = depth;
            this.drawers = drawers;
            this.surfaceIndex = surfaceIndex;
           
        }


        public float width { get; set; }
        public float depth { get; set; }
        public int drawers { get; set; }
        public int surfaceIndex { get; set; }
        



        //Dest Constraints
        public const int MINWIDTH = 24;

    }

    //rec by teacher 
    //enum
}
