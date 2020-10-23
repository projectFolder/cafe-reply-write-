using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    [DefaultEvent("Click")]
    
    public partial class CustomButton : UserControl
    {

        int wh = 20; float ang = 45;
        Color cl0 = Color.Blue, cl1 = Color.Orange;
        String txt = "Button";

        public CustomButton()
        {
            DoubleBuffered = true;
            ForeColor = Color.Black;
        }

        public String btnName
        {
            get { return txt; }
            set { txt = value; Invalidate(); }
        }

       public float Angel
        {
            get { return ang; }
            set { ang = value; Invalidate(); }
        }

        public int BorderRadius
        {
            get { return wh; }
            set { wh = value; Invalidate(); }
        }

        public Color Color0
        {
            get { return cl0; }
            set { cl0 = value; Invalidate(); }
        }

        public Color Color1
        {
            get { return cl1; }
            set { cl1 = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(new Rectangle(0, 0, wh, wh), 180, 90);
            gp.AddArc(new Rectangle(Width - wh, 0, wh, wh), -90, 90);
            gp.AddArc(new Rectangle(Width - wh, Height - wh, wh, wh), 0, 90);
            gp.AddArc(new Rectangle(0, Height-wh, wh, wh), 90, 90);
          
            e.Graphics.FillPath(new LinearGradientBrush(ClientRectangle, cl0, cl1, ang), gp);
            e.Graphics.DrawString(txt, Font, new SolidBrush(ForeColor), ClientRectangle, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
            base.OnPaint(e);
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            this.Color0 = Color.FromArgb(40, 47, 65);
            this.Color1 = Color.FromArgb(40, 47, 65);
        }

        private void CustomButton_Load(object sender, EventArgs e)
        {

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Color0 = Color.FromArgb(58, 65, 83);
            this.Color1 = Color.FromArgb(58, 65, 83);
        }

    }
}
