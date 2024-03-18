using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooExpenseTracker.Lib.Interface;
using ZooExpenseTracker.Lib.Model;

namespace ZooExpenseTracker.Lib.Services
{
    public class FileValidation : IFileValidation
    {
        public Dictionary<bool, string> ValidateFileAsync(FileInputModel model)
        {
            try
            {
                var textValidationResult = ValidateFile(model?.PricesFile, ".txt");
                var csvValidationResult = ValidateFile(model?.AnimalsFile, ".csv");
                var xmlValidationResult = ValidateFile(model?.ZooFile, ".xml");


                if (textValidationResult != null && textValidationResult.ContainsKey(false))
                    return textValidationResult;

                else if (csvValidationResult != null && csvValidationResult.ContainsKey(false))
                    return csvValidationResult;

                else if (csvValidationResult != null && xmlValidationResult.ContainsKey(false))
                    return xmlValidationResult;
                else if (textValidationResult == null && csvValidationResult == null && xmlValidationResult == null)
                    return null;

                else
                {
                    var validatedOutput = new Dictionary<bool, string>();
                    validatedOutput.Add(true, "Validated");
                    return validatedOutput;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        private Dictionary<bool, string> ValidateFile(IFormFile file, string expectedExtension)
        {
            try
            {
                var validatedOutput = new Dictionary<bool, string>();

                if (file.Length == 0)
                {
                    validatedOutput.Add(false, "File is empty.");
                    return validatedOutput;
                }

                if (Path.GetExtension(file.FileName) != expectedExtension)
                {
                    validatedOutput.Add(false, $"{file.Name} expected the file in {expectedExtension} filetype, Please correct fileformat");
                    return validatedOutput;
                }

                else
                {
                    validatedOutput.Add(true, "ValidatedSuccessfully");
                    return validatedOutput;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

       
    }
}
