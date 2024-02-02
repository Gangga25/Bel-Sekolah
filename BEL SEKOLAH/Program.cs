using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Component;
using Database;
using System.Threading;

namespace BEL_SEKOLAH
{
    class Program
    {
        public static AccessDatabaseHelper DB = new AccessDatabaseHelper("./Jadwal.accdb");

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Kotak Kepala = new Kotak();
            Kepala.X = 0;
            Kepala.Y = 0;
            Kepala.Width = 119;
            Kepala.Height = 5;
            Kepala.SetBackColor(ConsoleColor.DarkMagenta);
            Kepala.Tampil();

            Kotak Kaki = new Kotak();
            Kaki.X = 0;
            Kaki.Y = 25;
            Kaki.Width = 119;
            Kaki.Height = 3;
            Kaki.SetBackColor(ConsoleColor.DarkCyan);
            Kaki.Tampil();

            Kotak Kiri = new Kotak();
            Kiri.X = 0;
            Kiri.Y = 6;
            Kiri.Width = 30;
            Kiri.Height = 18;
            Kiri.SetBackColor(ConsoleColor.Gray);
            Kiri.Tampil();

            Kotak Kanan = new Kotak();
            Kanan.X = 31;
            Kanan.Y = 6;
            Kanan.Width = 88;
            Kanan.Height = 18;
            Kanan.SetBackColor(ConsoleColor.Gray);
            Kanan.Tampil();

            Tulisan NamaAplikasi = new Tulisan();
            NamaAplikasi.Text = "APLIKASI BEL SEKOLAH";
            NamaAplikasi.X = 1;
            NamaAplikasi.Y = 1;
            NamaAplikasi.Length = 114;
            NamaAplikasi.SetForeColor(ConsoleColor.Magenta);
            NamaAplikasi.TampilTengah();

            Tulisan Sekolah = new Tulisan();
            Sekolah.Text = "WEARNES EDUCATION CENTER MADIUN";
            Sekolah.X = 0;
            Sekolah.Y = 2;
            Sekolah.Length = 115;
            Sekolah.SetForeColor(ConsoleColor.Magenta);
            Sekolah.TampilTengah();

            Tulisan Alamat = new Tulisan();
            Alamat.Text = "JL. THAMRIN NO. 35A KOTA MADIUN";
            Alamat.X = 0;
            Alamat.Y = 3;
            Alamat.Length = 115;
            Alamat.SetForeColor(ConsoleColor.Magenta);
            Alamat.TampilTengah();

            Tulisan Nama = new Tulisan();
            Nama.SetForeColor(ConsoleColor.Cyan).SetText("GANGGA VIDYA ANGGELIKA").SetXY(0, 26).SetLength(119).TampilTengah();

            new Tulisan().SetForeColor(ConsoleColor.Cyan).SetXY(0, 27).SetText("INFORMATIKA II").SetLength(119).TampilTengah();

            Menu menu = new Menu ("JALANKAN", "LIHAT JADWAL", "TAMBAH JADWAL", "EDIT JADWAL", "HAPUS JADWAL", "KELUAR");
            menu.SetXY(5, 10);
            menu.ForeColor = ConsoleColor.Gray;
            menu.SelectedBackColor = ConsoleColor.White;
            menu.SelectedForeColor = ConsoleColor.Black;
            menu.Tampil();

            bool IsProgramJalan = true;

            while (IsProgramJalan)
            {
                ConsoleKeyInfo Tombol = Console.ReadKey(true);
                if (Tombol.Key == ConsoleKey.DownArrow)
                {
                    menu.Next();
                    menu.Tampil();
                }
                else if (Tombol.Key == ConsoleKey.UpArrow)
                {
                    menu.Prev();
                    menu.Tampil();
                }
                else if (Tombol.Key == ConsoleKey.Enter)
                {
                    int MenuTerpilih = menu.SelectedIndex;

                    if(MenuTerpilih == 0)
                    {
                        Jalankan();
                    }
                    else if(MenuTerpilih == 1)
                    {
                        LihatJadwal();
                    }
                    else if(MenuTerpilih == 2)
                    {
                        TambahJadwal();
                    }
                    else if(MenuTerpilih == 3)
                    {
                        EditJadwal();
                    }
                    else if(MenuTerpilih == 4)
                    {
                        HapusJadwal();
                    }
                    else if(MenuTerpilih == 5)
                    {
                        Keluar();
                        IsProgramJalan = false;
                    }
                }

            } 

        }  

        static void Jalankan()
        {
            new Clear(32, 7, 87, 16).Tampil();

            Tulisan Judul = new Tulisan();
            Judul.SetXY(31, 7).SetText(".: JALANKAN PROGRAM :.").SetLength(88).SetForeColor(ConsoleColor.White);
            Judul.TampilTengah();

            Tulisan HariSekarang = new Tulisan().SetXY(33, 9);
            Tulisan JamSekarang = new Tulisan().SetXY(33, 10);

            string QSelect = "SELECT * FROM tb_jadwal WHERE hari=@hari AND jam=@jam;";

            DB.Connect();

            bool Play = true;

            while (Play)
            {
                DateTime Sekarang = DateTime.Now;

                HariSekarang.SetText("HARI : " + Sekarang.ToString("dddd"));
                HariSekarang.Tampil();

                JamSekarang.SetText("JAM  : " + Sekarang.ToString("HH:mm:ss"));
                JamSekarang.Tampil();

                DataTable DT = DB.RunQuery(QSelect,
                    new OleDbParameter("@hari", Sekarang.ToString("dddd")),
                    new OleDbParameter("@jam", Sekarang.ToString("HH:mm")));

                if(DT.Rows.Count > 0)
                {
                    Audio SRA = new Audio();
                    SRA.File = "./Suara/" + DT.Rows[0]["sound"];
                    SRA.Play();

                    new Tulisan().SetXY(31, 14).SetText("BEL TELAH BERBUNYI!!!").SetBackColor(ConsoleColor.Red).SetLength(88).TampilTengah();
                    new Tulisan().SetXY(31, 15).SetText(DT.Rows[0]["ket"].ToString()).SetBackColor(ConsoleColor.Red).SetLength(88).TampilTengah();

                    Play = false;
                }

                Thread.Sleep(1000);
            }


        }
        static void LihatJadwal()
        {
            new Clear(32, 7, 87, 16).Tampil();

            Tulisan Judul = new Tulisan();
            Judul.SetXY(31, 7).SetText(".: LIHAT DATA JADWAL :.").SetLength(88).SetForeColor(ConsoleColor.White);
            Judul.TampilTengah();

            DB.Connect();
            DataTable DT = DB.RunQuery("SELECT * FROM tb_jadwal;");

            new Tulisan("┌───────────┬──────────────────┬──────────────────┬───────────────────────────────┐").SetXY(34, 10).SetForeColor(ConsoleColor.White).Tampil();
            new Tulisan("│    NO     │       HARI       │       JAM        │          KETERANGAN           │").SetXY(34, 11).SetForeColor(ConsoleColor.White).Tampil();
            new Tulisan("├───────────┼──────────────────┼──────────────────┼───────────────────────────────┤").SetXY(34, 12).SetForeColor(ConsoleColor.White).Tampil();

            for(int i = 0; i < DT.Rows.Count; i++)
            {
                string ID = DT.Rows[i]["id"].ToString();
                string Hari = DT.Rows[i]["hari"].ToString();
                string Jam = DT.Rows[i]["jam"].ToString();
                string Keterangan = DT.Rows[i]["ket"].ToString();

                string isi = string.Format("│{0, -11}│{1, -18}│{2, -18}│{3, -31}│", ID, Hari, Jam, Keterangan);
                new Tulisan(isi).SetXY(34, 13 + i).SetForeColor(ConsoleColor.White).Tampil();

            }

            new Tulisan("└───────────┴──────────────────┴──────────────────┴───────────────────────────────┘").SetXY(34, 13 + DT.Rows.Count).SetForeColor(ConsoleColor.White).Tampil();

        }


        static void TambahJadwal()
        {
            new Clear(32, 7, 87, 16).Tampil();

            Tulisan Judul = new Tulisan();
            Judul.SetXY(31, 7).SetText(".: TAMBAH DATA JADWAL :.").SetLength(88).SetForeColor(ConsoleColor.White);
            Judul.TampilTengah();

            Inputan HariInput = new Inputan();
            HariInput.Text = "Masukkan Hari  :";
            HariInput.SetXY(33, 9);
            HariInput.SetForeColor(ConsoleColor.White);

            Inputan JamInput = new Inputan();
            JamInput.Text = "Masukkan Jam   :";
            JamInput.SetXY(33, 10);
            JamInput.SetForeColor(ConsoleColor.White);

            Inputan KetInput = new Inputan();
            KetInput.Text = "Masukkan Keterangan  :";
            KetInput.SetXY(33, 11);
            KetInput.SetForeColor(ConsoleColor.White);

            //Inputan SoundInput = new Inputan();
            //SoundInput.Text = "Masukkan Audio  :";
            //SoundInput.SetXY(33, 12);

            Pilihan SoundInput = new Pilihan();
            SoundInput.SetPilihans(
                "pembuka.wav",
                "Pelajaran ke 1.wav",
                "Pelajaran ke 2.wav",
                "Pelajaran ke 3.wav",
                "Akhir Pelajaran A.wav",
                "Istirahat I.wav",
                "5 Menit Akhir Istirahat I.wav",
                "Akhir Pekan 1.wav");

            SoundInput.Text = "Masukkan Audio : ";
            SoundInput.SetXY(33, 12);
            SoundInput.SetForeColor(ConsoleColor.White);

            String Hari = HariInput.Read();
            String Jam = JamInput.Read();
            String Ket = KetInput.Read();
            String Sound = SoundInput.Read();

            DB.Connect();
            DB.RunNonQuery("INSERT INTO tb_jadwal(hari, jam, ket, sound) VALUES (@hari, @jam, @ket, @sound);",
                new OleDbParameter("@hari", Hari),
                new OleDbParameter("@jam", Jam),
                new OleDbParameter("@ket", Ket),
                new OleDbParameter("@sound", Sound));

            DB.Disconnect();

            new Tulisan().SetXY(31, 17).SetText("Data Berhasil Di Simpan!!!").SetBackColor(ConsoleColor.Red).SetLength(89).TampilTengah();

        }
        static void EditJadwal()
        {
            new Clear(32, 7, 87, 16).Tampil();

            Tulisan Judul = new Tulisan();
            Judul.SetXY(31, 7).SetText(".: EDIT DATA JADWAL :.").SetLength(88).SetForeColor(ConsoleColor.White);
            Judul.TampilTengah();

            Inputan IDInputDirubah = new Inputan();
            IDInputDirubah.Text = "Masukkan ID Jadwal Yang Ingin Di Rubah :";
            IDInputDirubah.SetXY(33, 9);
            IDInputDirubah.SetForeColor(ConsoleColor.White);

            Inputan HariInput = new Inputan();
            HariInput.Text = "Masukkan Hari  :";
            HariInput.SetXY(33, 10);
            HariInput.SetForeColor(ConsoleColor.White);

            Inputan JamInput = new Inputan();
            JamInput.Text = "Masukkan Jam   :";
            JamInput.SetXY(33, 11);
            JamInput.SetForeColor(ConsoleColor.White);

            Inputan KetInput = new Inputan();
            KetInput.Text = "Masukkan Keterangan  :";
            KetInput.SetXY(33, 12);
            KetInput.SetForeColor(ConsoleColor.White);

            //Inputan SoundInput = new Inputan();
            //SoundInput.Text = "Masukkan Sound  :";
            //SoundInput.SetXY(33, 12);

            Pilihan SoundInput = new Pilihan();
            SoundInput.SetPilihans(
                "pembuka.wav",
                "Pelajaran ke 1.wav",
                "Pelajaran ke 2.wav",
                "Pelajaran ke 3.wav",
                "Akhir Pelajaran A.wav",
                "Istirahat I.wav",
                "5 Menit Akhir Istirahat I.wav",
                "Akhir Pekan 1.wav");

            SoundInput.Text = "Masukkan Audio : ";
            SoundInput.SetXY(33, 13);
            SoundInput.SetForeColor(ConsoleColor.White);

            string IDRubah = IDInputDirubah.Read();
            String Hari = HariInput.Read();
            String Jam = JamInput.Read();
            String Ket = KetInput.Read();
            String Sound = SoundInput.Read();

            DB.Connect();
            DB.RunNonQuery("UPDATE tb_jadwal SET hari=@hari, jam=@jam, ket=@ket, sound=@sound WHERE id=@id;",
                new OleDbParameter("@hari", Hari),
                new OleDbParameter("@jam", Jam),
                new OleDbParameter("@ket", Ket),
                new OleDbParameter("@sound", Sound),
                new OleDbParameter("@id", IDRubah));

            DB.Disconnect();

            new Tulisan().SetXY(31, 18).SetText("Data Berhasil Di Simpan!!!").SetBackColor(ConsoleColor.Red).SetLength(89).TampilTengah();


        }
        static void HapusJadwal()
        {
            new Clear(32, 7, 87, 16).Tampil();

            Tulisan Judul = new Tulisan();
            Judul.SetXY(31, 7).SetText(".: HAPUS DATA JADWAL :.").SetLength(88).SetForeColor(ConsoleColor.White);
            Judul.TampilTengah();

            Inputan IDInput = new Inputan();
            IDInput.Text = "Masukkan ID Yang Akan Di Hapus  :";
            IDInput.SetXY(33, 9);
            IDInput.SetForeColor(ConsoleColor.White);
            string ID = IDInput.Read();

            // Cara Pertama
            //DB.Connect();
            //DB.RunNonQuery("DELETE FROM tb_jadwal WHERE id=" + ID + ";");

            DB.Connect();
            DB.RunNonQuery("DELETE FROM tb_jadwal WHERE id=@id",
                new OleDbParameter("@id", ID));

            new Tulisan().SetXY(31, 12).SetText("Data Berhasil Di Hapus!!!").SetBackColor(ConsoleColor.Red).SetLength(89).TampilTengah();

        }
        static void Keluar()
        {
            Tulisan Judul = new Tulisan();
            Judul.SetXY(31, 7).SetText(".: KELUAR PROGRAM :.").SetLength(88);
            Judul.TampilTengah();
        }

    }
}
