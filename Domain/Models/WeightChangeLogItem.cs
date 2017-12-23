using System;

namespace FatDairy.Domain.Models
{
    public class WeightChangeLogItem
    {
        public double OldValue { get; set; }
        public double NewValue { get; set; }
        public DateTime Date { get; set; }
    }
}
