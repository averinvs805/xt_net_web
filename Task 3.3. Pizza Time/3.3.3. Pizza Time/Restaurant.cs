using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _3._3._3._Pizza_Time
{
    public enum Pizza
    {
        Цезарь,
        Моццарелла,
        Гарганзолла,
        Пепперони
    }

    class Restaurant
    {
        public List<Order> orders = new List<Order>();

        public string Name { get; set; }

        public Restaurant(string name)
        {
            Name = name;
        }

        public void CreateOrder(Order order)
        {
            orders.Add(order);
            order.OnCreate += MakePizza;
        }

        public void MakePizza(Order order)
        {
            Console.WriteLine($"{Name}: Пожалуйста, подождите, пока пицца готовится...");
            Thread.Sleep(3000);
            Console.WriteLine($"{Name}: Пицца {order.Type} готова! Номер заказа: {order.Number}");

            orders.Remove(order);
            order.OnCreate -= MakePizza;
            order.Ready();
        }
    }

}
