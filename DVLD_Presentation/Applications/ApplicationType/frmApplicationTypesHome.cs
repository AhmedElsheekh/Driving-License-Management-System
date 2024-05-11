using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.ApplicationType
{
    public partial class frmApplicationTypesHome : Form
    {
        DataTable _AllApplicationTypes;
        public frmApplicationTypesHome()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _AllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvAllApplicationTypes.DataSource = _AllApplicationTypes;

            if(dgvAllApplicationTypes.Rows.Count > 0)
            {
                dgvAllApplicationTypes.Columns[0].HeaderText = "Application Type ID";

                dgvAllApplicationTypes.Columns[1].HeaderText = "Application Type Title";
                dgvAllApplicationTypes.Columns[1].Width = 250;

                dgvAllApplicationTypes.Columns[2].HeaderText = "Application Fees";

            }

            lblNumberOfRecords.Text = dgvAllApplicationTypes.Rows.Count.ToString();
        }

        private void frmApplicationTypesHome_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dgvAllApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
    }
}
