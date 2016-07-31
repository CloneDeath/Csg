﻿using NUnit.Framework;
using System;

namespace Csg.Test
{
	[TestFixture]
	public class IntersectTest : TestWithStlResult
	{
		[Test]
		public void UnitSphere_UnitSphere()
		{
			var sphere1 = Solids.Sphere(1, new Vector3D(-0.5, 0, 0));
			var sphere2 = Solids.Sphere(1, new Vector3D(0.5, 0, 0));
			var r = sphere1.Intersect(sphere2);
			Assert.AreEqual(32, r.Polygons.Count);
			Assert.IsTrue(r.IsCanonicalized);
			Assert.IsTrue(r.IsRetesselated);
			AssertAccepted(r, "IntersectTest");
		}

		[Test]
		public void UnitSphere_NoOverlap_UnitSphere()
		{
			var sphere1 = Solids.Sphere(1, new Vector3D(-50, 0, 0));
			var sphere2 = Solids.Sphere(1, new Vector3D(50, 0, 0));
			var r = sphere1.Intersect(sphere2);
			Assert.AreEqual(0, r.Polygons.Count);
			Assert.IsTrue(r.IsCanonicalized);
			Assert.IsTrue(r.IsRetesselated);
			AssertAccepted(r, "IntersectTest");
		}
	}
}

