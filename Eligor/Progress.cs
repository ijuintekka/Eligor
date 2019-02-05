using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eligor
{
    public partial class Progress : Form
    {
        public bool ProgReady = false;

        public Progress()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Cancel.Enabled = false;
        }

        private void Progress_Shown(object sender, EventArgs e)
        {
            ProgReady = true;
        }
    }
}
