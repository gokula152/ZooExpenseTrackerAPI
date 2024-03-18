using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ZooExpenseTracker.Lib.Model
{
    public class PriceOutputResponse
    {
        public List<CostPerAnimalType> CostPerAnimalType { get; set; }

        public decimal TotalDecimalCost { get; set; }
    }

    public class CostPerAnimalType
    {
        public string Name { get; set; }

        public string AnimalType { get; set; }

        public int NumberofAnimals { get; set; }

        public decimal TotalDecimalCost { get; set; }
    }

}
