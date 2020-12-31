using System;
using System.Collections.Generic;
using Trade.Domain.Entities;
using Trade.Domain.Handlers;
using Trade.Domain.Commands;

namespace Trade.Domain.Facade
{
    public static class FacadeCategories
    {
        public static void RiskAnalysis(List<Customer> customers)
        {
            GenericCommandResult result = new GenericCommandResult();
            var tradeCategories = new List<String>();

            

            foreach (var customer in customers)
            {
                result = RiskAnalysisHandler(customer);
                if(result.Sucess)
                    tradeCategories.Add(result.Data.ToString());
                else
                    tradeCategories.Add(result.Message);
            }

            //Print output categories
            //     foreach (string tradeCategorie in tradeCategories)
            //     {
            Console.WriteLine($"tradeCategories = {String.Join(", ", tradeCategories)}");
            //     }
        }

        private static GenericCommandResult RiskAnalysisHandler(Customer customer)
        {
            TradeHandler trade = new TradeHandler();

            TradeCommand tradeCommand = new TradeCommand(customer);

            return (GenericCommandResult)trade.Handle(tradeCommand);
        }

    }
}