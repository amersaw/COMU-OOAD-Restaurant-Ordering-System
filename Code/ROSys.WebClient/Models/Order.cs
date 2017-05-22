using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.WebClient.Models
{
    public class Order
    {
        public DateTime TimeDate { get; set; }
        public decimal Amount { get; set; }

        //Customer has finished adding items
        public bool IsCompleted { get; set; }

        //Customer has submited the order
        public bool IsSubmited { get; set; }

        public OrderStatus Status { get; set; }

        public bool IsPaid { get; set; }

        public List<FoodLineItem> FoodLineItems { get; set; }


        Payment p;


        public Order()
        {
            FoodLineItems = new List<FoodLineItem>();
            Status = OrderStatus.New;
        }

        internal void CreateLineItem(FoodDescription desc, int amount)
        {
            FoodLineItem fli = new FoodLineItem();
            //A FoodLineItem instance was created with name (fli).


            fli.Description = desc;
            //- (fli)was associated with FoodDescription, based on food_id match.

            fli.Count = amount;
            //- (fli.count)became count(which came from parameters)

            FoodLineItems.Add(fli);
            //(fli)was associated with the current order.

        }

        internal void MarkOrderAsReady()
        {
            Status = OrderStatus.Ready;
        }

        internal void SetTipAmount(double v)
        {
            p.SetTipAmount(v);
        }
        internal double GetTipAmount()
        {
            return p.GetTipAmount();
        }
        internal List<FoodLineItem> GetDetails()
        {
            return FoodLineItems;
        }

        internal void EndOrder()
        {
            this.IsCompleted = true;
        }

        internal void SubmitOrder()
        {
            this.IsSubmited = true;
            Status = OrderStatus.InProgress;
        }




        public void StartPayment()
        {
            p = new Payment();
            //A Payment instance was created with name (p).
        }

        internal void MakePayment()
        {
            p.MarkAsPCompleted();
            p.PaymentReceipt = new Models.Receipt(this, DateTime.Now, "Cash");
        }

        internal Receipt GetReceipt()
        {
            return p.GetReceipt();
        }
    }
}
