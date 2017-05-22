using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROSys.WebClient
{
    public static class Ledger
    {
        private static List<Models.Order> CompletedOrders;
        static Ledger()
        {
            CompletedOrders = new List<Models.Order>();
        }
        public static void AddOrder(Models.Order order)
        {
            CompletedOrders.Add(order);
        }
    }
}