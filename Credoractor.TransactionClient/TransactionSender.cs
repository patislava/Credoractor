using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Text;

namespace Credoractor.TransactionClient
{
    public class TransactionSender : ITransactionSender
    {
        public string Path { get; private set; }

        public TransactionSender()
        {
            
        }
        //string path
        //{
        //    Path = path;

        //    if (string.IsNullOrEmpty(path))
        //    {
        //        throw new ArgumentException("Parameter cannot be empty or null.");
        //    }

        //    //if (!File.Exists(path))
        //    //{
        //    //    throw new System.ComponentModel.Win32Exception();
        //    //}

        //    if (path.Contains(":\\"))
        //    {
        //        Path = System.IO.Path.GetFullPath(path);
        //    }
        //}

        public void SendTransaction(object payload, string path)
        {
            Path = path;

            if (payload.Equals(null))
            {
                throw new ArgumentNullException("There is no transaction data to send.");
            }

            //Convert payload to json
            JsonConverter jsonConverter = new JsonConverter();
            jsonConverter.WriteJsonToFile(payload);

            //Run batch file
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = Path;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.WaitForExit();
        }

        public string GetTransactionResult()
        {            
            string logPath = ConfigurationManager.AppSettings["logPath"];
            var result = File.ReadAllText(logPath, Encoding.UTF8);

            return result;
        }
    }
}
