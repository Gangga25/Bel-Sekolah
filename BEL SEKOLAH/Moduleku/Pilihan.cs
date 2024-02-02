using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Pilihan : IComponent
    {
        private Tulisan[] Pilihans;
        public int SelectedIndex = 0;
        public string Value = "";

        public Pilihan(params string[] Pilihans) : base()
        {
            this.SetPilihans(Pilihans);
        }

        public override void Tampil()
        {
            base.ApplyConsoleColor();
            Console.SetCursorPosition(base.X, base.Y);
            Console.Write(base.Text + " ");

            ConsoleKeyInfo CKey = new ConsoleKeyInfo();

            bool IsEnter = false;

            int LastSelectedIndex = this.SelectedIndex;

            while (!IsEnter)
            {
                Console.SetCursorPosition(base.X + Text.Length + 1, base.Y);
                Console.Write(new string(' ', this.Pilihans[LastSelectedIndex].Text.Length));
                Console.SetCursorPosition(base.X + Text.Length + 1, base.Y);

                Console.Write(this.Pilihans[SelectedIndex].Text);

                LastSelectedIndex = this.SelectedIndex;

                CKey = Console.ReadKey(true);

                switch (CKey.Key)
                {
                    case ConsoleKey.Enter:
                        Value = this.Pilihans[SelectedIndex].Text;
                        IsEnter = true;
                        break;
                    case ConsoleKey.UpArrow:
                        this.Prev();
                        break;
                    case ConsoleKey.DownArrow:
                        this.Next();
                        break;
                    case ConsoleKey.LeftArrow:
                        this.Prev();
                        break;
                    case ConsoleKey.RightArrow:
                        this.Next();
                        break;
                }
            }
        }

        public void SetPilihans(params string[] Pilihans)
        {
            this.Pilihans = new Tulisan[Pilihans.Length];
            for (int i = 0; i < Pilihans.Length; i++)
            {
                Tulisan T = new Tulisan();
                T.Text = Pilihans[i];
                this.Pilihans[i] = T;
            }

        }

        public string Read()
        {
            Tampil();
            return this.Pilihans[this.SelectedIndex].Text;
        }

        public void Next()
        {
            if (this.SelectedIndex >= this.Pilihans.Length - 1)
            {
                this.SelectedIndex = 0;
                return;
            }
            this.SelectedIndex++;
        }

        public void Prev()
        {
            if (this.SelectedIndex <= 0)
            {
                this.SelectedIndex = this.Pilihans.Length - 1;
                return;
            }
            this.SelectedIndex--;
        }

        public new Pilihan SetText(string Text)
        {
            base.SetText(Text);
            return this;
        }

        public new Pilihan SetXY(int X, int Y)
        {
            base.SetXY(X, Y);
            return this;
        }

        public Pilihan SetBackColor(ConsoleColor Color)
        {
            base.BackColor = Color;
            return this;
        }

        public Pilihan SetForeColor(ConsoleColor Color)
        {
            base.ForeColor = Color;
            return this;
        }
    }
}
