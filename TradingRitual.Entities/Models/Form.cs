using System;
using System.Collections.Generic;
using System.Text;

namespace TradingRitual.Entities.Models
{
   public class Form
    {
        public Guid ID { get; set; }     
        public string MentalState { get; set; }
        public string DescribeTrade { get; set; }
        public string TradingTrend { get; set; } 
        public string TradingCriteria { get; set; }      
        public string AcceptanceType { get; set; } 
        public string RewardRatio { get; set; }
        public string MetDailyGoal { get; set; } 
        public string TradeStatus { get; set; } //remember to use Enum to replace or populate/fill this
        public string TradeOutcome { get; set; }
        public string ExplainTrade { get; set; }
        public string Note { get; set; } 
        
        public string PairPicked { get; set; } 
        public string StrategyPicked { get; set; } 
        public string ExitStrategy { get; set; }

    }

    enum MentalState
    {
        Great,
        Happy,
        Okay,
        Sad,
        Stressed,
        Revenge,
        Upset,
        MissedTrade
    }
    enum TradingTrend
    {
        Yes,
        No
    }
    enum Criteria
    {
        Yes,
        No
    }
    enum AcceptanceType
    {
        Yes,
        No
    }
    enum MetDailyGoal
    {
        Yes,
        No
    }

    enum TradeStatus
    {
        Win,
        Lose,
        BreakEven,
        Missed
    }
}
