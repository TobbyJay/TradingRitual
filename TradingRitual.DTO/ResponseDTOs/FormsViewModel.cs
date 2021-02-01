using System;
using System.Collections.Generic;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.DTO.ResponseDTOs
{
    public class FormsViewModel
    {
        public string StrategyUsed { get; set; }
        public string MentalState { get; set; }
        public string DescribeTrade { get; set; }
        public string TradingTrend { get; set; }
        public string TradingCriteria { get; set; }
        public string AcceptanceType { get; set; }
        public string RewardRatio { get; set; }
        public string MetDailyGoal { get; set; }
        public string TradeStatus { get; set; }
        public string TradeOutcome { get; set; }
        public string ExplainTrade { get; set; }
        public string Note { get; set; }
        public string AmountMadeOrLost { get; set; }
        public string PairPicked { get; set; }
        public string StrategyPicked { get; set; }
        public string ExitStrategy { get; set; }

        public string TimeOfTrade { get; set; }

    }
}
