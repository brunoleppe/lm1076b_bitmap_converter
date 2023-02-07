using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Grayscaling
{
    class DesaturationStrategy : IGrayscalingStrategy
    {
        public Image<Rgba32> Grayscale(Image<Rgba32> image)
        {
            Image<Rgba32> newImage = new Image<Rgba32>(image.Width, image.Height);

            for(int i=0; i<image.Width; i++){
                for(int j=0; j<image.Height; j++){

                    byte R,G,B;
                    R = image[i,j].R;
                    G = image[i,j].G;
                    B = image[i,j].B;

                    var val = Math.Max(R,Math.Max(G,B)) + Math.Min(R, Math.Min(G,B));


                    Rgba32 pixel = new Rgba32((byte)(val/2), (byte)(val/2), (byte)(val/2));
                    newImage[i,j] = pixel;
                }
            }

            return newImage;
        }
    }
}