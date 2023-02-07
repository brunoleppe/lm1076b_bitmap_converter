using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Scaling
{
    class BoxSamplingStrategy : IScalingStrategy
    {
        
        public Rgba32 Scale(Image<Rgba32> image, int x, int y, double scale_x, double scale_y)
        {
            int box_width = (int)Math.Ceiling(1/scale_x);
            int box_height = (int)Math.Ceiling(1/scale_y);

            int x_ = (int)Math.Floor(x/scale_x);
            int y_ = (int)Math.Floor(y/scale_y);

            int x_end = Math.Min(x_ + box_width, image.Width-1);
            int y_end = Math.Min(y_ + box_height,image.Height-1);

            int count = 0;
            double R=0,G=0,B=0;
            for(int i=x_;i<x_end;i++){
                for(int j=y_;j<y_end;j++){
                    count++;
                    R += image[i,j].R;
                    G += image[i,j].G;
                    B += image[i,j].B;
                }
            }

            R = R/count;
            G = G/count;
            B = B/count;

            byte r,g,b;
            r = (byte)R;
            g = (byte)G;
            b = (byte)B;

            return new Rgba32(r,g,b);

        }
    }
}