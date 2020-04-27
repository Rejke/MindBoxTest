using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AreaLib
{
    /// <summary>
    /// Abstract class, that provides functionality for shape's area calculation
    /// </summary>
    public abstract class Shape
    {
        private double _area = double.NaN;

        /// <summary>
        /// Returns shape's area
        /// </summary>
        public double Area
        {
            get
            {
                if (double.IsNaN(_area)) 
                    _area = CalculateArea();

                return _area;
            }
        }
        
        private List<double> dimensions;

        /// <summary>
        /// Sets and gets readonly dimensions list
        /// </summary>
        /// <exception cref="NullReferenceException">Dimensions must be initialized before accessing.</exception>
        /// <exception cref="ArgumentException">The provided dimensions are invalid.</exception>
        protected ReadOnlyCollection<double> Dimensions
        {
            get
            {
                if (dimensions == null)
                    throw new NullReferenceException("Dimensions must be initialized before accessing.");
                return dimensions.AsReadOnly();
            }
            set
            {
                if (IsDimsValid(value.ToList()))
                    dimensions = value.ToList();
                else
                    throw new ArgumentException("The provided dimensions are invalid.");
            }
        }

        /// <summary>
        /// Calculates shape's area based on dimensions data
        /// </summary>
        /// <returns>Calculated area</returns>
        protected virtual double CalculateArea() 
            => dimensions.Aggregate(1.0, (current, dim) => current * dim);

        /// <summary>
        /// Validates given dimensions
        /// </summary>
        /// <param name="dims">Shape's dimensions</param>
        protected virtual bool IsDimsValid(List<double> dims) 
            => dims.TrueForAll(double.IsNormal) && dims.All(x => x > 0);
    }
}