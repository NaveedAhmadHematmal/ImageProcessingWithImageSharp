using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageProcessingWithImageSharp;

public class FirstTemplate
{
    private Image? _baseLayer;
    public void Generate()
    {
        // generates the first layer of the image
        _baseLayer = new Image<Rgba32>(1080, 1920);


        // saves the image in resources/outputs
        _baseLayer.Save("resources/outputs/firstTemplate.jpg");
    }
}