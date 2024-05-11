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

namespace DVLD_Presentation.Tests.Test_Types
{
    public partial class frmTestTypesHome : Form
    {
        DataTable _AllTestTypes;

        public frmTestTypesHome()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _AllTestTypes = clsTestType.GetAllTestTypes();
            dgvAllTestTypes.DataSource = _AllTestTypes;

            if(dgvAllTestTypes.Rows.Count > 0)
            {
                dgvAllTestTypes.Columns[0].HeaderText = "Test Type ID";

                dgvAllTestTypes.Columns[1].HeaderText = "Test Type Title";
                dgvAllTestTypes.Columns[1].Width = 200;

                dgvAllTestTypes.Columns[2].HeaderText = "Test Type Description";
                dgvAllTestTypes.Columns[2].Width = 220;

                dgvAllTestTypes.Columns[3].HeaderText = "Test Type Fees";

            }

            lblNumOfRecords.Text = dgvAllTestTypes.Rows.Count.ToString();
        }

        private void frmTestTypesHome_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((clsTestType.enTestType)dgvAllTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
    }
}
