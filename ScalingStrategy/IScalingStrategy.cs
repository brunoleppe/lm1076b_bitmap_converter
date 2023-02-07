using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Scaling
{
    interface IScalingStrategy
    {
        Rgba32 Scale(Image<Rgba32> image, int x, int y, double scale_x, double scale_y);
    }
}