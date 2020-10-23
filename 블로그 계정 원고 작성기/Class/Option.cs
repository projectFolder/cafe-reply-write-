using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;
using aiswing_product;

namespace WindowsFormsApp2.Class
{

    public class txtFile
    {

        public txtFile()
        {

        }

        public String readFile()
        {

            String lines = null;
            String filePath = "";

            OpenFileDialog Of = new OpenFileDialog();
            Of.Title = "불러올 파일을 선택해주세요.";
            Of.Filter = "텍스트파일|*.txt";
            if (Of.ShowDialog() == DialogResult.OK)
            {
                filePath = Of.FileName;
            }

            if (filePath.Length > 0)
            {
                var FileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using (var StreamReader = new StreamReader(FileStream, Encoding.UTF8))
                {
                    lines = StreamReader.ReadToEnd();
                }
            }
            return lines;
        }

        public void saveFile(String value)
        {

            String filePath = null;

            SaveFileDialog Sd = new SaveFileDialog();
            Sd.Title = "저장할 파일을 선택해주세요.";
            Sd.Filter = "텍스트파일|*.txt";
            if (Sd.ShowDialog() == DialogResult.OK)
            {
                filePath = Sd.FileName;
            }

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(value);
            }
        }

    }

    public class Tethering
    {
        String AirModeOn, AirModeOff;
        private MainForm frm;

        public Tethering(MainForm frm)
        {
            this.frm = frm;
        }

        public void TetheringMethod(bool versionUp, Label label)
        {

            label.Text = "테더링작업이 진행됩니다.";

            if (versionUp)
            {
                // 7.0 이하
                AirModeOn = Application.StartupPath + "\\adb.exe /c adb shell settings put global airplane_mode_on 1;sleep 2; am broadcast -a android.intent.action.AIRPLANE_MODE --ez state true";
                AirModeOff = Application.StartupPath + "\\adb.exe /c adb shell settings put global airplane_mode_on 0;sleep 2; am broadcast -a android.intent.action.AIRPLANE_MODE --ez state false";
            }
            else
            {
                // 7.0 이상
                AirModeOn = Application.StartupPath + "\\adb.exe /c adb shell input keyevent KEYCODE_WAKEUP;input keyevent KEYCODE_MOVE_HOME;sleep 2;am start -a android.settings.AIRPLANE_MODE_SETTINGS;sleep 2;input keyevent 61;input keyevent 66;pm clear com.android.settings;sleep 2;input keyevent KEYCODE_HOME";
                AirModeOff = Application.StartupPath + "\\adb.exe /c adb shell input keyevent KEYCODE_WAKEUP;input keyevent KEYCODE_MOVE_HOME;sleep 2;am start -a android.settings.AIRPLANE_MODE_SETTINGS;sleep 2;input keyevent 61;input keyevent 66;pm clear com.android.settings;sleep 2;input keyevent KEYCODE_HOME";
            }

            ProcessStartInfo startinfo = new ProcessStartInfo("cmd.exe", AirModeOn);
            Process p = new Process();
            startinfo.WindowStyle = ProcessWindowStyle.Hidden;
            startinfo.CreateNoWindow = true;
            p.StartInfo = startinfo;
            p.Start();
            p.WaitForExit();
            p.Close();
            label.Text = "비행기모드를 on하였습니다.";
            DelayOp.Delay(DelayOp.GetRandomNumber(3, 5) * 1000);

            ProcessStartInfo startinfo2 = new ProcessStartInfo("cmd.exe", AirModeOff);
            Process p2 = new Process();
            startinfo.WindowStyle = ProcessWindowStyle.Hidden;
            startinfo.CreateNoWindow = true;
            p2.StartInfo = startinfo;
            p2.Start();
            p2.WaitForExit();
            p2.Close();
            label.Text = "비행기모드를 off하였습니다. 인터넷연결시 작업을 시작합니다.";
            DelayOp.Delay(DelayOp.GetRandomNumber(5, 7) * 1000);

        }

    }

    public class DelayOp
    {

        public static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {

            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public static DateTime Delay(int MS)
        {

            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

    }

    public class FontLibrary
    {
        private static FontLibrary inst = new FontLibrary();
        public PrivateFontCollection privateFont = new PrivateFontCollection();
        public static FontFamily[] Families
        {
            get
            {
                return inst.privateFont.Families;
            }
        }

        public FontLibrary()
        {
            AddFontFromMemory();
        }

        private void AddFontFromMemory()
        {
            List<byte[]> fonts = new List<byte[]>();
            fonts.Add(aiswing_product.Properties.Resources.NanumGothic);

            foreach (byte[] font in fonts)
            {
                IntPtr fontBuffer = Marshal.AllocCoTaskMem(font.Length);
                Marshal.Copy(font, 0, fontBuffer, font.Length);
                privateFont.AddMemoryFont(fontBuffer, font.Length);
            }
        }

    }

    public class ComparerN : IComparer<string>
    {
        public int Compare(string sf, string ss)
        {
            if (IsNumer(sf) && IsNumer(ss))
            {
                if (Convert.ToInt32(sf) > Convert.ToInt32(ss))
                {
                    return 1;
                }
                if (Convert.ToInt32(sf) < Convert.ToInt32(ss))
                {
                    return -1;
                }
                if (Convert.ToInt32(sf) == Convert.ToInt32(ss))
                {
                    return 0;
                }
            }

            if (IsNumer(sf) && !IsNumer(ss))
                return -1;

            if (!IsNumer(sf) && IsNumer(ss))
                return 1;

            return string.Compare(sf, ss, true);
        }

        public static bool IsNumer(object v)
        {

            try
            {
                int it = Convert.ToInt32(v.ToString());
                return true;
            }
            catch (FormatException) { return false; }
        }
    }

    public static class _random
    {

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

    }

}
