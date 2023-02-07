using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Scaling
{
    class NearestNeighboursStrategy : IScalingStrategy
    {
        public Rgba32 Scale(Image<Rgba32> image, int x, int y, double scale_x, double scale_y)
        {
            int x_nearest = (int)Math.Round(x/scale_x);
            int y_nearest = (int)Math.Round(y/scale_y);
            return image[x_nearest, y_nearest];
        }
    }
}