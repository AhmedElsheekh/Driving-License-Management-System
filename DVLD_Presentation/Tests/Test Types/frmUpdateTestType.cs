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

namespace DVLD_Presentation.Tests.Test_Types
{
    public partial class frmUpdateTestType : Form
    {
        clsTestType.enTestType _TestTypeID;
        clsTestType _TestType;

        public frmUpdateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void _LoadData()
        {
            _TestType = clsTestType.GetTypeTypeByID(_TestTypeID);

            if(_TestType == null)
            {
                MessageBox.Show("Invalid Test Type ID");
                return;
            }

            lblTestTypeID.Text = _TestTypeID.ToString();
            txtTestTypeTitle.Text = _TestType.Title;
            txtDescription.Text = _TestType.Description;
            txtTestTypeFees.Text = _TestType.Fees.ToString();

        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtTestTypeTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeTitle, "This field can not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTestTypeTitle, "");
            }
        }

        private void txtTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "This field can not be blank");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTestTypeFees, "");
            }

            if (!clsValidation.ValidateNumber(txtTestTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Invalid number");
                
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTestTypeFees, "");
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "This field can not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDescription, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are invalid or empty");
                return;
            }

            _TestType.Title = txtTestTypeTitle.Text;
            _TestType.Description = txtDescription.Text;
            _TestType.Fees = Convert.ToDecimal(txtTestTypeFees.Text.Trim());

            if(_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully");
                lblTestTypeID.Text = _TestType.ID.ToString();
            }
            else
            {
                MessageBox.Show("Failed to save");
            }
        }
    }
}
