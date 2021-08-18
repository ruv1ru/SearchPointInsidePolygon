using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {

        //public static Polyline[] points { get; set; }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            /*
            points = new Polyline[5];
            
            points[0] = new Polyline { Longitude = (float)151.20823693, Latitude = (float)-33.85354, LineNo=1 };
            points[1] = new Polyline { Longitude = (float)151.196788745664, Latitude = (float)-33.8680286253515, LineNo=2 };
            points[2] = new Polyline { Longitude = (float)151.204213822969, Latitude = (float)-33.9095238980532, LineNo=3 };
            points[3] = new Polyline { Longitude = (float)151.256678192676, Latitude = (float)-33.928839646798, LineNo=4 };
            points[4] = new Polyline { Longitude = (float)151.284423324102, Latitude = (float)-33.8917417264152, LineNo=5 };
            */





           var summery = BenchmarkRunner.Run<PolygonCalc>();

            //var iswithin = PointInPolygon((float)-33.85242047501231, (float)151.28089997303726);
            // var iswithin = PointInPolygon((float)-33.87750743874254, (float)151.21120546037332);
            //var iswithin = PointInPolygon((float)-33.88605812773111, (float)151.0603151238422);
            //var iswithin = PointInPolygon((float)-33.9554295047651, (float)151.1188516480255);
            //-33.97251439193823, 151.24124619859052






            //-33.87437197141874, 151.21721360801675
            //-33.88605812773111, 151.0603151238422

            //-33.85441629879196, 151.01877307442183
            //-33.87750743874254, 151.21120546037332
            //Console.WriteLine(iswithin);
            //Console.ReadLine();
        }


        // Return True if the point is in the polygon.

    }

    public class Polyline
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int LineNo { get; set; }
    }

    public class PolygonCalc
    {

        [Benchmark]
        public void CalcPointInPolygon()
        {
            var points = new Polyline[4];
            points[0] = new Polyline { Longitude = (float)144.986757624512, Latitude = (float)-37.8742496984021, LineNo = 1 };
            points[1] = new Polyline { Longitude = (float)144.874150385742, Latitude = (float)-37.8073490313071, LineNo = 2 };
            points[2] = new Polyline { Longitude = (float)144.967688227539, Latitude = (float)-37.7752919818787, LineNo = 3 };
            points[3] = new Polyline { Longitude = (float)145.043029963379, Latitude = (float)-37.8191982271826, LineNo = 4 };
            var iswithin = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin2 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin3 = new PolygonCalc().PointInPolygon((float)-37.622617993548974, (float)145.02285690672713, points);
            var iswithin4 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin5 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.4490672713, points);
            var iswithin6 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin7 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02544690672713, points);
            var iswithin8 = new PolygonCalc().PointInPolygon((float)-37.800617993548974, (float)145.02285690672713, points);
            var iswithin9 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin10 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin11 = new PolygonCalc().PointInPolygon((float)-37.722617993548974, (float)145.02285690672713, points);
            var iswithin12 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin13 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin84 = new PolygonCalc().PointInPolygon((float)-37.8226170000974, (float)145.02285690672713, points);
            var iswithin95= new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin106 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin117 = new PolygonCalc().PointInPolygon((float)-37.80017993548974, (float)145.02285690672713, points);
            var iswithin128 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);
            var iswithin139 = new PolygonCalc().PointInPolygon((float)-37.822617993548974, (float)145.02285690672713, points);

        }

        public bool PointInPolygon(float latitude, float longitude, Polyline[] points)
        {
            // Get the angle between the point and the
            // first and last vertices.

            var orderedPoints = points.OrderBy(p => p.LineNo).ToList();

            var firstPoint = orderedPoints.FirstOrDefault();
            var lastPoint = orderedPoints.LastOrDefault();

            float total_angle = GetAngle(
                lastPoint.Latitude, lastPoint.Longitude,
                latitude, longitude,
                firstPoint.Latitude, lastPoint.Longitude);

            // Add the angles from the point
            // to each other pair of vertices.
            for (int i = 0; i < points.Length - 1; i++)
            {
                total_angle += GetAngle(
                    points[i].Latitude, points[i].Longitude,
                    latitude, longitude,
                    points[i + 1].Latitude, points[i + 1].Longitude);
            }

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            // The following statement was changed. See the comments.
            //return (Math.Abs(total_angle) > 0.000001);
            return (Math.Abs(total_angle) > 1);
        }

        // Return the angle ABC.
        // Return a value between PI and -PI.
        // Note that the value is the opposite of what you might
        // expect because Y coordinates increase downward.
        public static float GetAngle(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the dot product.
            float dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);

            // Get the cross product.
            float cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

            // Calculate the angle.
            return (float)Math.Atan2(cross_product, dot_product);
        }

        // Return the cross product AB x BC.
        // The cross product is a vector perpendicular to AB
        // and BC having length |AB| * |BC| * Sin(theta) and
        // with direction given by the right-hand rule.
        // For two vectors in the X-Y plane, the result is a
        // vector with X and Y components 0 so the Z component
        // gives the vector's length and direction.
        public static float CrossProductLength(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }

        // Return the dot product AB · BC.
        // Note that AB · BC = |AB| * |BC| * Cos(theta).
        private static float DotProduct(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the dot product.
            return (BAx * BCx + BAy * BCy);
        }
    }
}
