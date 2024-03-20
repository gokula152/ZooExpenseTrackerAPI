using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ZooExpenseTracker.Lib.Interface;
using ZooExpenseTracker.Lib.Model;

namespace ZooExpenseTracker.Lib.Services
{
    public class DataFileReader : IDataFileReader
    {
        public List<Animal> ReadAnimals(IFormFile animalsFile,  List<Animal>  animals)
        {
            try
            {
                using (StreamReader reader = new StreamReader(animalsFile.OpenReadStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        if (parts.Length == 4)
                        {
                            string name = parts[0].Trim();
                            decimal foodRate = Convert.ToDecimal(parts[1].Trim(), CultureInfo.InvariantCulture);
                            string foodPreference = parts[2].Trim();
                            decimal meatPercentage = !string.IsNullOrEmpty(parts[3].Trim()) ?
                                                     Convert.ToDecimal(parts[3].Trim().Substring(0, parts[3].Length - 1), CultureInfo.InvariantCulture) / 100 : 0;

                            foreach (var animal in animals.Where(animal => animal.AnimalType == name))
                            {
                                animal.FoodRate = foodRate;
                                animal.FoodPreference = foodPreference;
                                animal.MeatPercentage = meatPercentage;
                            }

                        }
                    }
                }
                return animals;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public FoodPrice ReadFoodPrices(IFormFile pricesFile)
        {
            try
            {
                var foodPrices = new FoodPrice();

                using (StreamReader reader = new StreamReader(pricesFile.OpenReadStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string foodType = parts[0].Trim();
                            var price = Convert.ToDecimal(parts[1].Trim(), CultureInfo.InvariantCulture);
                            if (foodType == "Meat")
                                foodPrices.MeatPricePerKg = price;
                            if (foodType == "Fruit")
                                foodPrices.FruitPricePerKg = price;
                        }
                    }
                }

                return foodPrices;

            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public List<Animal> ReadZoo(IFormFile zooFiles)
        {
            try
            {
                List<Animal> animals = new List<Animal>();


                XmlDocument doc = new XmlDocument();
                doc.Load(zooFiles.OpenReadStream());

                foreach (XmlNode animalNode in doc.DocumentElement.ChildNodes)
                {
                    string animalType = animalNode.Name;
                    foreach (XmlNode speciesNode in animalNode.ChildNodes)
                    {
                        Animal animal = new Animal();
                        animal.Name = speciesNode.Attributes["name"].Value;
                        animal.WeightKg = Convert.ToDecimal(speciesNode.Attributes["kg"].Value, CultureInfo.InvariantCulture);
                        animal.AnimalType = speciesNode.Name;
                        animals.Add(animal);
                    }
                }

                return animals;

            }
            catch(Exception e)
            {
                return null;
            }
                
            }
        }
}
