// See https://aka.ms/new-console-template for more information

using System.Reflection;
using WebAPIClient;

Console.WriteLine("API Client");
EmployeeClient.CallGetAllEmployee().Wait();
EmployeeClient.AddnewEmployee().Wait();
Console.ReadLine();