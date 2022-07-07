using System.Text.Json.Serialization;

namespace api_auction._Base.json
{
    public class ResultReturn
    {
        public ResultReturn(string result)
        {
            Result = result;
        }
        
        [JsonPropertyName("result")]
        public string Result { get; set; }
        
    }
}