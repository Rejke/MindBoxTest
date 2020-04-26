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
    }
}