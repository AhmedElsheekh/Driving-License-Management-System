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

namespace DVLD_Presentation.Users
{
    public partial class frmChangePassword : Form
    {
        int _UserID;
        clsUser _User;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void _LoadData()
        {
            _User = clsUser.GetUserInfoByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show("No user exists with this ID", "Invalid UserID");
                _ResetDefaultValues();
                return;
            }

            ctrlUserInfo1.LoadUserInfo(_UserID);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(_User.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password is invalid");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password can't be blank");
          
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
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
                MessageBox.Show("Some fields are invalid or empty, check the red signals");
                return;
            }

            _User.Password = txtNewPassword.Text;

            if(_User.Save())
            {
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("Failed To Save");
            }
        }
    }
}
