using Flunt.Notifications;
using Flunt.Validations;
using Trade.Domain.Commands.Interfaces;

namespace Trade.Domain.Commands
{
    public class RiskAnalysisCommand : Notifiable, ICommand
    {
        public RiskAnalysisCommand(decimal value)
        {
           Value = value;
        }

        public decimal Value { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .IsGreaterThan(Value, 0, "Value", "Valor inválido. Deve ser mair que 0.")
            );
        }
    }
}