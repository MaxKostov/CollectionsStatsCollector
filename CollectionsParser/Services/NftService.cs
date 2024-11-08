using System.Text.Json;
using RestSharp;

namespace CollectionsParser.Services;

    public class NftService
    {
        private readonly RestClient _client;
        private const string ApiUrl = "https://api.opensea.io/api/v2/collections/akidcalledbeast/stats";
        private readonly string _apiKey;

        public NftService()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") 
                .Build();
            
            _apiKey = config["ApiSettings:ApiKey"];
            
            var clientOptions = new RestClientOptions(ApiUrl);
            _client = new RestClient(clientOptions);
        }

        public async Task<NftStats> GetNftStatsAsync()
        {
            
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("x-api-key", _apiKey);

            try
            {
                
                var response = await _client.GetAsync(request);

                
                if (response.IsSuccessful && response.Content != null)
                {
                    var jsonOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true 
                    };
                    
                    var nftData = JsonSerializer.Deserialize<NftStats>(response.Content, jsonOptions);

                    if (nftData == null || nftData.Total == null || nftData.Intervals == null)
                    {
                        Console.WriteLine("Error: Deserialization returned null objects.");
                        return null;
                    }

                    return nftData;
                }
                else
                {
                    Console.WriteLine("Error: Failed to load NFT data.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching NFT data: {ex.Message}");
                return null;
            }
        }
    }