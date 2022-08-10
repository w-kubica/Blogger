using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace Blogger.Domain.Cosmos
{
    [CosmosCollection("posts")]
    public class CosmosPost
    {
        [CosmosPartitionKey]
        [JsonProperty]
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
