using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    abstract class Figure
    {
        public string Name { get; set; }
        public System.Drawing.Color Color { get; set; }
        public System.Drawing.Point Position { get; set; }
        public abstract double GetArea();
        public abstract System.Drawing.Point GetCenter();
        public abstract void Draw(Graphics gr);
    }

    class Rectangle : Figure
    {
        public double Width;
        public double Height;
        public override double GetArea()
        {
            return Width * Height;
        }
        public override Point GetCenter()
        {
            return new Point((int)(Position.X+Width/2),(int)(Position.Y+Height/2));
        }
        public override void Draw(Graphics gr)
        {
            gr.DrawRectangle(new Pen(Color), Position.X,Position.Y,(int)Width,(int)Height);
            gr.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
    class Сircle : Figure
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return 2 * Math.PI * Math.Pow(Radius, 2);
        }
        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Radius / 2), (int)(Position.Y + Radius / 2));
        }
        public override void Draw(Graphics gr)
        {
            Radius = Convert.ToSingle(Radius);
            gr.DrawEllipse(new Pen(Color), Position.X, Position.Y,(int)Radius*2,(int)Radius*2);
            gr.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
    class Triangle : Figure
    {
        public double Base;
        public double Height;
        public override double GetArea()
        {
            return Base * Height / 2;
        }
        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Base / 2), (int)(Position.Y + Height / 2));
        }
        public override void Draw(Graphics gr)
        {
            Point[] points = new Point[3];
            points[0] = new Point(Position.X, Position.Y + (int)Height);
            points[1] = new Point(Position.X + (int)Base, Position.Y + (int)Height);
            points[2] = new Point(Position.X + (int)(Base / 2), Position.Y);
            gr.DrawPolygon(new Pen(Color), points);
            gr.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }

    class Rhombus : Figure
    {
        public double Diagonal1 { get; set; }
        public double Diagonal2 { get; set; }

        public override double GetArea()
        {
            return 0.5 * Diagonal1 * Diagonal2;
        }

        public override Point GetCenter()
        {
            int centerX = (int)(Position.X + Diagonal2 / 2);
            int centerY = (int)(Position.Y + Diagonal1 / 2);
            return new Point(centerX, centerY);
        }

        public override void Draw(Graphics gr)
        {
            Point[] points = new Point[4];
            points[0] = new Point((int)(Position.X + Diagonal2 / 2), (int)Position.Y);
            points[1] = new Point((int)(Position.X + Diagonal2), (int)(Position.Y + Diagonal1 / 2));
            points[2] = new Point((int)(Position.X + Diagonal2 / 2), (int)(Position.Y + Diagonal1));
            points[3] = new Point((int)Position.X, (int)(Position.Y + Diagonal1 / 2));
            gr.DrawPolygon(new Pen(Color), points);
            gr.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }

    class Parallelogram : Figure
    {
        public double Base;
        public double Height;
        public override double GetArea()
        {
            return Base * Height;
        }
        public override Point GetCenter()
        {
            return new Point(Position.X + (int)(Base / 2), Position.Y + (int)(Height / 2));
        }
        public override void Draw(Graphics gr)
        {
            Point[] points = new Point[4];
            points[0] = new Point(Position.X, Position.Y);
            points[1] = new Point(Position.X + (int)Base, Position.Y);
            points[2] = new Point(Position.X + (int)(Base - Height), Position.Y + (int)Height);
            points[3] = new Point(Position.X - (int)Height, Position.Y + (int)Height);
            gr.DrawPolygon(new Pen(Color), points);
            gr.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
    class Trapezium : Figure
    {
        public double Bottom { get; set; }
        public double Top { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return (Bottom + Top) * Height * 0.5;
        }

        public override Point GetCenter()
        {
            int x = Position.X + (int)((Bottom + Top) / 2);
            int y = Position.Y + (int)(Height / 2);
            return new Point(x, y);
        }

        public override void Draw(Graphics gr)
        {
            Point[] points =
            {
                new Point((int)Position.X, (int)Position.Y),
                new Point((int)(Position.X+Top), (int)Position.Y),
                new Point((int)(Position.X+Bottom),(int)(Position.Y+Height)),
                new Point((int)Position.X,(int)(Position.Y+Height))
        };

            gr.DrawPolygon(new Pen(Color), points);
            gr.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
    class Pentagon : Figure
    {
        public double Side { get; set; }

        public override double GetArea()
        {
            return 0.25 * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) * Math.Pow(Side, 2);
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Side / 2), (int)(Position.Y + Side));
        }

        public override void Draw(Graphics gr)
        {
            Point[] points = new Point[5];
            double angle = 2 * Math.PI / 5;
            double apothem = 0.5 * Side / Math.Tan(Math.PI / 5);
            for (int i = 0; i < 5; i++)
            {
                points[i] = new Point(
                (int)(Position.X + apothem * Math.Cos(i * angle - Math.PI / 2)),
                (int)(Position.Y + apothem * Math.Sin(i * angle - Math.PI / 2))
                );
            }
            gr.DrawPolygon(new Pen(Color), points);
            gr.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
    class Decagon : Figure
    {
        public double Side { get; set; }

        public override double GetArea()
        {
            return 0.25 * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) * Math.Pow(Side, 2);
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Side / 2), (int)(Position.Y + Side));
        }

        public override void Draw(Graphics gr)
        {
            Point[] points = new Point[10];
            double angle = 2 * Math.PI / 10;
            double apothem = 0.5 * Side / Math.Tan(Math.PI / 10);
            for (int i = 0; i < 10; i++)
            {
                points[i] = new Point(
                (int)(Position.X + apothem * Math.Cos(i * angle - Math.PI / 2)),
                (int)(Position.Y + apothem * Math.Sin(i * angle - Math.PI / 2))
                );
            }
            gr.DrawPolygon(new Pen(Color), points);
            gr.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
    }
