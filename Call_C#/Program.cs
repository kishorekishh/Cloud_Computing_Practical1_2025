﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            var client = new HttpClient();
            var apiUrl = "http://localhost:3000/convert";
            
            // Create the request body with correct JSON format
            var requestBody = new
            {
                amount_in_rs = 1000
            };
            var jsonRequestBody = System.Text.Json.JsonSerializer.Serialize(requestBody);

            // Send an HTTP POST request to the API with the request body
            var response = await client.PostAsync(apiUrl, new StringContent(jsonRequestBody, Encoding.UTF8, "application/json"));

            // Check the response status code
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Response Code: " + response.StatusCode);
                Console.WriteLine("Response Body: " + await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
                Console.WriteLine("Details: " + await response.Content.ReadAsStringAsync());
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}