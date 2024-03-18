using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;
using ZooExpenseTracker.Lib.Interface;
using ZooExpenseTracker.Lib.Model;
using ZooExpenseTracker.Lib.Services;

namespace ZooExpenseTracker.Tests
{
    public class FeedingCostCalculatorTests
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public FeedingCostCalculatorTests()
        {

            ServiceProvider = new ServiceCollection().
                 AddSingleton<IFeedingCostCalculator, FeedingCostCalculator>().BuildServiceProvider();            

        }
        [Fact]
        public void CalculateFeedingCost_WhenFoodPreferenceIsMeat_ShouldCalculateCorrectly()
        {
            // Arrange
            var foodPrices = new FoodPrice
            {
                MeatPricePerKg = 10,
                FruitPricePerKg = 5
            };
            var animalsList = new List<Animal>
            {
                new Animal
                {
                    Name = "Simba",
                    AnimalType = "Lion",
                    FoodPreference = "meat",
                    FoodRate = 2,
                    WeightKg = 100,
                    MeatPercentage = 0
                }
            };
            var feedingCostCalculator = ServiceProvider.GetRequiredService<IFeedingCostCalculator>();

            // Act
            var result = feedingCostCalculator.CalculateFeedingCost(foodPrices, animalsList);

            // Assert
            Assert.Equal(2000, result.TotalDecimalCost);
            Assert.Single(result.CostPerAnimalType);
            Assert.Equal("Simba", result.CostPerAnimalType[0].Name);
            Assert.Equal(2000, result.CostPerAnimalType[0].TotalDecimalCost);
            Assert.Equal(1, result.CostPerAnimalType[0].NumberofAnimals);
            Assert.Equal("Lion", result.CostPerAnimalType[0].AnimalType);
        }

        [Fact]
        public void CalculateFeedingCost_WhenFoodPreferenceIsFruit_ShouldCalculateCorrectly()
        {
            // Arrange
            var foodPrices = new FoodPrice
            {
                MeatPricePerKg = 10,
                FruitPricePerKg = 5
            };
            var animalsList = new List<Animal>
            {
                new Animal
                {
                    Name = "Tiku",
                    FoodPreference = "fruit",
                    AnimalType ="Monkey",
                    FoodRate = 3,
                    WeightKg = 50,
                    MeatPercentage = 0
                }
            };
            var feedingCostCalculator = ServiceProvider.GetRequiredService<IFeedingCostCalculator>();

            // Act
            var result = feedingCostCalculator.CalculateFeedingCost(foodPrices, animalsList);

            // Assert
            Assert.Equal(750, result.TotalDecimalCost);
            Assert.Single(result.CostPerAnimalType);
            Assert.Equal("Tiku", result.CostPerAnimalType[0].Name);
            Assert.Equal(750, result.CostPerAnimalType[0].TotalDecimalCost);
            Assert.Equal(1, result.CostPerAnimalType[0].NumberofAnimals);
            Assert.Equal("Monkey", result.CostPerAnimalType[0].AnimalType);
        }

        [Fact]
        public void CalculateFeedingCost_WhenFoodPreferenceIsBoth_ShouldCalculateCorrectly()
        {
            // Arrange
            var foodPrices = new FoodPrice
            {
                MeatPricePerKg = 10,
                FruitPricePerKg = 5
            };
            var animalsList = new List<Animal>
            {
                new Animal
                {
                    Name = "Panda",
                    FoodPreference = "both",
                    AnimalType = "Bear",
                    FoodRate = 4,
                    WeightKg = 200,
                    MeatPercentage = 0.5M
                }
            };
            var feedingCostCalculator = new FeedingCostCalculator();

            // Act
            var result = feedingCostCalculator.CalculateFeedingCost(foodPrices, animalsList);

            // Assert
            Assert.Equal(6000, result.TotalDecimalCost);
            Assert.Single(result.CostPerAnimalType);
            Assert.Equal("Panda", result.CostPerAnimalType[0].Name);
            Assert.Equal(6000, result.CostPerAnimalType[0].TotalDecimalCost);
            Assert.Equal(1, result.CostPerAnimalType[0].NumberofAnimals);
            Assert.Equal("Bear", result.CostPerAnimalType[0].AnimalType);
        }

        [Fact]
        public void CalculateFeedingCost_WhenMultipleAnimals_ShouldCalculateCorrectly()
        {
            // Arrange
            var foodPrices = new FoodPrice
            {
                MeatPricePerKg = 10,
                FruitPricePerKg = 5
            };
            var animalsList = new List<Animal>
            {
                new Animal
                {
                    Name = "Lion",
                    FoodPreference = "meat",
                    FoodRate = 2,
                    WeightKg = 100,
                    MeatPercentage = 1
                },
                new Animal
                {
                    Name = "Monkey",
                    FoodPreference = "fruit",
                    FoodRate = 3,
                    WeightKg = 50,
                    MeatPercentage = 0
                },
                new Animal
                {
                    Name = "Bear",
                    FoodPreference = "both",
                    FoodRate = 4,
                    WeightKg = 200,
                    MeatPercentage = 0.5M
                }
            };
            var feedingCostCalculator = ServiceProvider.GetRequiredService<IFeedingCostCalculator>();

            // Act
            var result = feedingCostCalculator.CalculateFeedingCost(foodPrices, animalsList);

            // Assert
            Assert.Equal(8750, result.TotalDecimalCost);
            Assert.Equal(3, result.CostPerAnimalType.Count);
            Assert.Equal("Lion", result.CostPerAnimalType[0].Name);
            Assert.Equal(2000, result.CostPerAnimalType[0].TotalDecimalCost);
            Assert.Equal(1, result.CostPerAnimalType[0].NumberofAnimals);
            Assert.Equal("Monkey", result.CostPerAnimalType[1].Name);
            Assert.Equal(750, result.CostPerAnimalType[1].TotalDecimalCost);
            Assert.Equal(1, result.CostPerAnimalType[1].NumberofAnimals);
            Assert.Equal("Bear", result.CostPerAnimalType[2].Name);
            Assert.Equal(6000, result.CostPerAnimalType[2].TotalDecimalCost);
            Assert.Equal(1, result.CostPerAnimalType[2].NumberofAnimals);
        }

        [Fact]
        public void CalculateFeedingCost_WhenNoAnimals_ShouldReturnZeroCost()
        {
            // Arrange
            var foodPrices = new FoodPrice
            {
                MeatPricePerKg = 10,
                FruitPricePerKg = 5
            };
            var animalsList = new List<Animal>();
            var feedingCostCalculator = new FeedingCostCalculator();

            // Act
            var result = feedingCostCalculator.CalculateFeedingCost(foodPrices, animalsList);

            // Assert
            Assert.Equal(0, result.TotalDecimalCost);
            Assert.Empty(result.CostPerAnimalType);
        }
    }
}
