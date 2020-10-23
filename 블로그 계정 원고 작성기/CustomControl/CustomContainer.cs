using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace aiswing_product.CustomControl
{

    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]

    public partial class CustomContainer : UserControl
    {
        public CustomContainer()
        {
            InitializeComponent();
        }

        String containerLabel;

        public String labelName
        {
            get { return containerLabel; }

            set { this.containerLabel = value; label1.Text = containerLabel; }

        }

        private void CustomContainer_Load(object sender, EventArgs e)
        {
            panel1.SendToBack();

        }
    }
}
