using ImageProcessingWithImageSharp.Core;
using ImageProcessingWithImageSharp.Models;
using SixLabors.ImageSharp;

namespace ImageProcessingWithImageSharp.Templates;

public class FirstTemplate : IImageTemplate
{
    private Image? _baseLayer;
    private Image? _sampleImage;
    private Image? _logo;
    private Image? _activityImage;
    private Image? _NgoUrl;
    public async Task<Image> Generate(Campaign campaign)
    {
        // load sample image
        _activityImage = await ImageProcessingCore.LoadImageFromUrlAndResize(campaign.ActivityUrl, 120, 120);
        _NgoUrl = await ImageProcessingCore.LoadImageFromUrlAndResize(campaign.NGOUrl, 100, 100);
        _baseLayer = await ImageProcessingCore.LoadAndResizeImage("resources/images/firstTemplateBaseLayer.png", 1080, 1920);
        _sampleImage = await ImageProcessingCore.LoadAndResizeImage(campaign.SampleImage, 550, 500);
        
        // Draws campaign type rectangle
        _sampleImage = ImageProcessingCore.DrawFilledRect(_sampleImage, 0, 30, 200, 40, Color.Red);
        
        // Write campaign type
        _sampleImage = ImageProcessingCore.DrawTextAtImage(_sampleImage, campaign.CampaignType, Color.White, 25, 5, 27, 1);
        
        // write campaign title
        _baseLayer = ImageProcessingCore.DrawTextAtImage(_baseLayer, campaign.Title, Color.White, 35, 274, 1150, 0, "resources/fonts/myFont.ttf");
        
        // writes user names
        _baseLayer = ImageProcessingCore.DrawTextAtImage(_baseLayer, campaign.SubTitle, Color.Red, 25, 274, 1200, 0, "resources/fonts/myFont.ttf");

        // draws progress bar
        _baseLayer = ImageProcessingCore.DrawProgressBar(_baseLayer, 274, 1500, 550, 24, campaign.CompletedProgressBar);
        // writes progress bar text
        _baseLayer = ImageProcessingCore.DrawTextAtImage(_baseLayer, $"{campaign.CompletedProgressBar}% Completed", Color.White, 25, 274, 1525, 0, "resources/fonts/myFont.ttf");
        _baseLayer = ImageProcessingCore.DrawTextAtImage(_baseLayer, $"Ends {campaign.Ends}", Color.Red, 25, 710, 1525, 0, "resources/fonts/myFont.ttf");

        // merge with _baseLayer
        _baseLayer = ImageProcessingCore.DrawImageAt(_baseLayer, _sampleImage, 274, 650);
        
        // draws activity image
        _baseLayer = ImageProcessingCore.DrawImageAt(_baseLayer, _activityImage, 275, 1293);

        // draws NGO image
        _baseLayer = ImageProcessingCore.DrawImageAt(_baseLayer, _NgoUrl, 500, 1310);

        // draws pledge amount as icon
        _baseLayer = ImageProcessingCore.DrawTextAtImage(_baseLayer, campaign.PledgeAmountText, Color.Red, 50, 690, 1300, 1, "resources/fonts/myFont.ttf");
        _baseLayer = ImageProcessingCore.DrawTextAtImage(_baseLayer, "Pledge", Color.Red, 30, 700, 1360, 0, "resources/fonts/myFont.ttf");

        // saves the image in resources/outputs
        return _baseLayer;
    }
}