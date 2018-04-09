using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // string pt = "";  
        // Stack<string> undoList = new Stack<string>();
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font=fontDialog1.Font;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
             this.richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count=0;
            openFileDialog1.InitialDirectory = "D:";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
           // Form1 form = new Form1();
            richTextBox1.Text = "";
           if (openFileDialog1.ShowDialog() == DialogResult.OK)  
            {
                this.Text = this.Text + openFileDialog1.FileName;
               using (StreamReader sr = File.OpenText(openFileDialog1.FileName))  
                {  
                    string s = "";  
                    while ((s = sr.ReadLine()) != null)  
                    {  
                        this.richTextBox1.AppendText(s + Environment.NewLine);  
 
                        count = count + s.Length + 1;  
                    }  
                }  

           }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

           // String Filename = "";
            saveFileDialog1.Title= "Save";
             if (File.Exists(saveFileDialog1.FileName))
             {
                 richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
             }
            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = this.Text + saveFileDialog1.FileName;
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

            // String Filename = "";
            saveFileDialog1.Title = "Save as";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form f = new Form(){Height=100,Width=500,Text="Notepad"};
            f.Show();
          //  f.MdiParent = this;
            Label l1 = new Label() { Left = 0, Top = 0,Height=20,Width=200,Text = "Do you Want to Save?" };
            Button save = new Button(){Left = 50, Top=20, Text="Save" };
            Button DonotSave = new Button() { Left = 150, Top = 20, Text = "DonotSave" };
            Button Cancle= new Button(){Left = 300, Top=20, Text="Save" };
            f.Controls.Add(l1);
            f.Controls.Add(save);
            f.Controls.Add(DonotSave);
            f.Controls.Add(Cancle);
            save.Click += (ob,eve) =>
            {
                    f.Close();
                    saveFileDialog1.InitialDirectory = "D:";
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

                    // String Filename = "";
                    saveFileDialog1.Title = "Save";
                    if (File.Exists(saveFileDialog1.FileName))
                    {
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                    else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.Text = this.Text + saveFileDialog1.FileName;
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                     this.Close();
           };

            DonotSave.Click += (ob, eve) =>
            {
                f.Close();
                this.Close();
            };
            
            Cancle.Click += (ob, eve) =>
            {
                  f.Close();
            };
        }
        

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);// cut selected text
            richTextBox1.SelectedText = String.Empty;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Clipboard.SetText(richTextBox1.SelectedText);//copy all the text of textbox
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //String a = Clipboard.GetText();
            //richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, a);//past at select pointer
            richTextBox1.Paste();
        }
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // Clipboard.SetText(richTextBox1.SelectedText);// cut selected text of textboxt
           // richTextBox1.SelectedText = String.Empty;
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);//copy selected text of textbox
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            String a = Clipboard.GetText();
            richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, a);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                richTextBox1.Undo();
           
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                richTextBox1.Redo();
           
        }

        private void fullWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            richTextBox1.Width = 1401;
            richTextBox1.Height = 699;
        }
        void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }
        private void Form1_Load(object sender, EventArgs e)
        {
                
        }
        private void formateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void Maximize_Click(object sender, EventArgs e)
        {
            richTextBox1.Width = 1401;
            richTextBox1.Height = 699;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
