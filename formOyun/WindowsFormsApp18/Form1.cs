/***********************************************************************************************************************************
 SAKARYA ÜNİVERSİTESİ
 BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
 BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
 NESNEYE DAYALI PROGRAMLAMA DERSİ
 2019-2020 BAHAR DÖNEMİ
 ADI:ZEHRA BEGÜM  SOYADI:AKTOLGA   NUMARASI:B191210062   GRUP:1C GRUBU 1.ÖĞRETİM
/***********************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp18
{
    public partial class Form1 : Form
    {
        static int Sonuc = 0;
        static int Zaman = 59;
        public static Random Random = new Random();
        public interface IAtik
        {
            int Hacim { get; }
            System.Drawing.Image Image { get; }
        }
        public interface IAtikKutusu : IDolabilen
        {
            int BosaltmaPuani { get; }
            bool Ekle();
            bool Bosalt();
        }
        public interface IDolabilen
        {
            int Kapasite { get; set; }
            int DoluHacim { get; }
            int DolulukOrani { get; }
        }
        class Hacim :IAtikKutusu
        {
            private int _puan = 1000;
            public int _kapasite;
            public int _doluHacim = 525;
            public int _dolulukOrani = 75;
            public int BosaltmaPuani
            {
                get
                {
                   return _puan;
                }
            }
            public int Kapasite
            {
                get
                {
                    return _kapasite;
                }
                set
                {
                    _kapasite = value;
                }
            }
            public int DoluHacim
            {
                get
                {
                    return _doluHacim;
                }
            }
            public int DolulukOrani
            {
                get
                {
                    return _dolulukOrani;
                }
            }
            public bool Bosalt()
            {
                throw new NotImplementedException();
            }
            public bool Ekle()
            {
                throw new NotImplementedException();
            }
        }
        class Resim : IAtik
        {
            private int _hacim=150;
            private Image _resim;
            public int Hacim
            {
                get
                {  
                   return _hacim;
                }
            }
            public Image Image
            {
                get
                {
                    return _resim;
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // SÜRENİN FORM DA DÜZGÜN DURMASINI SAĞLAR.
            if(Zaman<10 && Zaman>=0)
            {
                label1.Text = " "+" "+Zaman.ToString();
            }
            else if(Zaman>0)
            {
                label1.Text = " " + Zaman.ToString();
            }
            Zaman--;
            // SÜRE BİTTİYSE YENİ OYUN BUTONUNU AKTİF HALE GETİRİR.AYRICA ZAMANI DA DURDURUR.
            if (Zaman < 0)
            {
                timer1.Stop();
                button1.Enabled = true;
            }
            // SÜRE BİTMEDİYSE YENİ OYUN BUTONUNU PASİF HALDE TUTAR.
            if(Zaman > 0)
            {
                button1.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Resim resim = new Resim();
            Hacim hacim = new Hacim();
            hacim._kapasite=700;
            // RESİM DOĞRUYSA VE HACİM YETERLİYSE EKLEMELERİ YAPAR.
            if(label6.ImageIndex==3 && progressBar1.Value <= hacim._kapasite - 150)
            {
                   label6.ImageIndex = Random.Next(0, 8);
                   progressBar1.Step = resim.Hacim;
                   progressBar1.PerformStep();
                   listBox1.Items.Add("Domates(150)");
                   Sonuc += 150;
                   label2.Text = Convert.ToString(Sonuc);
            }
            // RESİM DOĞRUYSA VE HACİM YETERLİYSE EKLEMELERİ YAPAR.
            else if (label6.ImageIndex == 6 && progressBar1.Value <= hacim._kapasite - 120)
            {
                   label6.ImageIndex = Random.Next(0, 8);
                   progressBar1.Step = resim.Hacim-30;
                   progressBar1.PerformStep();
                   listBox1.Items.Add("Salatalık(120)");
                   Sonuc += 120;
                   label2.Text = Convert.ToString(Sonuc);
            }                 
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Resim resim = new Resim();
            Hacim hacim = new Hacim();
            hacim._kapasite = 1200;
            // RESİM DOĞRUYSA VE HACİM YETERLİYSE EKLEMELERİ YAPAR.
            if (label6.ImageIndex == 2 && progressBar2.Value <= hacim._kapasite - 200)
            {
                   label6.ImageIndex = Random.Next(0, 8);
                   progressBar2.Step = resim.Hacim+50;
                   progressBar2.PerformStep();
                   listBox2.Items.Add("Dergi(200)");
                   Sonuc += 200;
                   label2.Text = Convert.ToString(Sonuc);
            }
            // RESİM DOĞRUYSA VE HACİM YETERLİYSE EKLEMELERİ YAPAR.
            else if (label6.ImageIndex == 4 && progressBar2.Value <= hacim._kapasite - 250)
            {
                   label6.ImageIndex = Random.Next(0, 8);
                   progressBar2.Step = resim.Hacim +100;
                   progressBar2.PerformStep();
                   listBox2.Items.Add("Gazete(250)");
                   Sonuc += 250;
                   label2.Text = Convert.ToString(Sonuc);
            }            
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Resim resim = new Resim();
            Hacim hacim = new Hacim();
            hacim._kapasite = 2200;
            // RESİM DOĞRUYSA VE HACİM YETERLİYSE EKLEMELERİ YAPAR.
            if (label6.ImageIndex == 0 && progressBar3.Value<=hacim._kapasite-250)
            {
                    label6.ImageIndex = Random.Next(0, 8);
                    progressBar3.Step = resim.Hacim + 100;
                    progressBar3.PerformStep();
                    listBox3.Items.Add("Bardak(250)");
                    Sonuc += 250;
                    label2.Text = Convert.ToString(Sonuc);
            }
            // RESİM DOĞRUYSA VE HACİM YETERLİYSE EKLEMELERİ YAPAR.
            else if (label6.ImageIndex == 1 && progressBar3.Value <=hacim._kapasite-600)
            {
                    label6.ImageIndex = Random.Next(0, 8);
                    progressBar3.Step = resim.Hacim+450;
                    progressBar3.PerformStep();
                    listBox3.Items.Add("Cam şişe(600)");
                    Sonuc += 600;
                    label2.Text = Convert.ToString(Sonuc);
            }                          
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Resim resim = new Resim();
            Hacim hacim = new Hacim();
            hacim._kapasite = 2300;
            // RESİM DOĞRUYSA VE HACİM YETERLİYSE EKLEMELERİ YAPAR.
            if (label6.ImageIndex == 5 && progressBar4.Value <= hacim._kapasite - 350)
            {
                     label6.ImageIndex = Random.Next(0, 8);
                     progressBar4.Step = resim.Hacim+200;
                     progressBar4.PerformStep();
                     listBox4.Items.Add("Kola kutusu350)");
                     Sonuc += 350;
                     label2.Text = Convert.ToString(Sonuc);
            }
            // RESİM DOĞRUYSA VE HACİM YETERLİYSE EKLEMELERİ YAPAR.
            else if (label6.ImageIndex == 7 && progressBar4.Value <= hacim._kapasite - 550)
            {
                     label6.ImageIndex = Random.Next(0, 8);
                     progressBar4.Step = resim.Hacim+400;
                     progressBar4.PerformStep();
                     listBox4.Items.Add("Salça kutusu(550)");
                     Sonuc += 550;
                     label2.Text = Convert.ToString(Sonuc);
            }                         
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Hacim hacim = new Hacim();
            // HACİMİN YÜZDE 70'İ DOLUYSA BOŞALTIR VE SÜRE EKLER.
            if (progressBar1.Value >= hacim._doluHacim)
            {
                progressBar1.Value = 0;
                listBox1.Items.Clear();
                Zaman += 4;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Hacim hacim = new Hacim();
            // HACİMİN YÜZDE 70'İ DOLUYSA BOŞALTIR , SÜRE VE PUAN EKLER.
            if (progressBar2.Value >= hacim._doluHacim+375)
            {
                    progressBar2.Value = 0;
                    listBox2.Items.Clear();
                    Zaman+=4;
                    Sonuc += hacim.BosaltmaPuani;
                    label2.Text = Convert.ToString(Sonuc);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Hacim hacim = new Hacim();
            // HACİMİN YÜZDE 70'İ DOLUYSA BOŞALTIR , SÜRE VE PUAN EKLER.
            if (progressBar3.Value >=hacim._doluHacim+1125)
            {
                    progressBar3.Value = 0;
                    listBox3.Items.Clear();
                    Zaman += 4;
                    Sonuc += hacim.BosaltmaPuani-400;
                    label2.Text = Convert.ToString(Sonuc);
            }          
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Hacim hacim = new Hacim();
            // HACİMİN YÜZDE 70'İ DOLUYSA BOŞALTIR , SÜRE VE PUAN EKLER.
            if (progressBar4.Value >= hacim._doluHacim+1200)
            {
                    progressBar4.Value = 0;
                    listBox4.Items.Clear();
                    Zaman += 4;
                    Sonuc += hacim.BosaltmaPuani - 200;
                    label2.Text = Convert.ToString(Sonuc);
            }          
        }
        private void button1_Click(object sender, EventArgs e)
        {
             timer1.Start();
             label6.ImageIndex = Random.Next(0, 8);
             listBox1.Items.Clear();
             listBox2.Items.Clear();
             listBox3.Items.Clear();
             listBox4.Items.Clear();
             progressBar1.Value = 0;
             progressBar2.Value = 0;
             progressBar3.Value = 0;
             progressBar4.Value = 0;
             label2.Text = " " + " " + "0";
             label1.Text = " " + "60";
             Zaman = 59; 
        }
    }
}
