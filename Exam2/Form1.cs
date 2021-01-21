using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Exam2
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> list;
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            textBox5.Visible = false;
            label5.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            listBox1.Visible = false;

            XmlTextReader reader = null;
            list = new Dictionary<string, List<string>>();
            try
            {
                reader = new XmlTextReader(@"info.xml");
                reader.WhitespaceHandling =
                WhitespaceHandling.None;
                while (reader.Read())
                {
                    Console.WriteLine(reader.NodeType + " \\ " + reader.Name);
                    if (reader.NodeType == XmlNodeType.Element && reader.Name.Contains("Dish"))
                    {
                        reader.Read();
                        reader.Read();
                        string temp = reader.Value;
                        list[temp] = new List<string>();
                        reader.Read();
                        reader.Read();
                        reader.Read();
                        list[temp].Add(reader.Value);
                        reader.Read();
                        reader.Read();
                        reader.Read();
                        list[temp].Add(reader.Value);
                        reader.Read();
                        reader.Read();
                        reader.Read();
                        list[temp].Add(reader.Value);
                        reader.Read();
                        reader.Read();
                        reader.Read();
                        list[temp].Add(reader.Value);
                        reader.Read();
                        reader.Read();
                        reader.Read();
                        list[temp].Add(reader.Value);
                    }
                }

            }
            finally
            {
                if (reader != null)
                    reader.Close();

            }

        }

        private void Save()
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter("info.xml", System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Recipes");
                foreach (string tmp in list.Keys)
                {
                    writer.WriteStartElement($"Dish");
                    writer.WriteElementString("Name", tmp);
                    writer.WriteElementString("Cuisine", list[tmp][0]);
                    writer.WriteElementString("Type", list[tmp][1]);
                    writer.WriteElementString("Composition", list[tmp][2]);
                    writer.WriteElementString("Method_of_cooking", list[tmp][3]);
                    writer.WriteElementString("Author", list[tmp][4]);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Width = 320;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            button4.Visible = true;
            button5.Visible = true;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Width = 816;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;

            textBox5.Visible = false;
            label5.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            listBox1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            list[textBox1.Text.ToString()] = new List<string>();
            list[textBox1.Text.ToString()].Add(textBox6.Text.ToString());
            list[textBox1.Text.ToString()].Add(textBox7.Text.ToString());
            list[textBox1.Text.ToString()].Add(textBox2.Text.ToString());
            list[textBox1.Text.ToString()].Add(textBox4.Text.ToString());
            list[textBox1.Text.ToString()].Add(textBox3.Text.ToString());
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Visible = true;
            label5.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            listBox1.Visible = true;
            button5.Visible = true;
            button6.Visible = true;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radioButton2.Checked == true)
            {
                if (list.ContainsKey(textBox5.Text.ToString())) {
                    listBox1.Items.Add(textBox5.Text.ToString());
                }
            }
            else if (radioButton1.Checked == true)
            {
                foreach (string tmp in list.Keys)
                {
                    if (list[tmp][0] == textBox5.Text)
                    {
                        listBox1.Items.Add(textBox5.Text.ToString());
                    }
                }
            }
            else if (radioButton3.Checked == true)
            {
                foreach (string tmp in list.Keys)
                {
                    List<string> temp = new List<string>();
                    foreach (string test in list[tmp][2].Split(','))
                    {
                        //if (test[0] == ' ')
                        //{
                        //    test.Trim(" ");
                        //}
                        //test.
                        temp.Add(test.Replace(" ", string.Empty));
                    }
                    if (temp.Contains(textBox5.Text))
                    {
                        listBox1.Items.Add(tmp);
                    }
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Width = 320;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                button8.Visible = true;
                button7.Visible = true;

                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;


                textBox5.Visible = false;
                label5.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                listBox1.Visible = false;
                button5.Visible = false;
                button6.Visible = false;


                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox6.Text = list[listBox1.SelectedItem.ToString()][0];
                textBox7.Text = list[listBox1.SelectedItem.ToString()][1];
                textBox2.Text = list[listBox1.SelectedItem.ToString()][2];
                textBox4.Text = list[listBox1.SelectedItem.ToString()][3];
                textBox3.Text = list[listBox1.SelectedItem.ToString()][4];
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            textBox5.Visible = true;
            label5.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            listBox1.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            list.Remove(textBox1.Text);
            button4_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }
    }
}
