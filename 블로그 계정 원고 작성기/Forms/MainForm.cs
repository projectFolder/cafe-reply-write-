using aiswing_product.Class;
using aiswing_product.Forms;
using ExtendedControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp2.Class;

namespace aiswing_product
{
    public partial class MainForm : Form
    {

        #region [ Gloval Variable ]

        private bool On, demo = false;
        private Point Pos;
        String mThreadState = null; Thread mThread;


        #endregion

        #region [ Form Method ]

        #region [ Form License & Load ]

        private void MainForm_Load(object sender, EventArgs e)
        {
            fileCheck fc = new fileCheck();
            String pas = fileCheck.AESEncrypt256(Convert.ToString(fc.getHddNum()));
            // String pas = "rcNpxTiWYMj5Xymx7EtzgR3nMJgX6PSxTJmXRFgfiDg=";
            // MessageBox.Show(fileCheck.AESDecrypt256(pas));

            switch (fc.License(this))
            {
                case fileCheck.checkState.Formally:
                    demo = true;
                    break;
                case fileCheck.checkState.ban:
                    fc.showMsg(pas);
                    Environment.Exit(Environment.ExitCode);
                    break;
                case fileCheck.checkState.Demo:
                    fc.showMsg(pas);
                    break;
            }

            CheckForIllegalCrossThreadCalls = false;

        }

        #endregion

        #region [ Form Move ]
        public MainForm()
        {

            InitializeComponent();
            this.Font = new Font(FontLibrary.Families[0], 9);
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        #endregion

        #region [ Form Minimize / Exit ] 
        private void button13_Click(object sender, EventArgs e)
        {
            exitChrome();
            Environment.Exit(Environment.ExitCode);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #endregion

        #region [ Kill Chrome Process ] 

        public static void exitChrome()
        {

            Process[] Chrome = Process.GetProcessesByName("chromedriver");

            foreach (var ch in Chrome)
            {
                ch.Kill();
            }

        }

        #endregion

        #region [ ListView Method ]

        #region [ Items Shuffle & Remove ]

        private List<String> delete_Items(List<String> lst)
        {

            for (int j = lst.Count - 1; j >= 0; j--)
            {
                if (lst.Count <= 50) break; else lst.RemoveAt(j);
            }

            return lst;

        }

        private List<String> Shuffle(List<String> lst)
        {
            Random rng = new Random();
            int n = lst.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                String value = lst[k];
                lst[k] = lst[n];
                lst[n] = value;
            }

            return lst;

        }

        private List<int> Shuffle(List<int> lst)
        {
            Random rng = new Random();
            int n = lst.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = lst[k];
                lst[k] = lst[n];
                lst[n] = value;
            }

            return lst;

        }

        #endregion

        #region [ delete Focused ListViewItems ] 

        public static void delete_Focused_Items(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                string objName = ((CustomListView)sender).Name.ToString();
                ListView Lst = ((CustomListView)sender);

                foreach (ListViewItem item in Lst.Items)
                {
                    if (item.Selected) item.Remove();
                }

            }

        }

        #endregion

        #endregion

        #region display log

        public void display(String str)
        {
            customListView3.BeginUpdate();

            ListViewItem item = new ListViewItem("");

            item.SubItems.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            item.SubItems.Add(str);

            customListView3.Items.Add(item);

            customListView3.EndUpdate();

            customListView3.Items[customListView3.Items.Count-1].Focused = true;
            label4.Text = str;
        }

        #endregion

        #region remove dupulicated item

        public List<String> removeList(List<String> _lst, List<String> _lst2)
        {
            foreach(String item1 in _lst)
            {
                foreach(String item2 in _lst2)
                {
                    if (item1.Contains(item2)) _lst.Remove(item2);
                }
            }

            return _lst;

        }

        #endregion

        #region [ workState ] 

        private bool checkState()
        {

            

            return true;
        }

        #endregion

        #region [ Run ] 

        private void Run()
        {

            List<String> _lst = new List<String>();

            foreach (ListViewItem _Account in customListView2.Items)
            {
                Tethering tethering = new Tethering(this);
                tethering.TetheringMethod(firefoxCheckBox2.Checked, label4);

                naverSelenium naver = new naverSelenium(this, _Account.SubItems[2].Text, _lst);

                if (naver.openChrome(_Account.Index, _Account.SubItems[2].Text, _Account.SubItems[3].Text))
                {
                    naver.cafeWrite(0, int.Parse(_Account.SubItems[4].Text));
                }

                naver.driver.Quit();
            }

            mThreadState = null;
            button2.Enabled = true;
            button1.Enabled = false;

            MessageBox.Show("모든 계정의 작업이 완료되었습니다.");

        }

        #endregion

        #region [ start / pause ]

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkState())
            {

                button2.Enabled = false;
                button1.Enabled = true;

                if (mThreadState == null)
                {
                    mThread = new Thread(Run);
                    mThread.SetApartmentState(ApartmentState.STA);
                    mThread.Start();
                    mThreadState = "Start";
                }
                else
                {
                    mThread.Resume();
                    mThreadState = "Resume";
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //작업중지
            if (mThread != null)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                mThread.Suspend();
                mThreadState = "pause";
            }
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "저장할 텍스트파일을 선택해주세요";
            sfd.Filter = "텍스트파일|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (ListViewItem item in customListView2.Items)
                    {
                        sw.WriteLine(item.SubItems[2].Text + "|" + item.SubItems[3].Text + "|" + item.SubItems[4].Text);
                    }
                }

                MessageBox.Show("성공적으로 저장되었습니다.");

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WriteForm wf = new WriteForm(this);
            wf.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "불러올 텍스트파일을 선택해주세요";
            ofd.Filter = "텍스트파일|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                ListView customListview = this.customListView1;

                customListview.BeginUpdate();

                foreach (String _word in File.ReadAllText(ofd.FileName).Split(new String[] { "----" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    String _title = Regex.Split(Regex.Split(_word, "제목 :")[1], "\n")[0].Trim();
                    String _subject = Regex.Split(_word, _title)[1].Trim();

                    ListViewItem item = new ListViewItem("");

                    item.SubItems.Add(Convert.ToString(customListview.Items.Count + 1));
                    item.SubItems.Add(_title);
                    item.SubItems.Add(_subject);

                    customListview.Items.Add(item);

                    if (customListview.Items.Count >= 7) customListview.Columns[3].Width = 108;

                    if (customListview.Items.Count % 2 == 0)
                        customListview.Items[item.Index].BackColor = Color.FromArgb(30, 30, 30);
                    else
                        customListview.Items[item.Index].BackColor = Color.FromArgb(28, 29, 31);
                }

                customListview.EndUpdate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "저장하실 텍스트파일을 선택 및 생성해주세요.";
            sfd.Filter = "텍스트파일|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.Default))
                {
                    foreach (ListViewItem item in customListView1.Items)
                    {
                        sw.WriteLine("제목 :" + item.SubItems[2].Text);
                        sw.WriteLine(item.SubItems[3].Text);
                        sw.WriteLine("----");
                    }
                }

                MessageBox.Show("성공적으로 저장되었습니다.");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((customTextbox1.val.Contains("http") && customTextbox1.val.Length > 0))
            {
                HttpWebRequetClass http = new HttpWebRequetClass(this);
                var _content = http.get_info(customTextbox1.val);

                label22.Text = _content.Item2;
                label23.Text = customTextbox1.val.Split('/')[customTextbox1.val.Split('/').Length - 1];
            }
            else
            {
                MessageBox.Show("잘못된 url입니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "불러올 텍스트파일을 선택해주세요";
            ofd.Filter = "텍스트파일|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                foreach (String line in File.ReadAllLines(ofd.FileName))
                {

                    customListView2.BeginUpdate();
                    ListViewItem item = new ListViewItem("");
                    if (line.Trim().Length > 1 && line != "")
                    {
                        item.SubItems.Add(Convert.ToString(customListView2.Items.Count + 1));
                        item.SubItems.Add(line.Split('|')[0]);
                        item.SubItems.Add(line.Split('|')[1]);
                    }

                    if (line.LastIndexOf("|") >= 3) item.SubItems.Add(line.Split('|')[2]);

                    customListView2.Items.Add(item);

                    if (customListView2.Items.Count >= 14) customListView2.Columns[4].Width = 48;

                    if (customListView2.Items.Count % 2 == 0)
                        customListView2.Items[item.Index].BackColor = Color.FromArgb(30, 30, 30);
                    else
                        customListView2.Items[item.Index].BackColor = Color.FromArgb(28, 29, 31);

                    customListView2.EndUpdate();

                }


            }
        }

    }
}
