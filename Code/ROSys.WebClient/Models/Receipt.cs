using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.WebClient.Models
{

    public class ReceiptItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class Receipt
    {
        public List<ReceiptItem> Items { get; set; }
        public DateTime PaidTime { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TipAmount { get; set; }

        public Receipt(Order o, DateTime paidTime, string paymentMethod)
        {
            TipAmount = (decimal)o.GetTipAmount();
            Items = new List<Models.ReceiptItem>();
            foreach (var item in o.FoodLineItems)
            {
                Items.Add(new Models.ReceiptItem()
                {
                    Count = item.Count,
                    Name = item.Description.Name,
                    TotalPrice = item.Count * item.Description.Price,
                    UnitPrice = item.Description.Price
                });
            }
            PaymentMethod = paymentMethod;
            PaidTime = paidTime;
            TotalAmount = TipAmount + o.FoodLineItems.Sum(f => f.Count * f.Description.Price);
        }
    }
}
