﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GeomPad.Helpers
{
    public abstract class HelperItem: AbstractHelperItem
    {
        public int Z { get; set; }
        
        
        public Action Changed;
       

        public virtual RectangleF? BoundingBox()
        {
            return null;
        }
    }    

    
}
