using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1.CustomControl
{
    public partial class CustomTextbox : UserControl
    {
        public CustomTextbox()
        {
            InitializeComponent();
        }

        private String TextVal;
        private String ht;
        bool focus = false, usePw = false;

        [Description("Set the Multiline feature of Textbox")]
        public bool MultiLine
        {
            get
            {
                return textBox1.Multiline;
            }
            set
            {
                textBox1.Multiline = value;
            }
        }

        public String val
        {
            get { return this.textBox1.Text; }
            set { this.TextVal = value; textBox1.Text = value; textBox1.ForeColor = Color.Silver; }
        }

        public bool usePWchar
        {
            get { return usePw; }
            set 
            {
                usePw = value; 
                textBox1.UseSystemPasswordChar = value;
                if (value) textBox1.PasswordChar ='*';
            }
        }

        public String hint
        {
            get { return this.textBox1.Text; }
            set { this.ht = value; textBox1.Text = value; }
        }

        private void CustomTextbox_Paint(object sender, PaintEventArgs e)
        {
            if (focus)
            {
                Pen p = new Pen(Color.FromArgb(30, 32, 33));
                Graphics g = e.Graphics;
                int variance = 1;
                g.DrawRectangle(p, new Rectangle(textBox1.Location.X - variance, textBox1.Location.Y - variance, textBox1.Width + variance, textBox1.Height + variance));
            }
            else
            {
                Pen p = new Pen(Color.FromArgb(30, 32, 33));
                Graphics g = e.Graphics;
                int variance = 1;
                g.DrawRectangle(p, new Rectangle(textBox1.Location.X - variance, textBox1.Location.Y - variance, textBox1.Width + variance, textBox1.Height + variance));
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == ht) { textBox1.Text = null; textBox1.ForeColor = Color.Silver; }
                focus = true;
            this.Refresh();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            focus = false;
            this.Refresh();
        }

        private void CustomTextbox_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.MinimumSize = new Size(Width-10, 23);
            textBox1.Size = new Size(Width-10, 23);
            textBox1.Multiline = false;

            if (ht != "") 
                textBox1.ForeColor = Color.Gray;
                
            else 
                textBox1.ForeColor = Color.Gray;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
