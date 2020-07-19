using System;
using System.Collections.Generic;
using System.Text;

namespace _3._3._3._Pizza_Time
{
    class Customer
    {
        //private Order _order;

        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        //public void MakeOrder(Restaurant restaurant, Pizza type)
        //{
        //    Console.WriteLine($"{Name}: Здравствуйте, я хочу пиццу {type}");
        //    _order = new Order(Name, type);

        //    _order.OnReady += GetPizza;

        //    restaurant.CreateOrder(_order);
        //    _order.Create();

        //    Console.WriteLine();
        //}

        public Order OrderPizza(Pizza pizza)
        {
            Console.WriteLine($"{Name}: Здравствуйте, я хочу пиццу {pizza}");
            return new Order(pizza);
        }

        public void GetPizza(Order order)
        {
            Console.WriteLine($"{Name}: Спасибо!");
            order.OnReady -= GetPizza;
        }
    }
}
