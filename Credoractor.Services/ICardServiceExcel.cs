using System.Collections.Generic;
using Credoractor.Models;

namespace Credoractor.Services
{
    public interface ICardServiceExcel
    {
        IList<CardModel> GetCardBasicInfo(string dataPath);
    }
}