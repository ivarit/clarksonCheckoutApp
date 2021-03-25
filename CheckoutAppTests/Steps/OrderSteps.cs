using CheckoutApplication;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CheckoutAppTests.Steps
{
	[Binding]
	public class OrderSteps
	{
		private CheckoutActions checkoutActions;
        private double actualTotal;

		public OrderSteps(CheckoutActions checkoutActions)
		{
			this.checkoutActions = checkoutActions;
		}
        [Given(@"I am presented with menu")]
        public void GivenIAmPresentedWithMenu()
        {
            checkoutActions.PrintMenu();
        }

        [When(@"I add below items")]
        public void WhenIAddBelowItems(Table table)
        { 
            var items = new List<string>();
            foreach(var item in table.CreateDynamicSet())
			{
                items.Add(item.menuItem);
			}
            actualTotal = checkoutActions.orderTotal(items);
        }

        [Then(@"I should be presented with total ""(.*)""")]
        public void ThenIShouldBePresentedWithTotal(Decimal totalBill)
        {
            Assert.AreEqual(totalBill, actualTotal);
        }

    }
}
