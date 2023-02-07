using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Converting
{
    class Lm1076bStrategy : IConvertingStrategy
    {
        const int _PixelsPerByte = 2;
        public const int _Height = 128;
        public const int _Width = 240;
        public void Convert(Image<Rgba32> image, StreamWriter writer)
        {
            int length = image.Width*image.Height/_PixelsPerByte;
    
            byte[] buffer = new byte[length];
            int counter = 0;
            int byteCount = 0;
            writer.WriteLine($"const uint8_t bitmap[{length}] = {{ ");
            
            for(int j=0;j<image.Height;j++){
                for(int i=0;i<image.Width;i+=_PixelsPerByte){
                
                    byte p0 = (byte)((~image[i,j].R) & 0xF0);
                    byte p1 = (byte)((~image[i+1,j].R) & 0xF0);

                    byte b = (byte)(p0 | (p1>>4));
                    
                    
                    buffer[byteCount++] = b;
                    writer.Write(string.Format("0x{0:X2}, ",b));
                    if(++counter == 120){
                        counter = 0;
                        writer.WriteLine("");
                    }
                }
            }
            writer.WriteLine(Environment.NewLine+"};");
        }
    }
}