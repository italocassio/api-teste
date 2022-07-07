using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api_auction._Base.json
{
    public class ResultReturnErros
    {
        public ResultReturnErros(List<string> result)
        {
            Result = result;
        }
        
        [JsonPropertyName("result")]
        public List<string> Result { get; set; }
        
    }
}