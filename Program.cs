﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.PixelFormats;
using Scaling;
using Grayscaling;
using Converting;

string imagePath = "image1.jpg";
int nHeight = 128;
int nWidth = 240;




IScalingStrategy scalingStrategy = new BoxSamplingStrategy();
IGrayscalingStrategy grayscalingStrategy = new DesaturationStrategy();
IConvertingStrategy convertingStrategy = new Lm1076bStrategy();

var image = Image.Load<Rgba32>(imagePath);

double scaleX = (double)nWidth/image.Width;
double scaleY = (double)nHeight/image.Height;

//Scaling 
Image<Rgba32> newImage = new Image<Rgba32>(nWidth,nHeight);

for(int y=0; y<nHeight; y++){
    for(int x=0; x<nWidth; x++){
        Rgba32 pixel = scalingStrategy.Scale(image,x,y,scaleX,scaleY);
        newImage[x,y] = pixel;
    }
}

//GrayScale
var _image = grayscalingStrategy.Grayscale(newImage);
_image.SaveAsBmp("test1.bmp");


string filepath = "file.txt";
FileStream fs = File.Open(filepath, FileMode.OpenOrCreate);
using(StreamWriter writer = new StreamWriter(fs)){
    convertingStrategy.Convert(_image, writer);
}