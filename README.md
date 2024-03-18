# ZooFeedingCostAPI
Overview
ZooFeedingCostAPI is a .NET Core Web API project developed to calculate the daily cost of feeding animals in a zoo based on their types and weights.

Table of Contents
Installation
Usage
Endpoints
Request & Response Examples
Error Handling
Testing
Dependencies

Installation
To use ZooFeedingCostAPI, follow these steps:

Clone the repository from GitHub:

bash
Copy code
git clone https://github.com/yourusername/ZooFeedingCostAPI.git
Navigate to the project directory:

bash
Copy code
cd ZooFeedingCostAPI
Build the project:

Copy code
dotnet build
Run the project:

arduino
Copy code
dotnet run
Usage
ZooFeedingCostAPI exposes endpoints to calculate the daily feeding cost for animals in the zoo. It requires input data files in specific formats (prices.txt, animals.csv, zoo.xml) to perform the calculations.

Endpoints
Calculate Total Feeding Cost
URL: /api/feedingcost
Method: POST
Description: Calculates the total feeding cost for all animals in the zoo.
Parameters: None
Response: Total feeding cost in JSON format.
Request & Response Examples
Request
http
Copy code
POST /api/feedingcost HTTP/1.1
Host: localhost:5000
Response
json
Copy code
{
  "totalCost": 1234.56
}
Error Handling
ZooFeedingCostAPI handles errors gracefully and returns appropriate HTTP status codes along with error messages in the response body.

Testing
The project includes unit tests to ensure the correctness of the feeding cost calculation logic. To run the tests, use the following command:

bash
Copy code
dotnet test
Dependencies
ZooFeedingCostAPI relies on the following dependencies:

.NET Core 6.
xUnit (for unit testing)
