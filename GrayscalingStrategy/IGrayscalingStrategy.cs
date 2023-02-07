using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Grayscaling
{
    interface IGrayscalingStrategy
    {
        Image<Rgba32> Grayscale(Image<Rgba32> image);
    }
}