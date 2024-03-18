using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooExpenseTracker.Lib.Model
{
    public class Animal
    {
        public string Name { get; set; }

        public string AnimalType { get; set; }
        public decimal FoodRate { get; set; }
        public string FoodPreference { get; set; } // "meat", "fruit", or "both"
        public decimal MeatPercentage { get; set; } // Percentage of food rate covered with meat (for omnivores)
        public decimal WeightKg { get; set; }
    }
}
