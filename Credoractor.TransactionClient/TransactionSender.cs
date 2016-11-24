using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.Diagnostics;

namespace Credoractor.TransactionClient
{
    public class TransactionSender : ITransactionSender
    {
        private string path;

        public TransactionSender(string path)
        {
            this.path = path;
            path = ".\\transactor.exe";
            string absolutePath = System.IO.Path.GetFullPath(path);
            path = absolutePath;
        }

        //Create process which launches transactor.exe with payload passed as an argument
        public void SendTransaction(string payload)
        {
            TransactionSender transactionSender = new TransactionSender(path);

            //Preparation of process to run
            ProcessStartInfo transactorExeStart = new ProcessStartInfo();
            transactorExeStart.Arguments = " direct .\\transaction.json";
            transactorExeStart.FileName = path;

            //Run transactor.exe and wait for it to finish
            using (Process process = Process.Start(transactorExeStart))
            {
                process.WaitForExit();
            }
        }
    }
}
