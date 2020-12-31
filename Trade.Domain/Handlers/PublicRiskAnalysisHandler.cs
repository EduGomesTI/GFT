using Trade.Domain.Handlers.Interfaces;
using Trade.Domain.Commands.Interfaces;
using Trade.Domain.Commands;
using Trade.Domain.Enums;

namespace Trade.Domain.Handlers
{
    public class PublicRiskAnalysisHandler : IHandler<RiskAnalysisCommand>
    {
        private GenericCommandResult _genericCommandResult;
        public ICommandResult Handle(RiskAnalysisCommand command)
        {
            ERisk risk;            
            command.Validate();
            if (command.Invalid)
            {
                _genericCommandResult = new GenericCommandResult(false, "Invalid risk analysis", command.Notifications);
                return _genericCommandResult;
            }

            if (command.Value < 1000000m)
            {
                risk = ERisk.LOWRISK;
                _genericCommandResult = new GenericCommandResult(true, "Successfully risk analysis.", risk.ToString());
            }

            else if (command.Value >= 1000000m)
            {
                risk = ERisk.MEDIUMRISK;
                _genericCommandResult = new GenericCommandResult(true, "Successfully risk analysis.", risk.ToString());
            }

            return _genericCommandResult;

        }
    }
}