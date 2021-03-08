using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
    public static class Service
    {
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static Rectangle FindRectangle(List<Point> points)
        {
            // checking for null value of points
            if (points == null)
            {
                throw new ArgumentNullException("points", "The input list is invalid. Points list is null");
            }

            // checking that points list contains at least 2 points
            if (points.Count < 2)
            {
                throw new ArgumentException("The input list is invalid. " +
                    "Points list should contain at least 2 points");
            }

            // checking fot dublicates of points
            if (HasDublicates(points))
            {
                throw new ArgumentException("The input list is invalid. " +
                    "Points list contain points with the same coordinates");
            }

            // case if there are two points
            if (points.Count == 2)
            {
                if (points[0].Y - points[1].Y > 0 || points[0].X - points[1].X > 0)
                {
                    return new Rectangle()
                    {
                        X = points[0].X,
                        Y = points[0].Y,
                        Width = 1,
                        Height = 1
                    };
                }

                return new Rectangle()
                {
                    X = points[1].X,
                    Y = points[1].Y,
                    Width = 1,
                    Height = 1
                };
            }

            // separate extracting x and y coordinates
            var xCoordinatesList = new List<int>();
            var yCoordinatesList = new List<int>();

            foreach (Point point in points)
            {
                xCoordinatesList.Add(point.X);
                yCoordinatesList.Add(point.Y);
            }

            // finding two extrime x and y coordinates by the four sides: top, bottom, left, right
            var yFirstMaxCoordinate = yCoordinatesList.Max();
            var ySecondMaxCoordinate = yCoordinatesList.OrderByDescending(y => y).Skip(1).First();

            var yFirstMinCoordinate = yCoordinatesList.Min();
            var ySecondMinCoordinate = yCoordinatesList.OrderBy(y => y).Skip(1).First();

            var xFirstMaxCoordinate = xCoordinatesList.Max();
            var xSecondMaxCoordinate = xCoordinatesList.OrderByDescending(x => x).Skip(1).First();

            var xFirstMinCoordinate = xCoordinatesList.Min();
            var xSecondMinCoordinate = xCoordinatesList.OrderBy(x => x).Skip(1).First();


            // finding rectangle if two top points don't have the same y coordinates
            if (yFirstMaxCoordinate != ySecondMaxCoordinate)
            {
                return new Rectangle()
                {
                    X = xFirstMinCoordinate,
                    Y = yFirstMinCoordinate,
                    Width = xFirstMaxCoordinate - xFirstMinCoordinate,
                    Height = ySecondMaxCoordinate - yFirstMinCoordinate
                };
            }

            // finding rectangle if two bottom points don't have the same y coordinates
            if (yFirstMinCoordinate != ySecondMinCoordinate)
            {
                return new Rectangle()
                {
                    X = xFirstMinCoordinate,
                    Y = ySecondMinCoordinate,
                    Width = xFirstMaxCoordinate - xFirstMinCoordinate,
                    Height = yFirstMaxCoordinate - ySecondMinCoordinate
                };
            }

            // finding rectangle if two left points don't have the same x coordinates
            if (xFirstMinCoordinate != xSecondMinCoordinate)
            {
                return new Rectangle()
                {
                    X = xSecondMinCoordinate,
                    Y = yFirstMinCoordinate,
                    Width = xFirstMaxCoordinate - xSecondMinCoordinate,
                    Height = yFirstMaxCoordinate - yFirstMinCoordinate
                };
            }

            // finding rectangle if two right points don't have the same x coordinates
            if (xFirstMaxCoordinate != xSecondMaxCoordinate)
            {
                return new Rectangle()
                {
                    X = xFirstMinCoordinate,
                    Y = yFirstMinCoordinate,
                    Width = xSecondMaxCoordinate - xFirstMinCoordinate,
                    Height = yFirstMaxCoordinate - yFirstMinCoordinate
                };
            }

            // case if  extreme points form rectangle and there is no solution
            throw new ArgumentException("The input list is invalid. " +
                    "Rectangle can't be finded because extreme points form also rectangle.");
        }

        public static bool HasDublicates(List<Point> points)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    if (points[i].X == points[j].X && points[i].Y == points[j].Y) return true;

                }
            }

            return false;
        }
    }
}
