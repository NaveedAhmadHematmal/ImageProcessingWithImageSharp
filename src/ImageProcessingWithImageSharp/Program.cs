using ImageProcessingWithImageSharp.Models;
using ImageProcessingWithImageSharp.Templates;
using SixLabors.ImageSharp;

// create a campaign
var campaign = new Campaign()
{
    CampaignName = "Indepndent",
    SampleImage = "resources/images/sample.jpg",
    Logo = "resources/images/logo.png",
    Title = "MY IMPACT, OUR FUTURE",
    SubTitle = "Naveed Khan",
    ActivityUrl = "http://18.221.38.133:5300/Uploads/TrackingMethodIcon/HKActiveEnergyBurnIcon.png",
    NGOUrl = "http://18.221.38.133:5300/Uploads/User/Profile/default.png",
    PledgeAmount = "10000.00 $",
    PledgeAmountText = "$10K",
    ActivityName = "RUNNING",
    NGOName = "UNICEF",
    CampaignType = "Independent",
    CompletedProgressBar = 24,
    Ends = "July 1"
};

// make the objects
var firstTemplate = new FirstTemplate();
var secondTemplate = new SecondTemplate();

// generate the image
firstTemplate.Generate(campaign).Result.Save("resources/outputs/firstTemplate.jpg");
secondTemplate.Generate(campaign).Result.Save("resources/outputs/SecondTemplate.jpg");