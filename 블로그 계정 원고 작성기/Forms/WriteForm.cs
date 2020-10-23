using aiswing_product.Class;
using ExtendedControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Class;

namespace aiswing_product.Forms
{
    public partial class WriteForm : Form
    {
       
        private bool On;
        private Point Pos;
        private MainForm main;

        #region [ Rounded Form Corenr ]

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
        );

        #endregion

        #region [ Constructor ]
        public WriteForm(MainForm main)
        {
            InitializeComponent();

            this.main = main;

            this.Font = new Font(FontLibrary.Families[0], 9);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        #endregion

        public void addWrite(CustomListView writeList, String path)
        {

            writeList.Items.Clear();

            try
            {
                foreach (String _word in File.ReadAllText(path,
                System.Text.Encoding.Default).Split(new String[] { "----" }, StringSplitOptions.None))
                {
                    if (_word.Contains("제목 :"))
                    {
                        String _title = Regex.Split(Regex.Split(_word, "제목 :")[1], "\n")[0].Trim();
                        String _subject = Regex.Split(_word, _title)[1].Trim();

                        writeList.BeginUpdate();

                        ListViewItem item = new ListViewItem("");
                        item.SubItems.Add(Convert.ToString(writeList.Items.Count + 1));
                        item.SubItems.Add(_title);
                        item.SubItems.Add(_subject);
                        writeList.Items.Add(item);

                        if (writeList.Items.Count >= 8) writeList.Columns[1].Width = writeList.Columns[1].Width - 17;

                        if (writeList.Items.Count % 2 == 0)
                        {
                            writeList.Items[item.Index].BackColor = Color.FromArgb(26, 26, 23);
                        }
                        else
                        {
                            writeList.Items[item.Index].BackColor = Color.FromArgb(30, 32, 33);
                        }

                        writeList.EndUpdate();
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("잘못된 형식의 텍스트파일을 불러왔습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void idList_KeyDown(object sender, KeyEventArgs e)
        {
            MainForm.delete_Focused_Items(sender, e);
        }
     
        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {

            ListView customListview = main.customListView1;

            customListview.BeginUpdate();

            ListViewItem item = new ListViewItem("");

            item.SubItems.Add(Convert.ToString(customListview.Items.Count + 1));
            item.SubItems.Add(titleText.val);
            item.SubItems.Add(subjectText.setValue);

            customListview.Items.Add(item);

            if (customListview.Items.Count >= 7) customListview.Columns[3].Width = 108;

            if (customListview.Items.Count % 2 == 0)
                customListview.Items[item.Index].BackColor = Color.FromArgb(30, 30, 30);
            else
                customListview.Items[item.Index].BackColor = Color.FromArgb(28, 29, 31);

            customListview.EndUpdate();

        }
    }
}
