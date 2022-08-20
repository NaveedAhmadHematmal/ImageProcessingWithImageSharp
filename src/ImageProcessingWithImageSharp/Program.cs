using ImageProcessingWithImageSharp.Models;
using ImageProcessingWithImageSharp.Templates;
using SixLabors.ImageSharp;
using ImageProcessingWithImageSharp.Core;
using System;

namespace ImageProcessingWithImageSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create a campaign
            var campaign = new GetShareableImageModel()
            {
                CampaignTypeId = 1,
                CampaignName = "Calories watch gt",
                CampaignDescription = "Gt watch",
                CampaignCreatorUsername = "Naveed Khan",
                CampaignStartDate = "06/08/2022",
                CampaignEndDate = "06/11/2022",
                CampaignPledgeAmount = 10000.0,
                CampaignTotalPledgeAmount = 10000.0,
                CampaignProgress = "153.00",
                CampaignProgressPercentage = "0.15",
                CampaignCoverPictureUrl = "http://18.221.38.133:5300/Uploads/Campaign/Images/1cb603b8-d253-4e6b-8bc4-67f59ec7a488_637902688486849472.jpg",
                TrackingMethodName = "UNICEF",
                TrackingMethodIconPictureUrl = "http://18.221.38.133:5300/Uploads/TrackingMethodIcon/HKActiveEnergyBurnIcon.png",
                FoundationName = "UNICEF",
                FoundationLogoPictureUrl = "http://18.221.38.133:5300/Uploads/User/Profile/default.png",
                CampaignPledgeAmountText = "10000",
                CampaignTotalPledgeAmountText = "10000"
            };

            // make the objects
            var firstTemplate = new FirstTemplate();
            var secondTemplate = new SecondTemplate();

            // generate the image
            firstTemplate.Generate(campaign).Result.Save("resources/outputs/firstTemplate.jpg");
            secondTemplate.Generate(campaign).Result.Save("resources/outputs/SecondTemplate.jpg");
        }
    }
}