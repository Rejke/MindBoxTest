using System;
using System.Collections.Generic;
using System.Linq;

namespace AreaLib
{
    /// <summary>
    /// Class, that provides functionality for triangle area calculation && determining right triangle
    /// </summary>
    public class Triangle : Shape
    {
        /*     I'm not sure about that way, because I can OrderByDescending List in constructor and
         *     remove OrByDesc in all of Triangle class methods
         */

        /// <param name="sideA">First side of triangle</param>
        /// <param name="sideB">Second side of triangle</param>
        /// <param name="sideC">Third side of triangle</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            Dimensions = new List<double>{ sideA, sideB, sideC }.AsReadOnly();
        }
        
        private bool? _isRight = null;
        
        /// <summary>
        /// Returns whether this triangle is right
        /// </summary>
        public bool IsRight
        {
            get
            {
                _isRight ??= HasRightAngle();

                return (bool) _isRight;
            }
        }

        /// <summary>
        /// Method that represents equality of Pythagorean theorem
        /// </summary>
        /// <returns>Does triangle has a right angle</returns>
        private bool HasRightAngle()
        {
            List<double> dims = Dimensions.OrderByDescending(x => x).ToList();

            return Math.Sqrt(dims[1] * dims[1] + dims[2] * dims[2]) == dims[0];
        }
        
        /// <summary>
        /// Method that represents axiom of existing triangle
        /// </summary>
        protected override bool IsDimsValid(List<double> dims)
        {
            if (dims.Any(x => x <= 0))
                return false;

            return dims[0] + dims[1] > dims[2] && dims[1] + dims[2] > dims[0] && dims[0] + dims[2] > dims[1];
        }

        /// <summary>
        /// Overriden method that represents two-way calculation, based on type of triangle
        /// </summary>
        /// <returns>Triangle's area</returns>
        protected override double CalculateArea()
        {
            if (IsRight)
            {
                List<double> dims = Dimensions.OrderByDescending(x => x).ToList();
                return 0.5 * dims[1] * dims[2];
            }

            double semiP = (Dimensions[0] + Dimensions[1] + Dimensions[2]) / 2;
            return Math.Sqrt(semiP * (semiP - Dimensions[0]) * (semiP - Dimensions[1]) * (semiP - Dimensions[2]));
        }
    }
}