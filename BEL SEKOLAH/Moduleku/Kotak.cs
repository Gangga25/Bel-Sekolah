using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Kotak : IComponent
    {
        public int Width = 0;
        public int Height = 0;

        public Kotak(int X = 0, int Y = 0, int Width = 0, int Height = 0) : base()
        {
            base.SetXY(X, Y);
            this.SetWidthAndHeight(Width, Height);
        }

        public override void Tampil()
        {
            base.ApplyConsoleColor();
            int X2 = base.X + this.Width;
            int Y2 = base.Y + this.Height;

            for (int i = 1; i <= this.Width; i++)
            {
                Console.SetCursorPosition(X + i, Y);
                Console.Write("─");
                Console.SetCursorPosition(X + i, Y2);
                Console.Write("─");
            }

            for (int i = 1; i <= this.Height; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write("│");
                Console.SetCursorPosition(X2, Y + i);
                Console.Write("│");
            }

            Console.SetCursorPosition(X, Y);
            Console.Write("┌");
            Console.SetCursorPosition(X2, Y);
            Console.Write("┐");
            Console.SetCursorPosition(X, Y2);
            Console.Write("└");
            Console.SetCursorPosition(X2, Y2);
            Console.Write("┘");

        }

        public new Kotak SetXY(int X, int Y)
        {
            base.SetXY(X, Y);
            return this;
        }

        public Kotak SetWidthAndHeight(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return this;
        }

        public Kotak SetBackColor(ConsoleColor Color)
        {
            base.BackColor = Color;
            return this;
        }

        public Kotak SetForeColor(ConsoleColor Color)
        {
            base.ForeColor = Color;
            return this;
        }
    }
}
