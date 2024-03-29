# ZooExpenseTrackerAPI
# Overview

ZooExpenseTrackerAPI is a .NET Core Web API project developed to calculate the daily cost of feeding animals in a zoo based on their types and weights.

# Table of Contents
Installation

Endpoints

Request & Response Examples

Error Handling

Testing

Dependencies

# Installation

To use ZooExpenseTrackerAPI, follow these steps:

Clone the repository from GitHub:

git clone https://github.com/gokula152/ZooExpenseTrackerAPI.git

# Endpoints
Calculate Total Feeding Cost

**URL**: /api/feedingcost

**Method**: POST

**Description**: Calculates the total feeding cost for all animals in the zoo.

**Pesponse**: Total feeding cost in JSON format.

**Request & Response Examples**

**Request:**
http

POST /api/feeding-cost HTTP/1.1

Host: localhost:7041

**Response:**
json


{
  "costPerAnimalType": [
    {
      "name": "Simba",
      "animalType": "Lion",
      "numberofAnimals": 1,
      "totalDecimalCost": 200.96
    }
  ],
  "totalDecimalCost": 1609.00896
}


# Error Handling

ZooExpenseTrackerAPI handles errors gracefully and returns appropriate HTTP status codes along with error messages in the response body.

# Testing

The project includes unit tests to ensure the correctness of the feeding cost calculation logic. To run the tests.

# Dependencies
ZooExpenseTrackerAPI relies on the following dependencies:

.NET Core 6.0

Swashbuckle.AspNetCore(Swagger Endpoint)

Microsoft.AspNetCore.Http.Features(using IFormFile)

xUnit (for unit testing)
