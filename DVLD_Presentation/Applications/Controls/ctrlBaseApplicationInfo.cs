using DVLD_Business;
using DVLD_Presentation.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Controls
{
    public partial class ctrlBaseApplicationInfo : UserControl
    {
        int _ApplicationID;
        clsApplication _Application;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        public ctrlBaseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _FillApplicationInfo()
        {
            lblApplicationID.Text = _ApplicationID.ToString();
            lblApplicantPerson.Text = _Application.ApplicantPerson.FullName;
            lblAppDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblApplicationType.Text = _Application.ApplicationType.ApplicationTypeTitle;
            lblAppStatus.Text = _Application.ApplicationStatus.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lblPaidFees.Text = _Application.PaidFees.ToString();
            lblCreatedByUser.Text = _Application.CreatedByUser.Username;
            lklPersonInfo.Enabled = true;
        }

        public void ResetDefaultValues()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblApplicantPerson.Text = "[????]";
            lblAppDate.Text = "[????]";
            lblApplicationType.Text = "[????]";
            lblAppStatus.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblPaidFees.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lklPersonInfo.Enabled = false;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.GetBaseApplicationByID(ApplicationID);

            if(_Application == null)
            {
                MessageBox.Show("No Application exists with this ID", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ResetDefaultValues();
                return;
            }

            _ApplicationID = ApplicationID;
            _FillApplicationInfo();
        }

        private void lklPersonInfo_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();
            LoadApplicationInfo(_ApplicationID);
        }
    }
}
