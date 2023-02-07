using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Grayscaling
{
    class GrayLumaStrategy : IGrayscalingStrategy
    {
        public Image<Rgba32> Grayscale(Image<Rgba32> image)
        {
            Image<Rgba32> newImage = new Image<Rgba32>(image.Width, image.Height);

            for(int i=0; i<image.Width; i++){
                for(int j=0; j<image.Height; j++){
                    float val = (image[i,j].R*0.299f + image[i,j].G*0.587f + image[i,j].B*0.114f);
                    Rgba32 pixel = new Rgba32((byte)val, (byte)val, (byte)val);
                    newImage[i,j] = pixel;
                }
            }

            return newImage;
        }
    }
}