namespace Credoractor.TransactionClient
{
    public interface ITransactionSender
    {
        void SendTransaction(object payload);

        string GetTransactionResult();
    }
}
