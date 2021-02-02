using System;
using System.Collections.Generic;
using System.Text;

namespace TradingRitual.Entities.Models
{
   public class Form
    {
        public Guid FormId { get; set; }
        public Guid TraderId { get; set; }
     
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
        
        public string PairPicked { get; set; } 
        public string StrategyPicked { get; set; } 
        public string ExitStrategy { get; set; }
        public string TimeOfTrade { get; set; }


    }

    public enum MentalState
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
    public enum TradingTrend
    {
        Yes,
        No
    }
    public enum Criteria
    {
        Yes,
        No
    }
    public enum AcceptanceType
    {
        Yes,
        No
    }
    public enum MetDailyGoal
    {
        Yes,
        No
    }

    public enum TradeStatus
    {
        Win,
        Lose,
        BreakEven,
        Missed
    }
}
