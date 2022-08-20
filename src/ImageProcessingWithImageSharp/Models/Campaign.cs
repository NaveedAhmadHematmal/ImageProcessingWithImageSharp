namespace ImageProcessingWithImageSharp.Models;

public class Campaign
{
    public string? SampleImage { get; set; }
    public string? CampaignName { get; set; }
    public string? Logo { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? ActivityUrl { get; set; }
    public string? ActivityName { get; set; }
    public string? NGOUrl { get; set; }
    public string? NGOName { get; set; }
    public string? PledgeAmount { get; set; }
    public string? CampaignType { get; set; } // for first template
    public string? PledgeAmountText { get; set; }
    public int CompletedProgressBar { get; set; }
    public string Ends { get; set; }
}