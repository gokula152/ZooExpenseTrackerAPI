using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooExpenseTracker.Lib.Model;

namespace ZooExpenseTracker.Lib.Interface
{
    public interface IDataFileReader
    {
        FoodPrice ReadFoodPrices(IFormFile pricesFile);
        List<Animal> ReadAnimals(IFormFile animalsFile, List<Animal> animals);
        List<Animal> ReadZoo(IFormFile zooFile);
    }
}
