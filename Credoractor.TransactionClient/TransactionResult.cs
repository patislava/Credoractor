using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.TransactionClient
{
    public class TransactionResult
    {
        private DateTime lastFileWriteTime;
        //string path = @".\powerShellLog.txt";

        public DateTime GetLastLogWriteTime(string path)
        {
            var lastFileUpdate = File.GetLastWriteTime(path);
            return lastFileUpdate;
        }

        public string GetTransactionResult(string path)
        {
            
            var result = File.ReadAllText(path, Encoding.UTF8);

            return result;
        }
    }
}
