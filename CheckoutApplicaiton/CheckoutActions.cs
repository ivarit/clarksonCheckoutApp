using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutApplication
{
	public class CheckoutActions
	{
		private  List<string> itemList = new List<string>();
		private  double total = 0.00;

		private Dictionary<string, double> restaurantMenu = new Dictionary<string, double>()
			{
				{ "A", 4.40 },
				{ "B", 4.40 },
				{ "C", 7.00 },
				{ "D", 7.00 }

			};

		public void PrintMenu()
		{
			foreach(var item in restaurantMenu)
			{
				Console.WriteLine($"{item.Key} : {item.Value}");
			}
		}
		public void removeItem(List<string> orderedItems)
		{
			if (orderedItems.Count != 0)
			{

				Console.WriteLine($"Select item to remove from below: please select space after each item");
				foreach (var item in orderedItems)
				{
					Console.WriteLine(item);
				}

				var splitInputs = Console.ReadLine().Split(' ');


				foreach (var item in splitInputs)
				{
					orderedItems.Remove(item);
					total = total - restaurantMenu[item];
				}
			}
			else
			{
				Console.WriteLine("Your order is empty!");

			}
		}

		public void anyUpdate()
		{
			Console.WriteLine("Do you want to Add or remove items\n 1. Add \n 2. Remove 3. No");
			var choice = Console.ReadLine();
			updateOrder(choice);
		}
		public void takeOrder()
		{
			Console.WriteLine("Please select Items you would like to order from the Menu: 1. A price 1.00, 2. B price  2.00, 3. C price 2.00 please select space after each item");

			var splitInputs = Console.ReadLine().Split(' ');


			foreach (var item in splitInputs)
				itemList.Add(item);

			var bill = orderTotal(itemList);
			Console.WriteLine($"Yout Total Bill is : { bill}");


		}

		public void updateOrder(string choice)
		{
			while (choice != "3")
			{
				switch (choice)
				{
					case "1":
						itemList.Clear();
						takeOrder();
						break;
					case "2":
						removeItem(itemList);
						break;
					default:
						throw new Exception("Inavlid choice!");
				}
				Console.WriteLine("Do you want to Add more or remove items\n 1. Add \n 2. Remove 3. No");
				choice = Console.ReadLine();
			}
			Console.WriteLine($"Your order Total is : {Math.Round(total,2)}");
			Console.WriteLine("Thank you for your order");
		}
		public double orderTotal(List<string> orderedItems)
		{

			foreach (var item in orderedItems)
			{
				total = total + restaurantMenu[item];
			}

			return Math.Round(total, 2);
		}
	}
}

