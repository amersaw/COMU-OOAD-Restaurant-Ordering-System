using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.WebClient.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }

        public Order currentOrder { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

        private void SetCurrentOrder(Order o)
        {
            currentOrder = o;
        }

        public void StartOrder()
        {

            Order o = new Order();
            //An Order instance was created with name (o).

            this.Orders.Add(o);
            //(o)was associated with the currently logged in customer instance.

            //todo:1.1.png file
            SetCurrentOrder(o);
        }

        public void CreateLineItem(FoodDescription desc, int amount)
        {
            currentOrder.CreateLineItem(desc, amount);
        }

        internal List<FoodLineItem> GetDetails()
        {
            return currentOrder.GetDetails();
        }

        internal void EndOrder()
        {
            currentOrder.EndOrder();
        }

        internal void SubmitOrder()
        {
            currentOrder.SubmitOrder();
        }
    }
}
