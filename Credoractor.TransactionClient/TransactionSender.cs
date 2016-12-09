using Credoractor.Services;
using System;
using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Credoractor.Services.Purchase;
using Newtonsoft.Json;

namespace Credoractor.TransactionClient
{
    public class TransactionSender : ITransactionSender
    {
        public string Path { get; private set; }

        public TransactionSender(string path)
        {
            Path = path;

            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Parameter cannot be empty or null.");
            }

            if (path.Contains(":\\"))
            {
                Path = System.IO.Path.GetFullPath(path);
            }
        }

        //Create process which launches transactor.exe with payload passed as an argument ?? 
        public void SendTransaction(Transaction payload) 
        {
            if (!payload.Equals(null))
            {
                JsonConverter jsonConverter = new JsonConverter();
                jsonConverter.WriteJsonToFile(payload);

                TransactionSender transactionSender = new TransactionSender(Path);

                //Preparation of process to run
                ProcessStartInfo transactorExeStart = new ProcessStartInfo();
                transactorExeStart.Arguments = "direct .\\transaction.json";
                transactorExeStart.FileName = Path;
                transactorExeStart.CreateNoWindow = true;
                //transactorExeStart.RedirectStandardOutput = true;

                //Run transactor.exe
                using (Process process = Process.Start(transactorExeStart))
                {
                    //TODO: transactor.exe doesn't close console when finished, so log reader should be implemented 
                    //to catch the moment when output file is not updated anymore.
                }
            }
        }
    }
}
