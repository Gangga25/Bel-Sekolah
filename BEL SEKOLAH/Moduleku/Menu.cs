using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Menu : IComponent
    {
        public Tulisan[] Pilihans;
        public int SelectedIndex = 0;
        public ConsoleColor SelectedBackColor = ConsoleColor.White;
        public ConsoleColor SelectedForeColor = ConsoleColor.Red;

        public Menu(params string[] Pilihans) : base()
        {
            this.SetPilihans(Pilihans);
        }

        public override void Tampil()
        {

            for (int i = 0; i < this.Pilihans.Length; i++)
            {
                this.Pilihans[i].X = base.X;
                this.Pilihans[i].Y = base.Y + i;
                this.Pilihans[i].BackColor = base.BackColor;
                this.Pilihans[i].ForeColor = base.ForeColor;
                this.Pilihans[i].Tampil();
            }

            if (Pilihans == null) return;
            if (Pilihans.Length <= SelectedIndex) return;
            this.Pilihans[SelectedIndex].BackColor = this.SelectedBackColor;
            this.Pilihans[SelectedIndex].ForeColor = this.SelectedForeColor;
            this.Pilihans[SelectedIndex].Tampil();
        }

        public void SetPilihans(params string[] Pilihans)
        {
            this.Pilihans = new Tulisan[Pilihans.Length];
            for(int i = 0; i < Pilihans.Length; i++)
            {
                Tulisan T = new Tulisan();
                T.Text = Pilihans[i];
                this.Pilihans[i] = T;
            }
           
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

        public new Menu SetXY(int X, int Y)
        {
            base.SetXY(X, Y);
            return this;
        }

        public Menu SetBackColor(ConsoleColor Color)
        {
            base.BackColor = Color;
            return this;
        }

        public Menu SetForeColor(ConsoleColor Color)
        {
            base.ForeColor = Color;
            return this;
        }

        public Menu SetSelectedBackColor(ConsoleColor Color)
        {
            this.SelectedBackColor = Color;
            return this;
        }

        public Menu SetSelectedForeColor(ConsoleColor Color)
        {
            this.SelectedForeColor = Color;
            return this;
        }
    }
}
