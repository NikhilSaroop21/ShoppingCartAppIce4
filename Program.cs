using System;

namespace ShoppingCartApp
{
	public enum ProductCategory
	{
		Clothing, Electronics, Home, Beauty, Groceries
	}

	public class Product
	{
		private string name;
		private double price;
		private ProductCategory category;

		public string Name { get => name; }
		public double Price { get => price; }
		public ProductCategory Category { get => category; }

		public Product(string name, double price, ProductCategory category)
		{
			this.name = name;
			this.price = price;
			this.category = category;
		}

		public virtual void GetInfo()
		{
			Console.WriteLine($"Name: {name}, Price: {price:C}, Category: {category}");
		}
	}

	public class ClothingProduct : Product
	{
		private readonly string size;
		private readonly string color;

		public string Size { get => size; }
		public string Color { get => color; }

		public ClothingProduct(string name, double price, ProductCategory category, string size, string color)
			: base(name, price, category)
		{
			this.size = size;
			this.color = color;
		}

		public override void GetInfo()
		{
			base.GetInfo();
			Console.WriteLine($"Size: {size}, Color: {color}");
		}
	}

	public class ElectronicsProduct : Product
	{
		private readonly string brand;
		private readonly string model;

		public string Brand { get => brand; }
		public string Model { get => model; }

		public ElectronicsProduct(string name, double price, ProductCategory category, string brand, string model)
			: base(name, price, category)
		{
			this.brand = brand;
			this.model = model;
		}

		public override void GetInfo()
		{
			base.GetInfo();
			Console.WriteLine($"Brand: {brand}, Model: {model}");
		}
	}

	public class ShoppingCart
	{
		private Product[] products;
		private int itemCount;

		public Product[] Products { get => products; }
		public int ItemCount { get => itemCount; }

		public ShoppingCart(int capacity)
		{
			products = new Product[capacity];
			itemCount = 0;
		}

		public void AddProduct(Product product)
		{
			if (itemCount < products.Length)
			{
				products[itemCount] = product;
				itemCount++;
				Console.WriteLine($"{product.Name} added to the cart.");
			}
			else
			{
				Console.WriteLine("Cannot add more products. Cart is full.");
			}
		}

		public void RemoveProduct(Product product)
		{
			bool found = false;
			for (int i = 0; i < itemCount; i++)
			{
				if (products[i] == product)
				{
					found = true;
					for (int j = i; j < itemCount - 1; j++)
					{
						products[j] = products[j + 1];
					}
					itemCount--;
					break;
				}
			}
			if (found)
			{
				Console.WriteLine($"{product.Name} removed from the cart.");
			}
			else
			{
				Console.WriteLine($"{product.Name} not found in the cart.");
			}
		}
	}

	public class Program
	{
		static void Main(string[] args)
		{
			// Instantiating products
			ClothingProduct shirt = new ClothingProduct("Shirt", 25.99, ProductCategory.Clothing, "Medium", "Blue");
			ElectronicsProduct laptop = new ElectronicsProduct("Laptop", 899.99, ProductCategory.Electronics, "Dell", "XPS 13");

			// Instantiating a shopping cart
			ShoppingCart cart = new ShoppingCart(5);

			// Adding products to the shopping cart
			cart.AddProduct(shirt);
			cart.AddProduct(laptop);

			// Displaying the contents of the shopping cart
			Console.WriteLine("\nContents of the shopping cart:");
			foreach (Product product in cart.Products)
			{
				if (product != null)
				{
					product.GetInfo();
				}
			}

			// Removing a product from the shopping cart
			cart.RemoveProduct(shirt);

			// Displaying the updated contents of the shopping cart
			Console.WriteLine("\nUpdated contents of the shopping cart:");
			foreach (Product product in cart.Products)
			{
				if (product != null)
				{
					product.GetInfo();
				}
			}
		}
	}
}
