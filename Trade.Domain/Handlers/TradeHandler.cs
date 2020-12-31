using Trade.Domain.Handlers.Interfaces;
using Trade.Domain.Commands.Interfaces;
using Trade.Domain.Commands;

namespace Trade.Domain.Handlers
{
    public class TradeHandler : IHandler<TradeCommand>
    {
        private ICommandResult _genericCommandResult;

        public ICommandResult Handle(TradeCommand command)
        {
            IHandler<RiskAnalysisCommand> riskAnalysisHanlder;
            RiskAnalysisCommand riskAnalysisCommand = new RiskAnalysisCommand(0);

            command.Validate();
            if (command.Invalid)
            {
                _genericCommandResult = new GenericCommandResult(false, "Invalid Trade operation.", command.Notifications);
                return _genericCommandResult;
            }

            riskAnalysisCommand.Value = command.Value;

            switch (command.ClientSector)
            {
                case "Public":
                    {
                        riskAnalysisHanlder = new PublicRiskAnalysisHandler();
                        _genericCommandResult = riskAnalysisHanlder.Handle(riskAnalysisCommand);
                        break;
                    }
                case "Private":
                    {
                        riskAnalysisHanlder = new PrivateRiskAnalysisHandler();
                        _genericCommandResult = riskAnalysisHanlder.Handle(riskAnalysisCommand);
                        break;
                    }
            }

            return _genericCommandResult;
        }
    }
}