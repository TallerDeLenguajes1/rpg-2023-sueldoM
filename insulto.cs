using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JuegoRPG
{
public class Insulto
{
    [JsonProperty("number")]
    public string? Number { get; set; }

    [JsonProperty("language")]
    public string? Language { get; set; }

    [JsonProperty("insult")]
    public string? Insult { get; set; }

    [JsonProperty("created")]
    public string? Created { get; set; }

    [JsonProperty("shown")]
    public string? Shown { get; set; }

    [JsonProperty("createdby")]
    public string? CreatedBy { get; set; }

    [JsonProperty("active")]
    public string? Active { get; set; }

    [JsonProperty("comment")]
    public string? Comment { get; set; }
}
}

