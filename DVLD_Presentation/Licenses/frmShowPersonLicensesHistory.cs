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

namespace DVLD_Presentation.Licenses
{
    public partial class frmShowPersonLicensesHistory : Form
    {
        int _PersonID = -1;
        clsPerson _Person;

        public frmShowPersonLicensesHistory()
        {
            InitializeComponent();
        }

        public frmShowPersonLicensesHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            ctrlPersonCardWithFilter1.EnableFilter = false;
        }

        private void _LoadData()
        {
            if(_PersonID != -1)
            {
                //ctrlPersonCardWithFilter1.EnableFilter = false;
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlDriverLicenses1.LoadInfoWithPersonID(_PersonID);
            }
            //else
            //{
            //    ctrlPersonCardWithFilter1.EnableFilter = true;
            //    //ctrlDriverLicenses1.Clear();
            //}
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID != -1)
                _LoadData();
        }

        private void frmShowPersonLicensesHistory_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
