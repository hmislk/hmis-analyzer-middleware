using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Middleware
{
    


    public partial class FormMain : Form
    {
        private FormDimensionSettings dimensionsForm;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnDimension_Click(object sender, EventArgs e)
        {
            dimensionsForm = new FormDimensionSettings();
            dimensionsForm.Show();
        }
    }
}
