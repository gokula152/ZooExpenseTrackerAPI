using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooExpenseTracker.Lib.Model;

namespace ZooExpenseTracker.Lib.Interface
{
    public interface IFeedingCostCalculator
    {
        PriceOutputResponse CalculateFeedingCost(FoodPrice foodPrices,List<Animal> animalsList);
    }
}
