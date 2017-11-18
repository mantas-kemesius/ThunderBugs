using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    public static class IsBetween
    {
        public static bool Between(this int x, int value1, int value2)
        {
            return (x > value1 && x < value2) ? true : false;
            
        }
    }
}
