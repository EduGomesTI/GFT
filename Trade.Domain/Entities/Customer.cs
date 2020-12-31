using Flunt.Validations;
using Trade.Domain.Enums;

namespace Trade.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public decimal TradeAmount { get; private set; }
        public ESector Sector { get; private set; }

        public Customer(string name, decimal tradeAmount, ESector sector)
        {
            ChangeName(name);
            ChangeTradeAmount(tradeAmount);
            Sector = sector;
        }

        public void ChangeName(string name)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(name, 3, "Name", "Name deve conter pelo menos 3 caracteres.")
                .HasMaxLen(name, 20, "Name", "Name deve conter no máximo 20 caracteres.")
            );
            Name = name;
        }

        public void ChangeTradeAmount(decimal tradeAmount)
        {
            AddNotifications(
                new Contract()
                .IsGreaterThan(tradeAmount, 0, "TradeAmount", "TradeAMount deve ser maior que 0.")
            );
            TradeAmount = tradeAmount;            
        }
    }
}