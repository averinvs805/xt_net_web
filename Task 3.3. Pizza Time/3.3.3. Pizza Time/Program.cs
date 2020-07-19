using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace _3._3._3._Pizza_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant pizzeria = new Restaurant("ДоРеМи Пицца");

            Customer customer1 = new Customer("Иван");
            //customer1.MakeOrder(pizzeria, Pizza.Гарганзолла);
            MakeOrder(customer1, pizzeria, Pizza.Гарганзолла);

            Customer customer2 = new Customer("Маша");
            //customer2.MakeOrder(pizzeria, Pizza.Моццарелла);
            MakeOrder(customer2, pizzeria, Pizza.Моццарелла);

            Customer customer3 = new Customer("Антон");
            //customer3.MakeOrder(pizzeria, Pizza.Цезарь); 
            MakeOrder(customer3, pizzeria, Pizza.Цезарь);

            Customer customer4 = new Customer("Вера");
            //customer4.MakeOrder(pizzeria, Pizza.Пепперони); 
            MakeOrder(customer4, pizzeria, Pizza.Пепперони);
        }

        static void MakeOrder(Customer customer, Restaurant shop, Pizza pizza)
        {
            //Console.WriteLine($"{customer.Name}: Здравствуйте, я хочу пиццу {pizza}");
            //Order order = new Order(pizza);
            Order order = customer.OrderPizza(pizza);

            order.OnReady += customer.GetPizza;

            shop.CreateOrder(order);
            order.Create();

            Console.WriteLine();
        }
    }
}
