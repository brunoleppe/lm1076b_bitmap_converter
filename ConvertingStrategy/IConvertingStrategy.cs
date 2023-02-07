using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Converting
{
    interface IConvertingStrategy
    {
        
        void Convert(Image<Rgba32> image, StreamWriter writer);
        
    }
}