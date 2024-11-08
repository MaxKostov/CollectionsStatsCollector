using System.Text.Json.Serialization;
using System.Collections.Generic;

public class TotalStats
{
    [JsonPropertyName("volume")]
    public double Volume { get; set; }

    [JsonPropertyName("sales")]
    public int Sales { get; set; }

    [JsonPropertyName("average_price")]
    public double AveragePrice { get; set; }

    [JsonPropertyName("num_owners")]
    public int NumOwners { get; set; }

    [JsonPropertyName("market_cap")]
    public double MarketCap { get; set; }

    [JsonPropertyName("floor_price")]
    public double FloorPrice { get; set; }

    [JsonPropertyName("floor_price_symbol")]
    public string FloorPriceSymbol { get; set; }
}

public class IndividualStats
{
    [JsonPropertyName("interval")]
    public string Interval { get; set; }

    [JsonPropertyName("volume")]
    public double Volume { get; set; }

    [JsonPropertyName("volume_diff")]
    public double VolumeDiff { get; set; }

    [JsonPropertyName("volume_change")]
    public double VolumeChange { get; set; }

    [JsonPropertyName("sales")]
    public int Sales { get; set; }

    [JsonPropertyName("sales_diff")]
    public double SalesDiff { get; set; }

    [JsonPropertyName("average_price")]
    public double AveragePrice { get; set; }
}

public class NftStats
{
    [JsonPropertyName("total")]
    public TotalStats Total { get; set; }

    [JsonPropertyName("intervals")]
    public List<IndividualStats> Intervals { get; set; }
}