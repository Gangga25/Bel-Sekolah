using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Clear : IComponent
    {
        public int Width = 0;
        public int Height = 0;

        public Clear(int X = 0, int Y = 0, int Width = 0, int Height = 0) : base()
        {
            base.SetXY(X, Y);
            this.SetWidthAndHeight(Width, Height);
        }

        public override void Tampil()
        {
            Console.ForegroundColor = base.ForeColor;
            Console.BackgroundColor = base.BackColor;
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(new string(' ', Width));
            }
        }

        public new Clear SetXY(int X, int Y)
        {
            base.SetXY(X, Y);
            return this;
        }

        public Clear SetWidthAndHeight(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return this;
        }

        public Clear SetBackColor(ConsoleColor Color)
        {
            base.BackColor = Color;
            return this;
        }

        public Clear SetForeColor(ConsoleColor Color)
        {
            base.ForeColor = Color;
            return this;
        }
    }
}
