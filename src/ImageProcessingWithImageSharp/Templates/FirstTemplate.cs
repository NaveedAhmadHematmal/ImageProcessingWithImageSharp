// using ImageProcessingWithImageSharp.Models;
// using SixLabors.ImageSharp;
// using SixLabors.ImageSharp.Drawing;
// using SixLabors.ImageSharp.Drawing.Processing;
// using SixLabors.ImageSharp.PixelFormats;
// using SixLabors.ImageSharp.Processing;

// namespace ImageProcessingWithImageSharp.Templates;

// public class FirstTemplate : IImageTemplate
// {
//     private Image? _baseLayer;
//     private Image? _sampleImage;
//     public Task<Image> Generate(Campaign campaign)
//     {
//         // generates the first layer of the image
//         _baseLayer = new Image<Rgba32>(1080, 1920);

//         // load sample image
//         _sampleImage = Image.Load(campaign.SampleImage);

//         // resize the sample image
//         _sampleImage.Mutate(x => x.Resize(new Size(700)));

//         // create a rectangle
//         // Image rect = new Image<Rgba32>(20, 30);
//         // Point pointBigImage2 = new Point(20, 10);

//         RectangleF rect = new RectangleF(0, 30, 50, 40);
//         IPen pen = Pens.Solid(Color.Red, 5);

//         // rect2.Mutate(x => x.Draw(pen, rect)
//                                 //   .Fill(Color.Red));

//         _sampleImage.Mutate(x => x.Draw(pen, rect)
//                                   .Fill(Color.Red, rect));

//         // merge with _baseLayer
//         Point pointBigImage = new Point(190, 300);
//         GraphicsOptions g = new GraphicsOptions();
//         _baseLayer.Mutate(x => x.DrawImage(_sampleImage, pointBigImage, g));
    

//         // saves the image in resources/outputs
//         return _baseLayer;
//     }
// }