using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services
{
    public class TagField
    {
        public string TagId { get; set; }
        public string Value { get; set; }

        public TagField(string tagId, string value)
        {
            TagId = tagId;
            Value = value;
        }
    }
}
