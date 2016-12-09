using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credoractor.Services;
using Newtonsoft.Json;

namespace Credoractor.TransactionClient
{
    class JsonConverter
    {
        public void WriteJsonToFile(Transaction transaction)
        {
            //Convert transaction to json    
            string json = JsonConvert.SerializeObject(transaction);

            //Write string to file
            System.IO.File.WriteAllText(@".\transaction.json", json);
        }
    }
}
