using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Treehouse Ln", "Saint Anthony", "ID", "USA");
        Customer customer1 = new Customer("Jacob Loveland", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("PLA Filament", "PLA1001", 19.99, 2));
        order1.AddProduct(new Product("Stepper Motor", "STM500", 8.50, 4));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalPrice():F2}\n");

        Address address2 = new Address("99 Builder Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jonathan Carpenter", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Servo", "SRV200", 12.99, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalPrice():F2}");
    }
}
