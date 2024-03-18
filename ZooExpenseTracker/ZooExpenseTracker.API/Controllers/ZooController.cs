using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using ZooExpenseTracker.Lib.Interface;
using ZooExpenseTracker.Lib.Model;

namespace ZooExpenseTracker.API.Controllers
{
    public class ZooController : ControllerBase
    {
        public IFileValidation _validateFile;
        public IDataFileReader _dataFileReader;
        public IFeedingCostCalculator _feedingCostCalculator;
        public ZooController(IFileValidation validateFile, IDataFileReader dataFileReader, IFeedingCostCalculator feedingCostCalculator) {
        
            _validateFile = validateFile;
            _dataFileReader = dataFileReader;
            _feedingCostCalculator = feedingCostCalculator;
        }
        [HttpPost("feeding-cost")]
        public ActionResult<decimal> CalculateFeedingCost([FromForm] FileInputModel model)
        {
            try
            {
                if (model == null || model.PricesFile == null || model.AnimalsFile == null || model.ZooFile == null)
                {
                    return BadRequest("Files were not provided.");
                }

                var ValidationResult = _validateFile.ValidateFileAsync(model);
                if (ValidationResult == null)
                    return BadRequest("Please provide the validate data to calculate the TotalPrice");
                else if (ValidationResult != null && ValidationResult.ContainsKey(false))                
                    return BadRequest(ValidationResult[false]);
                
                var foodPrice = _dataFileReader.ReadFoodPrices(model.PricesFile);
                var zooAnimals = _dataFileReader.ReadZoo(model.ZooFile);
                var animals = _dataFileReader.ReadAnimals(model.AnimalsFile, zooAnimals);

                if(foodPrice != null && animals != null) {
                    var totalCost = _feedingCostCalculator.CalculateFeedingCost(foodPrice, animals);
                    return Ok(totalCost);
                }
                return BadRequest("Please provide the validate data to calculate the TotalPrice");
            }
            catch (Exception ex)
            {
                return BadRequest("System Error, Please contact the admin");
            }
            
        }
        
        
    }
}
