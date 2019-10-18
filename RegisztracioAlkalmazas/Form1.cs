using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("Úszás");
            listBox1.Items.Add("Horgászat");
            listBox1.Items.Add("Futás");

            saveFileDialog1.FileOk += (senderFile, eFile) => 
            {
                try
                {
                    string fileName = saveFileDialog1.FileName;
                    (fileName, listBox1.Items.Cast<String>().ToArray()); 
                 
                }
                catch (Exception)
                {

                    MessageBox.Show("Hiba! Nem sikerült a kiírás");
                }
            };

           
            openFileDialog1.FileOk += (sender, e) =>
            {
                try
                {
                    string[] sorok = File.ReadAllLines(openFileDialog1.FileName);
                    
                    listBox1.Items.Clear();
                    foreach (var item in sorok) 
                    {
                        listBox1.Items.Add(item);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Hiba! sikertelen betöltés.");
                }
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Hozzaadas_Click(object sender, EventArgs e)
        {           
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
