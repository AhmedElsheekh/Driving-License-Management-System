using DVLD_Business;
using DVLD_Presentation.Global_Classes;
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
    public partial class frmUpdateApplicationType : Form
    {
        int _ApplicationTypeID;
        clsApplicationType _ApplicationType;
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        private void _LoadData()
        {
            _ApplicationType = clsApplicationType.GetApplicationTypeByID(_ApplicationTypeID);

            if(_ApplicationType == null)
            {
                MessageBox.Show("Invalid Application Type ID");
                return;
            }

            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtApplicationTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtApplicationFees.Text = _ApplicationType.ApplicationFees.ToString();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtApplicationTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtApplicationTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTitle, "This field can't be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtApplicationTitle, "");
            }
        }

        private void txtApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApplicationFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "This field can't be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtApplicationFees, "");
            }

            if(!clsValidation.ValidateNumber(txtApplicationFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "Invalid Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtApplicationFees, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are invalid");
                return;
            }

            _ApplicationType.ApplicationTypeTitle = txtApplicationTitle.Text;
            _ApplicationType.ApplicationFees = Convert.ToDecimal(txtApplicationFees.Text.Trim());

            if(_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully");

                lblApplicationTypeID.Text = _ApplicationType.ApplicationTypeID.ToString();
            }
            else
            {
                MessageBox.Show("Failed to save");
            }

        }
    }
}
