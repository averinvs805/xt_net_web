using System;
using System.Collections.Generic;
using System.Text;

namespace _3._3._3._Pizza_Time
{
    class Order
    {
        public static int OrderNumber = 1;

        public event Action<Order> OnCreate = delegate { };
        public event Action<Order> OnReady = delegate { };

        public int Number { get; private set; }
        public Pizza Type { get; private set; }

        public Order(Pizza type)
        {
            Type = type;
            Number = OrderNumber;
            OrderNumber++;
        }

        public void Create()
        {
            OnCreate(this);
        }

        public void Ready()
        {
            OnReady(this);
        }
    }
}
