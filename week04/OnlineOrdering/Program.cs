using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        //Create addresses
        Address address1 = new Address("234 Elm St", "Springfield","IL","USA");
        Address address2 = new Address("450 Oak St", "Toronto", "ON","USA");
        Address canadaAddress = new Address("456 Oak Avenue","Toronto", "ON", "Canada");

        //Create customers
        Customer customer1 = new Customer("Alice", address1);
        Customer customer2 = new Customer ("Bob", address2);
        Customer canadaCustomer = new Customer ("Jane",canadaAddress);

        //Create products
        Product product1 = new Product("Laptop", "A123", 999.99m, 1);
        Product product2 = new Product("Mouse", "B456", 19.99m, 2);
        Product product3 = new Product("Keyboard", "C789", 49.99m, 1);

        //Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product2);

        Order order3 = new Order(canadaCustomer);
        order3.AddProduct(product3);
        order3.AddProduct(product1);

        //Display Order Details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
        DisplayOrderDetails(order3);
    }

    static void DisplayOrderDetails(Order order)

        {
        Console.WriteLine("==============================");
        Console.WriteLine($"Get Order for Customer: {order.GetCustomer().GetName()}");
        Console.WriteLine(order.GetPackingLabel()); 
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Shipping Cost: ${(order.GetCustomer().IsInUSA() ? 5 : 35)}");
        Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}\n");
        Console.WriteLine("===============================");
        }
}