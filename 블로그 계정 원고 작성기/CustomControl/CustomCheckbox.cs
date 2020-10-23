using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2.CustomControl
{

    static class Theme
    {

        public static Font GlobalFont(FontStyle B, int S)
        {
            return new Font("Microsoft JhengHei UI", S, B);
        }

        public static string GetCheckMark()
        {
            return "iVBORw0KGgoAAAANSUhEUgAAABcAAAAXCAYAAADgKtSgAAAABmJLR0QA/wD/AP+gvaeTAAAB6ElEQVRIDdVUzSsEYRh/nqFZyUeRq3JTalEubuRA4V/wWZwcsL5urtsuyUVt0aKUUi6So7OoQUoclOKAyEeyw87r92ztWDuzrF2X3Z7fzPM+H7/nN+/svES5+uNk4X3+02LSzYrk+K9rU79dmqh+Tqz7Rt4bNPyKeAwF3+JYp2OKiP1hn3cqXmyT9M+elEWtjzsk7Bj8v5oy37l8bcr7II2aXARRNktwz4YY7cR6QbRUHIFNLov/RrbkF6SxF6IOAIdlQ35FltUaHvEeM6uAgxmBfCATu7A+8ptWJmsue2eMDqV42Y3kJ+URtwbErkWxEHfNGM34664j5gEc5krOzJtRRZWo3gMSTRQ3hsfrz0WxpniHFBUmFiT6ruSWpXZXx2pvdHpvR/ERIHZtsWpLUqxLIhVcyZlpDsoGQ76GOwxogbptEDevjNadyVZoxFuIpVQcH5bqhTJe0kJ34NAT8tXOo1iegHoCh50g3cD6R8XIx8xVeSyDg0KeoCdoDMk6RsyUNrH0pFIuOQFjxlx30KgipkGoTkuxNAp+I5cajYmHQSz+n2BvS57Sn9CJYxPXzE2Zb3mP8XabfHGk5p4p9hlnOgB97I8ftzIAeyq3LwxM7xe+eHTXL+6ryukVRcxIaLrh1ZnJxcgnSGKTuHvl2WoAAAAASUVORK5CYII=";
        }

    }

    static class Helpers
    {

        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2
        }

        public static Color GreyColor(int G)
        {
            return Color.FromArgb(G, G, G);
        }

        public static void DrawRoundRect(Graphics G, Rectangle R, int Curve, Color C, bool chk)
        {
            using (Pen P = new Pen(C))
            {
                G.DrawArc(P, R.X, R.Y, Curve, Curve, 180, 90);
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), R.Y, Convert.ToInt32(R.X + R.Width - Curve / 2), R.Y);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.DrawLine(P, R.X, Convert.ToInt32(R.Y + Curve / 2), R.X, Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + Curve / 2), Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height), Convert.ToInt32(R.X + R.Width - Curve / 2), Convert.ToInt32(R.Y + R.Height));
                G.DrawArc(P, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
                if (chk)
                {
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(55, 55, 55));
                G.FillRectangle(solidBrush, R.X, R.Y, 20, 20);
                }
            }

        }

    }

    [DefaultEvent("CheckedChanged")]
    public partial class FirefoxCheckBox : Control
    {

        #region " Public "
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);
        #endregion

        #region " Private "
        private Helpers.MouseState State;
        private Color ETC = Color.Blue;

        private Graphics G;
        private bool _EnabledCalc;
        private bool _Checked;
        #endregion

        private bool _Bold;

        #region " Properties "

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public new bool Enabled
        {
            get { return EnabledCalc; }
            set
            {
                _EnabledCalc = value;
                Invalidate();
            }
        }

        [DisplayName("Enabled")]
        public bool EnabledCalc
        {
            get { return _EnabledCalc; }
            set
            {
                Enabled = value;
                Invalidate();
            }
        }

        public bool Bold
        {
            get { return _Bold; }
            set
            {
                _Bold = value;
                Invalidate();
            }
        }

        #endregion

        #region " Control "

        public FirefoxCheckBox()
        {
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(55, 55, 55);
            Font = Theme.GlobalFont(FontStyle.Regular, 9);
            Size = new Size(140, 23);
            Enabled = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Parent.BackColor);

            if (Enabled)
            {
                ETC = Color.FromArgb(128, 128, 128);

                switch (State)
                {

                    case Helpers.MouseState.Over:
                    case Helpers.MouseState.Down:
                        Helpers.DrawRoundRect(G, new Rectangle(3, 3, 17, 17), 1, Color.FromArgb(55, 55, 55), false);

                        break;
                    default:
                        Helpers.DrawRoundRect(G, new Rectangle(3, 3, 17, 17), 1, Color.FromArgb(55, 55, 55), false);

                        break;
                }


                if (Checked)
                {
                    using (Image I = Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Theme.GetCheckMark()))))
                    {
                        G.DrawImage(I, new Point(0, 1));
                    }

                }


            }
            else
            {
                ETC = Helpers.GreyColor(170);
                Helpers.DrawRoundRect(G, new Rectangle(3, 3, 17, 17), 1, Color.FromArgb(55, 55, 55), false);


                if (Checked)
                {
                    using (Image I = Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Theme.GetCheckMark()))))
                    {
                        G.DrawImage(I, new Point(0, 1));
                    }

                }

            }


            using (SolidBrush B = new SolidBrush(ETC))
            {

                if (Bold)
                {
                    G.DrawString(Text, Theme.GlobalFont(FontStyle.Bold, 9), B, new Point(25, 5));
                }
                else
                {
                    G.DrawString(Text, Theme.GlobalFont(FontStyle.Regular, 9), B, new Point(25, 5));
                }

            }


        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = Helpers.MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (Enabled)
            {
                Checked = !Checked;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this, e);
                }
            }

            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = Helpers.MouseState.None;
            Invalidate();
        }

        #endregion
    }
}