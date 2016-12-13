namespace Credoractor.TransactionClient
{
    interface ITransactionSender
    {
        void SendTransaction(object payload);
    }
}
