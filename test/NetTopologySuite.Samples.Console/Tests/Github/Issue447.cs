using NUnit.Framework;

namespace NetTopologySuite.Samples.Tests.Github
{
    [Description("https://github.com/NetTopologySuite/NetTopologySuite/issues/447")]
    public class Issue447
    {
        [Test]
        public void Test()
        {
            NetTopologySuite.Geometries.Geometry.CoordinateEqualityComparer = new NetTopologySuite.Geometries.CoordinateZMComparer();

            Assert.IsFalse(new NetTopologySuite.Geometries.Point(1, 2) == new NetTopologySuite.Geometries.Point(1, 2, 3));
            Assert.AreNotEqual(new NetTopologySuite.Geometries.Point(1, 2), new NetTopologySuite.Geometries.Point(1, 2, 3));

            NetTopologySuite.Geometries.Geometry.CoordinateEqualityComparer = null;

        }

        [Test]
        public void Test2()
        {
            var pt1 = new NetTopologySuite.Geometries.Point(new NetTopologySuite.Geometries.Coordinate(10, 10));
            var pt2 = new NetTopologySuite.Geometries.Point(new NetTopologySuite.Geometries.CoordinateZ(10, 10));
            Assert.IsTrue(pt1 == pt2); 
            Assert.IsTrue(pt1.Equals((object)pt2));

        }
    }
}
