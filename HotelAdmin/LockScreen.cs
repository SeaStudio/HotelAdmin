using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HotelAdmin
{
    public partial class LockScreen : Form
    {

        public LockScreen()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TrmCloseTaskmgr_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ee)
            {

            }
        }
    }
}
