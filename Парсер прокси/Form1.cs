using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xNet;
using System.Text.RegularExpressions;
using System.Threading;

namespace Парсер_прокси
{
    public partial class Form1 : Form
    {
        Thread[] Potok = new Thread[1];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Potok[0] = new Thread(Poluchit_proxy);
            Potok[0].Start();
        }/*Cтарт*/

        void Poluchit_proxy()
        {
            int count = 0;
            this.Invoke((MethodInvoker)delegate() { count = richTextBox2.Lines.Count(); });
           

            for (int i = 0; i < count; i++)
            {
                var danni = new HttpRequest();

                string lines = "";
                this.Invoke((MethodInvoker)delegate() { lines = richTextBox2.Lines[i]; });
                
                string response = danni.Get(lines).ToString();
                Regular_Virag(response);
            }
        }/*Получить прокси*/

        void Regular_Virag(string response)
        {
            Regex regex = new Regex(@"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{1,5}");
            MatchCollection matches = regex.Matches(response);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    this.Invoke((MethodInvoker)delegate() { richTextBox1.Text += match.Value + "\n"; });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Potok[0].Abort();
        }/*Стоп*/

        private void button2_Click(object sender, EventArgs e)
        {
            OpenSaveTxtFile.OpenSave_Files.Save_Vibor_Polzovatelya(richTextBox1.Text);
        }/*Сохранить*/

        private void button3_Click(object sender, EventArgs e)
        {
            string q = "";
            OpenSaveTxtFile.OpenSave_Files.Open_Vibor_Polzovatelya(ref q);
            richTextBox2.Text = q;
        }/*Открыть*/

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Text = "Proxy ["+richTextBox1.Lines.Count().ToString()+"]";
        }/*Кол-во строк прокси*/

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            groupBox2.Text = "Сайты [" + richTextBox2.Lines.Count().ToString() + "]";
        }/*кол-ви строк сайты*/
    }


}
