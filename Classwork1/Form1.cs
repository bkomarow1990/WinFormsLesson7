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

namespace Classwork1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //this.richTextBox1.sele
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
            
            
        }

        private void fontBtn_Click(object sender, EventArgs e)
        {
            fontDialog1.Color = Color.Black;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
                richTextBox1.SelectionColor = fontDialog1.Color;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Txt files(*.txt)|*.txt|Rich files(*.rtf)||All files(*.*)|*.*||";
            openFileDialog1.FilterIndex = 3;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                switch (openFileDialog1.FilterIndex)
                {
                   
                    case 1:
                    case 3:
                    case 0:
                        richTextBox1.Text =  File.ReadAllText(path);
                        break;
                    case 2:
                        if (Path.GetExtension(path) == ".rtf")
                        {
                            richTextBox1.LoadFile(path, RichTextBoxStreamType.RichText);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string path;
            saveFileDialog1.Filter = "Txt files(*.txt)|*.txt|Rich files(*.rtf)||All files(*.*)|*.*||";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                switch (Path.GetExtension(path))
                {
                    case ".txt":
                        File.WriteAllText(path, richTextBox1.Text);
                        break;
                    case ".rtf":
                        richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
