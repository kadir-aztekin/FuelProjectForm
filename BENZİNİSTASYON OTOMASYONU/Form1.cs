using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BENZİNİSTASYON_OTOMASYONU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
        double D_benzin95 = 0, D_benzin97 = 0, D_dizel = 0, D_eurodizel = 0, D_lpg = 0;
        double E_benzin95 = 0, E_benzin97 = 0, E_dizel = 0, E_eurodizel = 0, E_lpg = 0;
        double F_benzin95 = 0, F_benzin97 = 0, F_dizel = 0, F_eurodizel = 0, F_lpg = 0;
        double S_benzin95 = 0, S_benzin97 = 0, S_dizel = 0, S_eurodizel = 0, S_lpg = 0;
        string[] depo_bilgiler;
        string[] fiyat_bilgileri;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                E_benzin95 = Convert.ToDouble(textBox1.Text);
                if (1000 < D_benzin95 + E_benzin95 || D_benzin95 <= 0)
                    textBox1.Text = "HATA!";
                else
                    depo_bilgiler[0] = Convert.ToString(D_benzin95 + E_benzin95);
            }
            catch (Exception)
            {

                textBox1.Text = "HATA!";
            }
            try
            {
                E_benzin97 = Convert.ToDouble(textBox2.Text);
                if (1000 < D_benzin97 + E_benzin97 || D_benzin97 <= 0)
                    textBox2.Text = "HATA!";
                else
                    depo_bilgiler[1] = Convert.ToString(D_benzin97 + E_benzin97);
            }
            catch (Exception)
            {

                textBox2.Text = "HATA!";
            }
            try
            {
                E_dizel = Convert.ToDouble(textBox3.Text);
                if (1000 < D_dizel + E_dizel || D_dizel <= 0)
                    textBox3.Text = "HATA!";
                else
                    depo_bilgiler[2] = Convert.ToString(D_dizel + E_dizel);
            }
            catch (Exception)
            {

                textBox3.Text = "HATA!";
            }
            try
            {
                E_eurodizel = Convert.ToDouble(textBox4.Text);
                if (1000 < D_eurodizel + E_eurodizel || D_eurodizel <= 0)
                    textBox4.Text = "HATA!";
                else
                    depo_bilgiler[3] = Convert.ToString(D_eurodizel + E_eurodizel);
            }
            catch (Exception)
            {

                textBox4.Text = "HATA!";
            }
            try
            {
                E_lpg= Convert.ToDouble(textBox5.Text);
                if (1000 < D_lpg + E_lpg || D_lpg <= 0)
                    textBox5.Text = "HATA!";
                else
                    depo_bilgiler[4] = Convert.ToString(D_lpg + E_lpg);
            }
            catch (Exception)
            {

                textBox5.Text = "HATA!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo_bilgiler);
            txt_depo_oku();
            txt_depo_yaz();
            numericupdown_value();

        }

        

        private void txt_depo_oku()
        {
            depo_bilgiler = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_benzin95 = Convert.ToDouble(depo_bilgiler[0]);
            D_benzin97 = Convert.ToDouble(depo_bilgiler[1]);
            D_dizel = Convert.ToDouble(depo_bilgiler[2]);
            D_eurodizel = Convert.ToDouble(depo_bilgiler[3]);
            D_lpg = Convert.ToDouble(depo_bilgiler[4]);
        }
        private void txt_depo_yaz()
        {
            label6.Text = D_benzin95.ToString("N");
            label7.Text = D_benzin97.ToString("N");
            label8.Text = D_dizel.ToString("N");
            label9.Text = D_eurodizel.ToString("N");
            label10.Text = D_lpg.ToString("N");
        }
        private void txt_fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            F_dizel = Convert.ToDouble(fiyat_bilgileri[2]);
            F_eurodizel = Convert.ToDouble(fiyat_bilgileri[3]);
            F_lpg = Convert.ToDouble(fiyat_bilgileri[4]);
        }
        private void txt_fiyat_yaz()
        {
            label16.Text = F_benzin95.ToString("N");
            label17.Text = F_benzin97.ToString("N");
            label18.Text = F_dizel.ToString("N");
            label19.Text = F_eurodizel.ToString("N");
            label20.Text = F_lpg.ToString("N");
        }
        private void numericupdown_value()
        {
            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(D_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_eurodizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(D_lpg.ToString());



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "AKARYAKIT OTOMASYONU ";
            

            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            numericupdown_value();

            string[] yakit_türleri = { "BENZİN(95)", "BENZİN(97)", "DİZEL", "EURODİZEL", "LPG" };
            comboBox1.Items.AddRange(yakit_türleri);

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;

            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
