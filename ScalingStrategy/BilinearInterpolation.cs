using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Scaling
{
    class BilinearInterpolationStrategy : IScalingStrategy
    {
        public Rgba32 Scale(Image<Rgba32> image, int x, int y, double scale_x, double scale_y)
        {
            double x_ = x/scale_x;
            double y_ = y/scale_y;

            //Finding neighboring points
            int x1 = Math.Min((int)Math.Floor(x_), image.Width-1);
            int y1 = Math.Min((int)Math.Floor(y_), image.Height-1);
            int x2 = Math.Min((int)Math.Ceiling(x_), image.Width-1);
            int y2 = Math.Min((int)Math.Ceiling(y_), image.Height-1);


            var Q11 = new Vector(image[x1, y1]);
            var Q12 = new Vector(image[x2, y1]);
            var Q21 = new Vector(image[x1, y2]);
            var Q22 = new Vector(image[x2, y2]);


            //Interpolating P1 and P2
            var P1 = (x2-x_)*Q11 + (x_-x1)*Q12;
            var P2 = (x2-x_)*Q21 + (x_-x1)*Q22;

            if (x1 == x2){
                P1 = Q11;
                P2 = Q22;
            }

            //Interpolating P
            var P = (y2-y_)*P1 + (y_-y1)*P2;

            return P.ToPixel();
        }
    }

    public struct Vector{
        double a;
        double b;
        double c;

        public Vector(Rgba32 pixel){
            a = pixel.R;
            b = pixel.G;
            c = pixel.B;
        }

        public Rgba32 ToPixel(){
            byte R,G,B;
            R = (byte)a;
            G = (byte)b;
            B = (byte)c;
            
            return new Rgba32(R, G, B);
        }

        public static Vector operator *(Vector v, int n)
        {
            return n*v;
        }
        public static Vector operator *(double n, Vector v)
        {
            v.a *= n;
            v.b *= n;
            v.c *= n;
            return v;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            v1.a += v2.a;
            v1.b += v2.b;
            v1.c += v2.c;
            return v1;
        }     

    }
}