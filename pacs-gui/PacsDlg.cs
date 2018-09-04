using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacs_gui
{
    public partial class PacsDlg : Form
    {
        public PacsDlg()
        {
            InitializeComponent();
        }

        private void Startup_Click(object sender, EventArgs e)
        {
            var port = textPort.Text;
            var ae = textAE.Text;
            var path = textPath.Text; 
            pacs_store.StoreSCP storeSCP = new pacs_store.StoreSCP();
            pacs_store.StoreSCP.StoragePath = path;
            pacs_store.StoreSCP.port = port;
            pacs_store.StoreSCP.ae = ae;
            storeSCP.run();
        }
    }
}
