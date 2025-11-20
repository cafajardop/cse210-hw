using System;

class Program
{
    static void Main(string[] args)
    {        
        Address address1 = new Address(
            "Calle 45 #21-90",
            "Bogotá",
            "Cundinamarca",
            "Colombia");

        Customer customer1 = new Customer("Andres Martinez", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Coffee Bag Premium", "CF100", 12.50m, 3));
        order1.AddProduct(new Product("Arepa Pack", "AR200", 5.00m, 4));

        
        Address address2 = new Address(
            "Carrera 10 #15-60",
            "Medellín",
            "Antioquia",
            "Colombia");

        Customer customer2 = new Customer("Laura Gomez", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Headset X-Pro", "HS500", 45m, 1));
        order2.AddProduct(new Product("USB-C Cable", "CB250", 8m, 2));
        order2.AddProduct(new Product("Keyboard K70", "KB700", 60m, 1));


        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");

        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}