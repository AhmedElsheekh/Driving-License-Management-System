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
    public partial class frmUserInfo : Form
    {
        int _UserID;
        clsUser _User;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            ctrlUserInfo1.LoadUserInfo(UserID);
        }
    }
}
