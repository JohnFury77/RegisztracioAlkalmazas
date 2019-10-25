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
                    StreamWriter sw = new StreamWriter(fileName);
                    sw.Write(textBox2.Text+";");
                    sw.Write(textBox3.Text+";");
                    sw.Write(listBox1.Text+";");
                    if (radioButton1.Checked==true)
                    {
                        sw.Write("Férfi;");
                    }
                    else if(radioButton2.Checked==true)
                    {
                        sw.Write("Nő;");
                    }
                    foreach (var item in listBox1.Items)
                    {
                        sw.Write(item+",");
                    }

                    sw.Close();
                   
                 
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
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    string sor = sr.ReadLine();
                    string[] nev = sor.Split(';');
                    
                    textBox2.Text = nev[0];
                    textBox3.Text = nev[1];
                    
                    if (nev[3]=="Férfi")
                    {
                        radioButton1.Checked = true;
                    }
                    else if(nev[3] == "Nő")
                    {
                        radioButton2.Checked = true;
                    }
                    string[] hobbitok = nev[4].Split(',');
                    listBox1.Items.Clear();
                    for (int i = 0; i < hobbitok.Length; i++)
                    {
                        listBox1.Items.Add(hobbitok[i]);
                        if (hobbitok[i] == nev[2])
                        {
                            listBox1.SelectedItem = hobbitok[i];
                        }
                    }

                    /*listBox1.Items.Clear();
                    foreach (var item in sorok) 
                    {
                        listBox1.Items.Add(item);
                    }*/
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

        private void Mentes_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

        }

        private void Betöltés_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
