using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Modal : IComponent
    {
        public string Yes = "IYA";
        public string No = "TIDAK";

        public bool IsYes = true;

        public Modal(string Text = "") : base()
        {
            base.Text = Text;
        }

        public override void Tampil()
        {
            base.ApplyConsoleColor();
            Console.SetCursorPosition(base.X, base.Y);
            Console.Write(base.Text + " ");

            ConsoleKeyInfo CKey = new ConsoleKeyInfo();

            bool IsEnter = false;

            while (!IsEnter)
            {
                Console.SetCursorPosition(base.X + Text.Length + 1, base.Y);
                Console.Write(new string(' ', !this.IsYes ? this.Yes.Length : this.No.Length));
                Console.SetCursorPosition(base.X + Text.Length + 1, base.Y);
                Console.Write(this.IsYes ? this.Yes : this.No);

                CKey = Console.ReadKey(true);

                switch(CKey.Key)
                {
                    case ConsoleKey.Enter:
                        IsEnter = true;
                        break;
                    case ConsoleKey.UpArrow:
                        IsYes = !IsYes;
                        break;
                    case ConsoleKey.DownArrow:
                        IsYes = !IsYes;
                        break;
                    case ConsoleKey.LeftArrow:
                        IsYes = !IsYes;
                        break;
                    case ConsoleKey.RightArrow:
                        IsYes = !IsYes;
                        break;
                    case ConsoleKey.T:
                        IsYes = false;
                        break;
                    case ConsoleKey.Y:
                        IsYes = true;
                        break;
                }
            }
        }

        public bool Read()
        {
            Tampil();
            return this.IsYes;
        }

        public new Modal SetText(string Text)
        {
            base.SetText(Text);
            return this;
        }

        public new Modal SetXY(int X, int Y)
        {
            base.SetXY(X, Y);
            return this;
        }

        public Modal SetBackColor(ConsoleColor Color)
        {
            base.BackColor = Color;
            return this;
        }

        public Modal SetForeColor(ConsoleColor Color)
        {
            base.ForeColor = Color;
            return this;
        }
    }
}
