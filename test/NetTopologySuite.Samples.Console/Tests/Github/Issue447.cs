using NUnit.Framework;

namespace NetTopologySuite.Samples.Tests.Github
{
    [Description("https://github.com/NetTopologySuite/NetTopologySuite/issues/447")]
    public class Issue447
    {
        [Test]
        public void Test()
        {
            NetTopologySuite.Geometries.Geometry.CoordinateEqualityComparer = new NetTopologySuite.Geometries.CoordinateZComparer();

            Assert.IsFalse(new NetTopologySuite.Geometries.Point(1, 2) == new NetTopologySuite.Geometries.Point(1, 2, 3));
            Assert.AreNotEqual(new NetTopologySuite.Geometries.Point(1, 2), new NetTopologySuite.Geometries.Point(1, 2, 3));

            NetTopologySuite.Geometries.Geometry.CoordinateEqualityComparer = null;

        }
    }
}
