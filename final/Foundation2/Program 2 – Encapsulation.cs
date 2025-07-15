using System;
using System.Collections.Generic;

// Represents a product in an order
class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    // Constructor sets initial product info
    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _productId = id;
        _price = price;
        _quantity = quantity;
    }

    // Returns total price for the quantity ordered
    public double GetTotalPrice()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetQuantity()
    {
        return _quantity;
    }
}

// Represents a customer's mailing address
class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructor sets address info
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Determines if the address is in the USA
    public bool IsUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Returns a formatted address
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

// Represents a customer placing the order
class Customer
{
    private string _name;
    private Address _address;

    // Constructor sets the customer's name and address
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    // Determines if the customer lives in the USA
    public bool LivesInUSA()
    {
        return _address.IsUSA();
    }
}

// Represents an order with products and a customer
class Order
{
    private Customer _customer;
    private List<Product> _products;

    // Constructor links the customer to the order
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Adds a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculates the total order price including shipping
    public double GetTotalPrice()
    {
        double subtotal = 0;
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalPrice();
        }

        double shipping = _customer.LivesInUSA() ? 5.00 : 35.00;
        return subtotal + shipping;
    }

    // Returns a packing label listing products and quantities
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"- {product.GetName()} (x{product.GetQuantity()})\n";
        }
        return label;
    }

    // Returns a formatted shipping label with customer name and address
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}

// Main program to test the encapsulation concept
class Program
{
    static void Main(string[] args)
    {
        // US customer
        Address address1 = new Address("123 Treehouse Ln", "Saint Anthony", "ID", "USA");
        Customer customer1 = new Customer("Jacob Loveland", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("PLA Filament", "PLA1001", 19.99, 2));
        order1.AddProduct(new Product("Stepper Motor", "STM500", 8.50, 4));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalPrice():F2}\n");

        // International customer
        Address address2 = new Address("99 Builder Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jonathan Carpenter", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Servo", "SRV200", 12.99, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalPrice():F2}");
    }
}
