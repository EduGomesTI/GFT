using Flunt.Notifications;
using Trade.Domain.Commands.Interfaces;
using Trade.Domain.Interfaces;
using Trade.Domain.Entities;

namespace Trade.Domain.Commands
{
    public class TradeCommand : Notifiable, ICommand, ITrade
    {
        private Customer _customer;
        public TradeCommand(Customer customer)
        {
            _customer = customer;
            Value = _customer.TradeAmount;
            ClientSector = _customer.Sector.ToString();
        }

        public decimal Value { get; }
        public string ClientSector { get; }

        public void Validate()
        {
            AddNotifications(_customer.Notifications);
        }
    }
}