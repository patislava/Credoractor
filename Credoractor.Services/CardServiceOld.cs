﻿using Credoractor.Models;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel.Attributes;

namespace Credoractor.Services
{
    public class CardServiceOld
    {
        public List<string> pans = new List<string>() { "4123688840000000", "5266000000000008" };

        public IList<CardModel> GetCards()
        {
            IList<CardModel> result = new List<CardModel>();

            for (int i = 0; i < pans.Count; i++)
            {
                if (pans[i].StartsWith("4"))
                {
                    result.Add(new CardModel(CardType.Visa, pans[i]));
                }
                else
                {
                    result.Add(new CardModel(CardType.MasterCard, pans[i]));
                }
            }
            return result;
        }
    }
}

