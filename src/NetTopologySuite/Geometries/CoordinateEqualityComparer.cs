using System;

namespace NetTopologySuite.Geometries
{
    /// <summary>
    /// A class that can be used to test coordinates for equality
    /// </summary>
    public abstract class CoordinateEqualityComparer
    {
        /// <summary>
        /// Method to test 2 <see cref="Coordinate"/>s for equality, allowing a tolerance.
        /// </summary>
        /// <param name="a">The 1st Coordinate</param>
        /// <param name="b">The 2nd Coordinate</param>
        /// <param name="tolerance">A tolerance value</param>
        /// <returns></returns>
        public abstract bool AreEqual(Coordinate a, Coordinate b, double tolerance);
    }

    /// <summary>
    /// An implementation of <see cref="CoordinateEqualityComparer"/> that includes
    /// <see cref="Coordinate.Z"/> into equality tests.
    /// </summary>
    public sealed class CoordinateZComparer : CoordinateEqualityComparer
    {
        /// <inheritdoc cref="CoordinateEqualityComparer.AreEqual"/>
        public override bool AreEqual(Coordinate a, Coordinate b, double tolerance)
        {
            if (tolerance.Equals(0d))
                return a.Equals(b) && EqualInZ(a, b);

            return a.Distance(b) <= tolerance && DistanceInZ(a, b) <= tolerance;
        }

        private bool EqualInZ(Coordinate a, Coordinate b)
        {
            if (double.IsNaN(a.Z) && double.IsNaN(b.Z))
                return true;

            if (double.IsNaN(a.Z) || double.IsNaN(b.Z))
                return false;

            return a.Z == b.Z;
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
}
