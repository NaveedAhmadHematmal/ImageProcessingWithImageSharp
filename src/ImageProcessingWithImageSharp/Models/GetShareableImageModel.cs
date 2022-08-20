using System.ComponentModel;

namespace ImageProcessingWithImageSharp.Models;

public class GetShareableImageModel
    {
        public int CampaignTypeId { get; set; }
        public string CampaignType
        {
            get
            {
                return ((CampaignType)CampaignTypeId).ToString();
            }
        }
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public string CampaignCreatorUsername { get; set; }
        public string CampaignStartDate { get; set; }
        public string CampaignEndDate { get; set; }
        public double CampaignPledgeAmount { get; set; }
        public double CampaignTotalPledgeAmount { get; set; }
        public string CampaignProgress { get; set; }
        public string CampaignProgressPercentage { get; set; }
        public string CampaignCoverPictureUrl { get; set; }
        public string TrackingMethodName { get; set; }
        public string TrackingMethodIconPictureUrl { get; set; }
        public string	FoundationName { get; set; }
        public string FoundationLogoPictureUrl { get; set; }
        public string CampaignPledgeAmountText { get; set; }
        public string CampaignTotalPledgeAmountText { get; set; }
}

public enum CampaignType
{
    [Description("Independent")]
    Independent = 1,

    [Description("Social")]
    Social = 2,
}