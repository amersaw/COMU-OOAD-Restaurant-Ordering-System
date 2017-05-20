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
        public bool IsCompleted { get; set; }
        public bool IsSubmited { get; set; }

        public List<FoodLineItem> FoodLineItems { get; set; }

        public Order()
        {
            FoodLineItems = new List<FoodLineItem>();
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
        }
    }
}
