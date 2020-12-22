using NetTopologySuite.Geometries;
using NUnit.Framework;

namespace NetTopologySuite.Samples.Tests.Github
{
    [Description("https://github.com/NetTopologySuite/NetTopologySuite/issues/447")]
    public class Issue447
    {
        private static readonly CoordinateSequenceFactory CsFactory =
            NtsGeometryServices.Instance.DefaultCoordinateSequenceFactory;
        
        [Test]
        public void Test()
        {
            var i = new NtsGeometryServices(CsFactory, PrecisionModel.Floating.Value, 0,
                GeometryOverlay.Legacy, new CoordinateZMComparer());
            var pt1 = i.CreateGeometryFactory().CreatePoint(new Coordinate(1, 2));
            var pt2 = i.CreateGeometryFactory().CreatePoint(new CoordinateZ(1, 2, 3));
            Assert.IsFalse(pt1 == pt2);
            Assert.AreNotEqual(pt1, pt2);
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
