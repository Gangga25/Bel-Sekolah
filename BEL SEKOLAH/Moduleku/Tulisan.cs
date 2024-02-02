using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{     
    class Tulisan : IComponent
    {
        public int Length = 0;

        public Tulisan(string Text = ""): base()
        {
            base.Text = Text;
        }

        public override void Tampil()
        {
            base.ApplyConsoleColor();
            Console.SetCursorPosition(base.X, base.Y);
            Console.Write(base.Text);
        }

        public void TampilTengah()
        {
            base.ApplyConsoleColor();
            Console.SetCursorPosition(((this.Length  - base.Text.Length) / 2) + base.X, base.Y);
            Console.Write(base.Text);
        }

        public new Tulisan SetText(string Text)
        {
            base.SetText(Text);
            return this;
        }

        public new Tulisan SetXY(int X, int Y)
        {
            base.SetXY(X, Y);
            return this;
        }

        public Tulisan SetLength(int Length)
        {
            this.Length = Length;
            return this;
        }

        public Tulisan SetBackColor(ConsoleColor Color)
        {
            base.BackColor = Color;
            return this;
        }

        public Tulisan SetForeColor(ConsoleColor Color)
        {
            base.ForeColor = Color;
            return this;
        }
    }
}
