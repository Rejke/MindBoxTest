using System;
using System.Collections.Generic;

namespace AreaLib
{
    /// <summary>
    /// Class, that provides functionality for circumference area calculation
    /// </summary>
    public class Circumference : Shape
    {
        /*
         *    There is two ways to calculate area.
         *    First way: like below.
         *    Second way: override CalculateArea method (ex. CalculateArea() => Math.PI * Dimensions[0] * Dimensions[0];)
         *    Also, when we choose the second way, must do this: Dimensions = new List<double>{ radius }.AsReadOnly();
         */
        
        /// <param name="radius">Circumference radius</param>
        public Circumference(double radius)
        {
            Dimensions = new List<double>{ radius, radius, Math.PI }.AsReadOnly();
        }
    }
}