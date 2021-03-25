using System;
using System.Collections.Generic;

namespace CheckoutApplication
{
	class Checkout
	{

		static void Main(string[] args)
		{
			var checkOut = new CheckoutActions();
			checkOut.PrintMenu();
			checkOut.takeOrder();
			checkOut.anyUpdate();
		}
	}
		
}
