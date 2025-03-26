using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices.Marshalling;
public class Program
{
    public static void Main(string[] args)
    {
        //Create addresses
        Address address1 = new Address("234 Elm St", "Springfield","IL","USA");
        Address address2 = new Address("450 Oak St", "Toronto", "ON","USA");
        
        //Create customers
        Customer customer1 = new Customer("Alice", address1);
        Customer customer2 = new Customer ("Bob", address2);

        //Create products
        Product product1 = new Product("Laptop","A123", 999.99m, 1);
        Product product2 = new Product("Mouse","B456", 19.99m, 2);
        Product product3 = new Product("Keyboard", "C789", 49.99m, 1);

        //Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        //Display results
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():F2}\n");
    }
}