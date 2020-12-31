using System.Collections.Generic;
using Trade.Domain.Entities;
using Trade.Domain.Enums;
using Trade.Domain.Facade;

namespace Trade.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare vars
            ESector _private = ESector.Private;
            ESector _public = ESector.Public;
            List<Customer> _customers = new List<Customer>();

            //Customer´s data
            _customers.Add(new Customer("Warner Bros", 4000000.00m, _private));
            _customers.Add(new Customer("Will Smith", 300000.00m, _public));
            _customers.Add(new Customer("Gal Gadot", 600000.00m, _public));
            _customers.Add(new Customer("Morgan Freeman", 2500000.00m, _public));
            // Fail test
            //_customers.Add(new Customer("Marvel", 400000.00m, _private));

            //call facade class 
            FacadeCategories.RiskAnalysis(_customers);
        }
    }
}
