using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    internal class Program
    {
        public static Figure[] figures =
{
            new Rectangle()
            {
                Name = "Квадрат №1",
                Color= System.Drawing.Color.DarkRed,
                Position = new System.Drawing.Point(30,30),
                Width= 50,Height= 50,
            },
            new Rectangle()
            {
                Name = "Квадрат №2",
                Color= System.Drawing.Color.Green,
                Position = new System.Drawing.Point(60,100),
                Width= 100,Height= 100,
            },
            new Rectangle()
            {
                Name = "Прямоугольник #1",
                Color = System.Drawing.Color.Blue,
                Position = new System.Drawing.Point(200,200),
                Width= 100,Height= 50,
            },
            new Сircle()
            {   
                Name = "Круг",
                Color = System.Drawing.Color.Blue,
                Position = new System.Drawing.Point(200,10),
                Radius = 25,
            },
            new Triangle()
            {
                Name = "Треугольник",
                Color = System.Drawing.Color.Red,
                Position = new System.Drawing.Point(300,10),
                Height = 60, Base = 90
            },
            new Rhombus()
            {
                Name = "Ромб",
                Color = System.Drawing.Color.Red,
                Position = new System.Drawing.Point(400,10),
                Diagonal1 = 85,
                Diagonal2 = 50,
            },
            new Parallelogram()
            {
                Name = "Параллелограмм",
                Color = System.Drawing.Color.Red,
                Position = new System.Drawing.Point(400,100),
                Base = 30, Height= 50
            },
            new Trapezium()
            {
                Name = "Трапеция",
                Color = System.Drawing.Color.Green,
                Position = new System.Drawing.Point(500,100),
                Top= 80,Height= 50,Bottom= 100,
            },
            new Pentagon()
            {
                Name = "Пятиугольник",
                Color = System.Drawing.Color.Red,
                Position = new System.Drawing.Point(500,400),
                Side= 80,
            },
            new Decagon()
            {
                Name = "Десятиугольник",
                Color = System.Drawing.Color.Red,
                Position = new System.Drawing.Point(500,300),
                Side= 50,
            }
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Лабараторная работа №3\nВыполнил - Прокопчук Сергей");


            Form frm = new Form()
            {
                Text = "Лабараторная работа№3 - полиморфизм",
                Size = new System.Drawing.Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen,
            };
           frm.Paint += Frm_Paint;
            Application.Run(frm);
        }
        private static void Frm_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure f in figures)
            {
                f.Draw(e.Graphics);
            }

        }
    }
}
