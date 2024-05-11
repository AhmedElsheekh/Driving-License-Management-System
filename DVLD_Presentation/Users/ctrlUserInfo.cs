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
    public partial class ctrlUserInfo : UserControl
    {
        int _UserID = -1;
        clsUser _User;

        public int UserID
        {
            get { return _UserID; }
        }

        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            
            lblUserID.Text = "???";
            lblUsername.Text = "???";
            lblIsActive.Text = "???";
        }

        private void _FillUserInfo()
        {
            ctrlPersonInfo1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username;

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.GetUserInfoByUserID(UserID);
            
            if(_User == null)
            {
                MessageBox.Show($"No user with ID = {UserID}", "Invalid UserID");
                _ResetDefaultValues();
                return;
            }

            _UserID = UserID;
            _FillUserInfo();
        }
        
    }
}
