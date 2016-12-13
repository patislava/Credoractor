using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Collections.ObjectModel;

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
        public void SendTransaction(object payload) 
        {
            // //if (!payload.Equals(null))
            // {
            JsonConverter jsonConverter = new JsonConverter();
            jsonConverter.WriteJsonToFile(payload);

            //Run batch file
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName =
                @".\send_json.bat";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            ////Preparation of process to run
            //ProcessStartInfo transactorExeStart = new ProcessStartInfo();
            //transactorExeStart.FileName = Path;
            ////transactorExeStart.Arguments = @"direct .\transaction.json";
            ////transactorExeStart.CreateNoWindow = false;
            ////////transactorExeStart.RedirectStandardOutput = true;

            ////Run transactor.exe
            //////using (Process process = Process.Start(transactorExeStart))
            //////{
            //////    //TODO: transactor.exe doesn't close console when finished, so log reader should be implemented 
            //////    //to catch the moment when output file is not updated anymore.
            //////}
            //////// }
        }
    }
}
