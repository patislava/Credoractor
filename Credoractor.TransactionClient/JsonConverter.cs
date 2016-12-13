using Newtonsoft.Json;

namespace Credoractor.TransactionClient
{
    class JsonConverter
    {
        public void WriteJsonToFile(object transaction)
        {
            //Convert transaction to json    
            string json = JsonConvert.SerializeObject(transaction);

            //Write string to file
            System.IO.File.WriteAllText(@".\transaction.json", json);
        }
    }
}
