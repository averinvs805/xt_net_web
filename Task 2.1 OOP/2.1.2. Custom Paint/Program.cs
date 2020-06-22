using System;
using System.Collections.Generic;

namespace _2._1._2._Custom_Paint
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] param;

            List<AbstractShape> shapes = new List<AbstractShape>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста, выберите действие:\n");
                Console.WriteLine("1. Добавить фигуру");
                Console.WriteLine("2. Показать фигуры");
                Console.WriteLine("3. Очистить");
                Console.WriteLine("4. Выйти");

                int.TryParse(Console.ReadLine(), out int selectAction);

                switch (selectAction)
                {
                    case 1:

                        Console.WriteLine("Пожалуйста, выберите тип фигуры и введите соответствующее ей число:\n");
                        Console.WriteLine("1. Окружность");
                        Console.WriteLine("2. Круг");
                        Console.WriteLine("3. Кольцо");
                        Console.WriteLine("4. Квадрат");
                        Console.WriteLine("5. Прямоугольник");
                        Console.WriteLine("6. Линия");
                        Console.WriteLine("7. Треугольник");

                        int.TryParse(Console.ReadLine(), out int selectFigure);

                        switch (selectFigure)
                        {
                            case 1:
                                param = new int[3];
                                Console.WriteLine("Введите две координаты начала и радиус: ");
                                break;
                            case 2:
                                param = new int[3];
                                Console.WriteLine("Введите две координаты начала и радиус: ");
                                break;
                            case 3:
                                param = new int[4];
                                Console.WriteLine("Введите две координаты начала, внешний и внутренний радиус: ");
                                break;
                            case 4:
                                param = new int[3];
                                Console.WriteLine("Введите две координаты начала и одну сторону: ");
                                break;
                            case 5:
                                param = new int[4];
                                Console.WriteLine("Введите две координаты начала и две стороны: ");
                                break;
                            case 6:
                                param = new int[3];
                                Console.WriteLine("Введите две координаты начала и длину: ");
                                break;
                            case 7:
                                param = new int[5];
                                Console.WriteLine("Введите две координаты начала и три стороны: ");
                                break;
                            default:
                                param = new int[0];
                                break;
                        }

                        for (int i = 0; i < param.Length; i++)
                        {
                            int.TryParse(Console.ReadLine(), out int x);

                            if (x <= 0 || string.IsNullOrWhiteSpace(x.ToString()))
                            {
                                selectFigure = 8;
                            }
                            param[i] = x;
                        }

                        switch (selectFigure)
                        {
                            case 1:
                                shapes.Add(new Circle(param[0], param[1], param[2]));
                                break;
                            case 2:
                                shapes.Add(new Disk(param[0], param[1], param[2]));
                                break;
                            case 3:
                                shapes.Add(new Ring(param[0], param[1], param[2], param[3]));
                                break;
                            case 4:
                                shapes.Add(new Square(param[0], param[1], param[2]));
                                break;
                            case 5:
                                shapes.Add(new Rectangle(param[0], param[1], param[2], param[3]));
                                break;
                            case 6:
                                shapes.Add(new Line(param[0], param[1], param[2]));
                                break;
                            case 7:
                                shapes.Add(new Triangle(param[0], param[1], param[2], param[3], param[4]));
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        for (int i = 0; i < shapes.Count; i++)
                        {
                            Console.WriteLine(shapes[i].ToString());
                        }
                        Console.WriteLine("Нажмите Enter...");
                        Console.ReadLine();
                        break;
                    case 3:
                        shapes.Clear();
                        break;
                    case 4:
                        return;
                }
            }
        }
    }
}
