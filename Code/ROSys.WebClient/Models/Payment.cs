using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.WebClient.Models
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public double TipAmount { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsCompleted { get; set; }
        public Receipt PaymentReceipt { get; set; }

        internal void SetTipAmount(double v)
        {
            TipAmount = v;
        }

        internal void MarkAsPCompleted()
        {
            this.IsCompleted = true;
        }

        internal Receipt GetReceipt()
        {
            return PaymentReceipt;

        }

        internal double GetTipAmount()
        {
            return TipAmount;
        }
    }
}
