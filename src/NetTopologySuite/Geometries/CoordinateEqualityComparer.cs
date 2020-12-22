using System;
using System.Collections.Generic;

namespace NetTopologySuite.Geometries
{
    /// <summary>
    /// A class that can be used to test coordinates for equality
    /// </summary>
    [Serializable]
    public class CoordinateEqualityComparer : EqualityComparer<Coordinate>
    {
        /// <inheritdoc cref="EqualityComparer{T}.Equals(T, T)"/>
        public sealed override bool Equals(Coordinate x, Coordinate y)
        {
            return AreEqual(x, y, 0d);
        }

        /// <inheritdoc cref="EqualityComparer{T}.GetHashCode(T)"/>
        public sealed override int GetHashCode(Coordinate c)
        {
            return c.GetHashCode();
        }

        /// <summary>
        /// Method to test 2 <see cref="Coordinate"/>s for equality, allowing a tolerance.
        /// </summary>
        /// <param name="a">The 1st Coordinate</param>
        /// <param name="b">The 2nd Coordinate</param>
        /// <param name="tolerance">A tolerance value</param>
        /// <returns></returns>
        public virtual bool AreEqual(Coordinate a, Coordinate b, double tolerance)
        {
            if (tolerance == 0)
                return a.Equals(b);

            return a.Distance(b) <= tolerance;
        }
    }



    /// <summary>
    /// An implementation of <see cref="CoordinateEqualityComparer"/> that includes
    /// <see cref="Coordinate.Z"/> into equality tests.
    /// </summary>
    [Serializable]
    public sealed class CoordinateZComparer : CoordinateEqualityComparer
    {
        /// <inheritdoc cref="CoordinateEqualityComparer.AreEqual"/>
        public override bool AreEqual(Coordinate a, Coordinate b, double tolerance)
        {
            if (tolerance.Equals(0d))
                return a.Equals(b) && a.Z.Equals(b.Z);

            return a.Distance(b) <= tolerance && DistanceInZ(a, b) <= tolerance;
        }

        private static double DistanceInZ(Coordinate a, Coordinate b)
        {
            if (double.IsNaN(a.Z) && double.IsNaN(b.Z))
                return 0d;

            if (double.IsNaN(a.Z) || double.IsNaN(b.Z))
                return double.PositiveInfinity;

            return Math.Abs(a.Z - b.Z);
        }
    }
    /// <summary>
    /// An implementation of <see cref="CoordinateEqualityComparer"/> that includes
    /// <see cref="Coordinate.Z"/> and <see cref="Coordinate.M"/> into equality tests.
    /// </summary>
    [Serializable]
    public sealed class CoordinateZMComparer : CoordinateEqualityComparer
    {
        /// <inheritdoc cref="CoordinateEqualityComparer.AreEqual"/>
        public override bool AreEqual(Coordinate a, Coordinate b, double tolerance)
        {
            if (tolerance.Equals(0d))
                return a.Equals(b) && a.Z.Equals(b.Z) && a.M.Equals(b.M);

            return a.Distance(b) <= tolerance &&
                   Distance(a.Z, b.Z) <= tolerance &&
                   Distance(a.M, b.M) <= tolerance;
        }

        private static double Distance(double a, double b)
        {
            if (double.IsNaN(a) && double.IsNaN(b))
                return 0d;

            if (double.IsNaN(a) || double.IsNaN(b))
                return double.PositiveInfinity;

            return Math.Abs(a - b);
        }
    }
}
