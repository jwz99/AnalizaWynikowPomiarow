using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {

        public List<float> listaProbki = new List<float>();
        string srednia;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(List<float> listaProbki, string srednia)
        {
            InitializeComponent();
            this.listaProbki = listaProbki;
            this.srednia = srednia;
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            int averageInt = (int)Math.Round(float.Parse(srednia));
            for (int i = 0; i < listaProbki.Count; i++)
            {
                chart1.Series["Wszystkie pomiary"].Points.AddXY(i, listaProbki[i]);
                chart1.Series["Średnia arytmetyczna"].Points.AddXY(i, averageInt);
            }
            if(comboBox1.SelectedIndex == -1)
            {
                chart1.Series["Średnia arytmetyczna"].Color = System.Drawing.Color.Red;
                comboBox1.SelectedIndex = 1;
            }
                
            if (comboBox2.SelectedIndex == -1)
            {
                chart1.Series["Wszystkie pomiary"].Color = System.Drawing.Color.Green;
                comboBox2.SelectedIndex = 0;
            }
                
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                chart1.Legends["Legend1"].Enabled = false;
            else
                chart1.Legends["Legend1"].Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
                chart1.Series["Średnia arytmetyczna"].Enabled = false;
            else
                chart1.Series["Średnia arytmetyczna"].Enabled = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
                chart1.Series["Wszystkie pomiary"].Enabled = false;
            else
                chart1.Series["Wszystkie pomiary"].Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                chart1.Series["Średnia arytmetyczna"].Color = System.Drawing.Color.Green;
            else if (comboBox1.SelectedIndex == 1)
                chart1.Series["Średnia arytmetyczna"].Color = System.Drawing.Color.Red;
            else if (comboBox1.SelectedIndex == 2)
                chart1.Series["Średnia arytmetyczna"].Color = System.Drawing.Color.Pink;
            else if (comboBox1.SelectedIndex == 3)
                chart1.Series["Średnia arytmetyczna"].Color = System.Drawing.Color.Yellow;
            else if (comboBox1.SelectedIndex == 4)
                chart1.Series["Średnia arytmetyczna"].Color = System.Drawing.Color.Black;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == 0)
                chart1.Series["Wszystkie pomiary"].Color = System.Drawing.Color.Green;
            else if (comboBox2.SelectedIndex == 1)
                chart1.Series["Wszystkie pomiary"].Color = System.Drawing.Color.Red;
            else if (comboBox2.SelectedIndex == 2)
                chart1.Series["Wszystkie pomiary"].Color = System.Drawing.Color.Pink;
            else if (comboBox2.SelectedIndex == 3)
                chart1.Series["Wszystkie pomiary"].Color = System.Drawing.Color.Yellow;
            else if (comboBox2.SelectedIndex == 4)
                chart1.Series["Wszystkie pomiary"].Color = System.Drawing.Color.Black;
        }
    }
}
