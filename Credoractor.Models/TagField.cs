using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Credoractor.Services
{
    public class TagField
    {
        [JsonProperty(PropertyName = "TagId")]
        public string TagId { get; set; }

        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }

        public TagField(string tagId, string value)
        {
            TagId = tagId;
            Value = value;
        }
    }
}
