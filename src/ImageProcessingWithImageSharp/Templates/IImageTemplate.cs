using ImageProcessingWithImageSharp.Models;
using SixLabors.ImageSharp;

namespace ImageProcessingWithImageSharp.Templates;

public interface IImageTemplate
{
    public Task<Image> Generate(Campaign campaign);
}