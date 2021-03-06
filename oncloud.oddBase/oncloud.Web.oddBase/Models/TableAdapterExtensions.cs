﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oncloud.Domain.Concrete;

namespace oncloud.Web.oddBase.Models
{
    public class TableAdapterExtensions
    {
        public static int Increment()
        {
            int result;
            int valueInrement;

            using (EFDbContext context = new EFDbContext())
            {

                result = context.Increment.First().Counter;
                valueInrement = result;

                context.Increment.First().Counter = ++valueInrement;
                context.SaveChanges();
            }
            return result;
        }

        public static string StringSymvol(string TypeConstruction = "BB")
        {
            using (EFDbContext context = new EFDbContext())
            {
                if (context.ListUniqueNumber.Any())
                {
                    string ListId= context.ListUniqueNumber.Select(a=>a.UniqueNumber).First();
                    context.ListUniqueNumber.Remove(context.ListUniqueNumber.First());
                    context.SaveChanges();
                    return ListId;
                }
            }
            string SymbolString = "";
            int number = Increment();
            for (int s = 8; s > number.ToString().Length; s--)
            {
                SymbolString = "0" + SymbolString;
            }
            var ValueString = TypeConstruction + SymbolString + number;
            return ValueString;
        }
    }
}