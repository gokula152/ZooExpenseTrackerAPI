using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooExpenseTracker.Lib.Interface;
using ZooExpenseTracker.Lib.Model;

namespace ZooExpenseTracker.Lib.Services
{
    public class FeedingCostCalculator : IFeedingCostCalculator    {

        public PriceOutputResponse CalculateFeedingCost(FoodPrice foodPrices, List<Animal> animalsList)
        {
            try
            {
                var totalCost = 0M;
                var priceOutputResponse = new PriceOutputResponse();
                var costPerAnimals = new List<CostPerAnimalType>();
                foreach (var animal in animalsList)
                {
                    decimal foodCost = 0;
                    var costPerAnimal = new CostPerAnimalType();
                    if (animal.FoodPreference == "meat")
                    {
                        foodCost = animal.FoodRate * foodPrices.MeatPricePerKg * animal.WeightKg;
                    }
                    else if (animal.FoodPreference == "fruit")
                    {
                        foodCost = animal.FoodRate * foodPrices.FruitPricePerKg * animal.WeightKg;
                    }
                    else if (animal.FoodPreference == "both")
                    {
                        var meatCost = animal.FoodRate * foodPrices.MeatPricePerKg * animal.WeightKg * animal.MeatPercentage;
                        var fruitCost = animal.FoodRate * foodPrices.FruitPricePerKg * animal.WeightKg * (1 - animal.MeatPercentage);
                        foodCost = meatCost + fruitCost;
                    }

                    totalCost += foodCost;

                    costPerAnimal.Name = animal.Name;
                    costPerAnimal.TotalDecimalCost = foodCost;
                    costPerAnimal.NumberofAnimals++;
                    costPerAnimal.AnimalType = animal.AnimalType;
                    costPerAnimals.Add(costPerAnimal);
                }
                priceOutputResponse.TotalDecimalCost = totalCost;
                priceOutputResponse.CostPerAnimalType = costPerAnimals;

                return priceOutputResponse;
            }
            catch (Exception ex)
            {
                return null;
            }           

        }
    }
}
