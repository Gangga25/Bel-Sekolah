using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    internal class Inputan : IComponent
    {
        public bool CursorVisible = true;
        public string InputValue = "";
        public Inputan(string Text = "") : base()
        {
            base.Text = Text;
        }

        public override void Tampil()
        {
            base.ApplyConsoleColor();
            Console.SetCursorPosition(base.X, base.Y);
            Console.Write(base.Text);
            Console.Write(" ");
            bool CursorVisible = Console.CursorVisible;
            Console.CursorVisible = this.CursorVisible;
            this.InputValue = Console.ReadLine();
            Console.CursorVisible = CursorVisible;
        }

        public string Read()
        {
            Tampil();
            return InputValue;
        }

        public new Inputan SetText(string Text)
        {
            base.SetText(Text);
            return this;
        }

        public new Inputan SetXY(int X, int Y)
        {
            base.SetXY(X, Y);
            return this;
        }

        public Inputan SetBackColor(ConsoleColor Color)
        {
            base.BackColor = Color;
            return this;
        }

        public Inputan SetForeColor(ConsoleColor Color)
        {
            base.ForeColor = Color;
            return this;
        }

    }
}
