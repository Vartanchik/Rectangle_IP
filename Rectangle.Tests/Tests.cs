using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ListIsInvalid_IsNull()
		{
			Assert.Throws<ArgumentNullException>(() => Service.FindRectangle(null));
		}

		[Test]
		public void ListIsInvalid_IsLessThanTwo()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 3}
			};
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(points));
		}

		[Test]
		public void ListIsInvalid_IsHaveDublicates()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 3},
				new Point(){X = 1, Y = 2},
				new Point(){X = 5, Y = 3}
			};
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(points));
		}

		[Test]
		public void ListIsInvalid_ThereIsNoSolution()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 7},
				new Point(){X = 1, Y = 7},
				new Point(){X = 5, Y = 1},
				new Point(){X = 4, Y = 2},
				new Point(){X = 2, Y = 2},
				new Point(){X = 1, Y = 1}
			};
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(points));
		}

		[Test]
		public void Success_OutPointOnTop()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 7},
				new Point(){X = 1, Y = 7},
				new Point(){X = 5, Y = 1},
				new Point(){X = 4, Y = 8},
				new Point(){X = 2, Y = 2},
				new Point(){X = 1, Y = 1}
			};

			var actual = Service.FindRectangle(points);

			var expected = new Impl.Rectangle()
			{
				X = 1,
				Y = 1,
				Width = 4,
				Height = 6
			};

			Assert.AreEqual(expected.X, actual.X);
			Assert.AreEqual(expected.Y, actual.Y);
			Assert.AreEqual(expected.Width, actual.Width);
			Assert.AreEqual(expected.Height, actual.Height);
		}

		[Test]
		public void Success_OutPointOnBottom()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 7},
				new Point(){X = 1, Y = 7},
				new Point(){X = 5, Y = 1},
				new Point(){X = 4, Y = 0},
				new Point(){X = 2, Y = 2},
				new Point(){X = 1, Y = 1}
			};

			var actual = Service.FindRectangle(points);

			var expected = new Impl.Rectangle()
			{
				X = 1,
				Y = 1,
				Width = 4,
				Height = 6
			};

			Assert.AreEqual(expected.X, actual.X);
			Assert.AreEqual(expected.Y, actual.Y);
			Assert.AreEqual(expected.Width, actual.Width);
			Assert.AreEqual(expected.Height, actual.Height);
		}

		[Test]
		public void Success_OutPointOnLeft()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 7},
				new Point(){X = 1, Y = 7},
				new Point(){X = 5, Y = 1},
				new Point(){X = 0, Y = 5},
				new Point(){X = 2, Y = 2},
				new Point(){X = 1, Y = 1}
			};

			var actual = Service.FindRectangle(points);

			var expected = new Impl.Rectangle()
			{
				X = 1,
				Y = 1,
				Width = 4,
				Height = 6
			};

			Assert.AreEqual(expected.X, actual.X);
			Assert.AreEqual(expected.Y, actual.Y);
			Assert.AreEqual(expected.Width, actual.Width);
			Assert.AreEqual(expected.Height, actual.Height);
		}

		[Test]
		public void Success_OutPointOnRight()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 7},
				new Point(){X = 1, Y = 7},
				new Point(){X = 5, Y = 1},
				new Point(){X = 6, Y = 5},
				new Point(){X = 2, Y = 2},
				new Point(){X = 1, Y = 1}
			};

			var actual = Service.FindRectangle(points);

			var expected = new Impl.Rectangle()
			{
				X = 1,
				Y = 1,
				Width = 4,
				Height = 6
			};

			Assert.AreEqual(expected.X, actual.X);
			Assert.AreEqual(expected.Y, actual.Y);
			Assert.AreEqual(expected.Width, actual.Width);
			Assert.AreEqual(expected.Height, actual.Height);
		}

		[Test]
		public void Success_TwoPoints_Horisontal()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 7},
				new Point(){X = 1, Y = 7}
			};

			var actual = Service.FindRectangle(points);

			var expected = new Impl.Rectangle()
			{
				X = 5,
				Y = 7,
				Width = 1,
				Height = 1
			};

			Assert.AreEqual(expected.X, actual.X);
			Assert.AreEqual(expected.Y, actual.Y);
			Assert.AreEqual(expected.Width, actual.Width);
			Assert.AreEqual(expected.Height, actual.Height);
		}

		[Test]
		public void Success_TwoPoints_Vertical()
		{
			var points = new List<Point>()
			{
				new Point(){X = 5, Y = 1},
				new Point(){X = 5, Y = 7}
			};

			var actual = Service.FindRectangle(points);

			var expected = new Impl.Rectangle()
			{
				X = 5,
				Y = 7,
				Width = 1,
				Height = 1
			};

			Assert.AreEqual(expected.X, actual.X);
			Assert.AreEqual(expected.Y, actual.Y);
			Assert.AreEqual(expected.Width, actual.Width);
			Assert.AreEqual(expected.Height, actual.Height);
		}
	}
}