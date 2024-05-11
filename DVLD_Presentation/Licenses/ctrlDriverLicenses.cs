using DVLD_Business;
using DVLD_Presentation.Applications.International_Licenses;
using DVLD_Presentation.Licenses.Local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses
{
    public partial class ctrlDriverLicenses : UserControl
    {
        DataTable _LocalLicenses;
        DataTable _InternationalLicenses;
        int _DriverID;
        clsDriver _Driver;
        int _PersonID;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public int DriverID
        {
            get { return _DriverID; }
        }

        public clsDriver Driver
        {
            get { return _Driver; }
        }

        private void _LoadLocalLicenses()
        {
            _LocalLicenses = _Driver.GetAllDriverLicenses();
            dgvLocalLicenses.DataSource = _LocalLicenses;

            lblNumOfLocalRecords.Text = dgvLocalLicenses.RowCount.ToString();

            if(dgvLocalLicenses.RowCount > 0)
            {
                dgvLocalLicenses.Columns[0].HeaderText = "License ID";

                dgvLocalLicenses.Columns[1].HeaderText = "App ID";

                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenses.Columns[2].Width = 220;

                dgvLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[3].Width = 220;

                dgvLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[4].Width = 220;

                dgvLocalLicenses.Columns[5].HeaderText = "Is Active";
              
            }
        }

        private void _LoadInternationalLicenses()
        {
            _InternationalLicenses = clsInternationalLicense.GetDriverInternationlLicenses(_DriverID);
            dgvInternationalLicenses.DataSource = _InternationalLicenses;
            lblNumOfInternationlRec.Text = dgvInternationalLicenses.RowCount.ToString();

            if (dgvInternationalLicenses.RowCount > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int. License ID";
                dgvInternationalLicenses.Columns[0].Width = 100;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 100;


                dgvInternationalLicenses.Columns[2].HeaderText = "Local License ID";
                dgvInternationalLicenses.Columns[2].Width = 100;

                dgvInternationalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[3].Width = 200;

                dgvInternationalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[4].Width = 200;

                dgvInternationalLicenses.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[5].Width = 100;
            }
        }

        public void LoadInfo(int DriverID)
        {
            
            _Driver = clsDriver.GetDriverByID(DriverID);

            if(_Driver == null)
            {
                MessageBox.Show("No Driver With That ID");
                return;
            }

            _DriverID = DriverID;

            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        public void LoadInfoWithPersonID(int PersonID)
        {
            
            _Driver = clsDriver.GetDriverByPersonID(PersonID);

            if(_Driver == null)
            {
                MessageBox.Show("No Driver With That ID");
                return;
            }

            _DriverID = _Driver.DriverID;
            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        private void showDetailsLocalLicensesCMS_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showDetailsInternationalCMS_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        //public void Clear()
        //{
        //    if(_LocalLicenses.Rows.Count > 0)
        //    {
        //        _LocalLicenses.Clear();
        //    }
          
        //    if(_InternationalLicenses.Rows.Count > 0)
        //        _InternationalLicenses.Clear();
        //}
    }
}
