using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROSys.WebClient.Models
{
    public class Table
    {
        public string Number { get; set; }
        public int NumberOfPerson { get; set; }

        public Payment CurrentPayment { get; set; }
        public Customer CurrentCustomer { get; set; }
        public Guid Id { get; internal set; }

        public Table()
        {
            //This is only mock customer, because we don't have login process yet.
            CurrentCustomer = new Customer()
            {
                FirstName = "Ahmet",
                LastName = "Özturk",
                Orders = new List<Order>()
            };
        }


        public void StartOrder()
        {
            CurrentCustomer.StartOrder();
        }

        public void SelectFood(Guid foodId, int amount)
        {

            Model.FoodDescription desc = (Model.FoodDescription)DBFacadeFactory.Instance.Get(foodId, typeof(Model.FoodDescription));

            CurrentCustomer.CreateLineItem(new FoodDescription(desc), amount);



        }

        internal List<FoodLineItem> GetDetails()
        {
            return CurrentCustomer.GetDetails();
        }

        internal void EndOrder()
        {
            CurrentCustomer.EndOrder();
        }

        internal void SubmitOrder()
        {
            CurrentCustomer.SubmitOrder();
        }
    }
}