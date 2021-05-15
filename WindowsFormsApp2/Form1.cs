using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<float> listProbki = new List<float>();
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        OpenFileDialog open = new OpenFileDialog();
        private void button1_Click_1(object sender, EventArgs e)
        {
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            open.Filter = "(*.txt)|*.txt";
            string ln = "", text = "", n = "";
            float results = 0, x, indeks = 0;
            if (open.ShowDialog() == DialogResult.OK)
            {
                var fs = open.OpenFile();
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    ln = sr.ReadLine();
                    n = Regex.Replace(ln, "[^0-9,]", " ");
                    if (float.TryParse(n, out results))
                    {
                        x = float.Parse(n);
                        listProbki.Add(x);
                        text += x.ToString();
                        indeks++;
                    }
                }
            }
            try
            {
                float średnia = 0, min = listProbki[0], max = listProbki[0], wariancja = 0;
                for (int i = 0; i < indeks; i++)
                {
                    średnia += listProbki[i];
                    if (listProbki[i] > max)
                        max = listProbki[i];
                    if (listProbki[i] < min)
                        min = listProbki[i];
                }
                średnia /= indeks;
                for (int i = 0; i < indeks; i++)
                {
                    wariancja += (listProbki[i] - średnia) * (listProbki[i] - średnia);
                }
                wariancja /= indeks;
                textBox1.Text = średnia.ToString();
                textBox4.Text = max.ToString();
                textBox2.Text = min.ToString();
                textBox3.Text = wariancja.ToString();
                textBox5.Text = text;
                decimal index;
                index = Convert.ToDecimal(indeks);
                numericUpDown1.Maximum = index;
                button2.Enabled = true;
                button4.Enabled = true;
                button3.Enabled = true;
                MessageBox.Show("Pomyślnie wczytano plik");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String text, plik;
                text = "Wartość średnia - " + textBox1.Text + " " + "Wartość minimalna - " + textBox2.Text + " " + "Wartość maksymalna - " + textBox4.Text + " " + " Wariancja - " + textBox3.Text;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
                dialog.ShowDialog();
                if (dialog.FileName != "")
                {
                    plik = dialog.FileName;
                    StreamWriter sw = new StreamWriter(plik);
                    sw.Write(text);
                    sw.Close();
                }
                MessageBox.Show("Pomyślnie zapisano plik");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(listProbki,textBox1.Text);
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                string text = "", plik = "";
                for (int i = 0; i < count; i++)
                {
                    text += listProbki[i].ToString();
                    text += " ";
                }
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "(*.txt)|*.txt";
                dialog.ShowDialog();
                if (dialog.FileName != "")
                {
                    plik = dialog.FileName;
                    StreamWriter f = new StreamWriter(plik);
                    f.Write(text);
                    f.Close();
                    MessageBox.Show("Pomyślnie zapisano plik");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

    }
}
