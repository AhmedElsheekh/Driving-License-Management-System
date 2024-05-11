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

namespace DVLD_Presentation
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ComputedHashPassword = clsUtil.ComputeHashForPassword(txtPassword.Text.Trim());

            clsUser CurrentUser = clsUser.GetUserInfoByUsernameAndPassword(txtUsername.Text.Trim(), ComputedHashPassword);
                

            if(CurrentUser != null)
            {
                //if(chkRemeberMe.Checked)
                //{
                //    clsLogedUser.RemeberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                //}
                //else
                //{
                //    clsLogedUser.RemeberUsernameAndPassword("", "");
                //}

                //if(!CurrentUser.IsActive)
                //{
                //    MessageBox.Show("Your account is Inactive, contact your admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (chkRemeberMe.Checked)
                {
                    clsLogedUser.SaveUsernameAndPasswordOnWindowsRegistery(txtUsername.Text.Trim(),
                        txtPassword.Text.Trim());
                }
                else
                {
                    clsLogedUser.DeleteStoredCredentialFromWinRegisteryIfExists();
                }

                if (!CurrentUser.IsActive)
                {
                    MessageBox.Show("Your account is Inactive, contact your admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsLogedUser.CurrentUser = CurrentUser;
                frmHome frm = new frmHome(this);
                this.Hide();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username and/or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            //if(clsLogedUser.GetStoredCredential(ref Username, ref Password))
            //{
            //    txtUsername.Text = Username;
            //    txtPassword.Text = Password;
            //}
            //else
            //{
            //    chkRemeberMe.Checked = false;
            //}

            if (clsLogedUser.GetStoredCredentialFromWindowsRegistery(ref Username, ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
            }
            else
            {
                chkRemeberMe.Checked = false;
            }
        }
    }
}
