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
using System.Security.Cryptography;
using DVLD_Presentation.Global_Classes;

namespace DVLD_Presentation.Users
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        int _UserID;
        clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefaultValues()
        {
            _User = new clsUser();

            lblUserID.Text = "???";
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            chkIsActive.Checked = false;
        }

        private void _LoadUserData()
        {
            _User = clsUser.GetUserInfoByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show($"User with ID = {_UserID} is not found", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _UserID.ToString();
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = txtPassword.Text;
            chkIsActive.Checked = _User.IsActive;
        }

        private void _LoadData()
        {
            if(_Mode == enMode.AddNew)
            {

                _ResetDefaultValues();

                this.Text = "Add New User";
                lblTitle.Text = "Add New User";

                tpLoginInfo.Enabled = false;
                btnSave.Enabled = false;

            }
            else
            {
                _LoadUserData();
                ctrlPersonCardWithFilter1.EnableFilter = false;

                this.Text = "Update User";
                lblTitle.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;

            }

        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Username can't be empty");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }

            if(_Mode == enMode.AddNew)
            {
                if(clsUser.IsUserExistsByUsername(txtUsername.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUsername, "Username is already exists, choose another one");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUsername, "");
                }
            }
            else
            {
                if(_User.Username != txtUsername.Text.Trim())
                {
                    if (clsUser.IsUserExistsByUsername(txtUsername.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUsername, "Username is already exists, choose another one");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtUsername, "");
                    }
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUsername, "");
                }
  
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password can't be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPassword.Text.Trim() != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password confirmation doesn't match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are invalid or empty, check the red signals to correct");
                return;
            }

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.Username = txtUsername.Text;
            _User.Password = clsUtil.ComputeHashForPassword(txtPassword.Text);
            _User.IsActive = chkIsActive.Checked;

            if(_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();

                _Mode = enMode.Update;
                this.Text = "Update User";
                lblTitle.Text = "Update User";

                MessageBox.Show("Data saved successfully", "Successful Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save data", "Failed Process", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
                tcUser.SelectedIndex = 1;

                return;
            }

            if(_Mode == enMode.AddNew)
            {
                if(ctrlPersonCardWithFilter1.PersonID != -1)
                {
                    if(clsUser.DoesUserExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                    {
                        MessageBox.Show("This person is already a user, choose another person", "Invalid Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        tpLoginInfo.Enabled = true;
                        btnSave.Enabled = true;
                        tcUser.SelectedIndex = 1;
                    }
                }
                else
                {
                    MessageBox.Show("You Must choose a person to continue", "No Person Choosed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
