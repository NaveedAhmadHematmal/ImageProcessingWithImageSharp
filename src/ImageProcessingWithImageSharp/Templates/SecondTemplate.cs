using ImageProcessingWithImageSharp.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.Fonts;
using SixLabors.ImageSharp.Formats.Png;
using ImageProcessingWithImageSharp.Core;
using System.Threading.Tasks;

namespace ImageProcessingWithImageSharp.Templates
{

    public class SecondTemplate
    {
        private Image _sampleImage;
        private Image _logo;
        private Image _activityImage;
        private Image _NgoUrl;
        private Image _bottomLayer;
        public async Task<Image> Generate(GetShareableImageModel campaign)
        {
            // load images
            _activityImage = await ImageProcessingCore.LoadImageFromUrlAndResize(campaign.TrackingMethodIconPictureUrl, 55, 55);
            _NgoUrl = await ImageProcessingCore.LoadImageFromUrlAndResize(campaign.FoundationLogoPictureUrl, 40, 40);
            _sampleImage = await ImageProcessingCore.LoadImageFromUrlAndResize(campaign.CampaignCoverPictureUrl, 1000, 1000);
            _logo = await ImageProcessingCore.LoadAndResizeImage("resources/images/logo.png");
            _bottomLayer = await ImageProcessingCore.LoadAndResizeImage("resources/images/SecondTemplateFrame.png", 1000, 80);

            // draws logo
            _sampleImage = ImageProcessingCore.DrawImageAt(_sampleImage, _logo, 20, 20);

            // write campaign title
            _sampleImage = ImageProcessingCore.DrawTextAtImage(_sampleImage, campaign.CampaignName, Color.White, 45, 10, 820, 1, "resources/fonts/myFont.ttf");

            // writes user names
            _sampleImage = ImageProcessingCore.DrawTextAtImage(_sampleImage, $"@{campaign.CampaignCreatorUsername}", Color.Red, 25, 680, 840, 1, "resources/fonts/myFont.ttf");

            // draws bottom line skeleton
            _sampleImage = ImageProcessingCore.DrawImageAt(_sampleImage, _bottomLayer, 0, 920);

            // draws activity image
            _sampleImage = ImageProcessingCore.DrawImageAt(_sampleImage, _activityImage, 16, 925);

            // writes activity name
            _sampleImage = ImageProcessingCore.DrawTextAtImage(_sampleImage, campaign.TrackingMethodName, Color.White, 30, 100, 940, 0, "resources/fonts/myFont.ttf");

            // draws NGO image
            _sampleImage = ImageProcessingCore.DrawImageAt(_sampleImage, _NgoUrl, 380, 940);

            // writes NGO name
            _sampleImage = ImageProcessingCore.DrawTextAtImage(_sampleImage, campaign.TrackingMethodName, Color.White, 30, 455, 940, 0, "resources/fonts/myFont.ttf");

            // draws pledge amount as icon
            _sampleImage = ImageProcessingCore.DrawTextAtImage(_sampleImage, "10K", Color.Red, 30, 724, 935, 1, "resources/fonts/myFont.ttf");

            // writes pledge amount
            _sampleImage = ImageProcessingCore.DrawTextAtImage(_sampleImage, campaign.CampaignPledgeAmountText, Color.White, 30, 795, 940, 0, "resources/fonts/myFont.ttf");

            return _sampleImage;
        }
    }
}