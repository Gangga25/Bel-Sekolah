using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
   
    abstract class IComponent
    {
        public string Text = "";
        public ConsoleColor BackColor = ConsoleColor.Black;
        public ConsoleColor ForeColor = ConsoleColor.White;
        public int X = 0;
        public int Y = 0;

        public IComponent()
        {

        }

        public abstract void Tampil();

        public IComponent SetXY(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            return this;
        }

        public IComponent ApplyConsoleColor()
        {
            Console.BackgroundColor = this.BackColor;
            Console.ForegroundColor = this.ForeColor;
            return this;
        }

        public IComponent SetText(string Text)
        {
            this.Text = Text;
            return this;
        }

        public IComponent SetX(int X)
        {
            this.X = X;
            return this;
        }

        public IComponent SetY(int Y)
        {
            this.Y = Y;
            return this;
        }
    }
}

