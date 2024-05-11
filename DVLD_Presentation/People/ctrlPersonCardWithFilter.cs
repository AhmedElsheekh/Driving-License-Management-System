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

namespace DVLD_Presentation.People
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;

            if (handler != null)
            {
                handler(PersonID);
            }
        }

        public int PersonID
        {
            get { return ctrlPersonInfo1.PersonID; }
        }

        public clsPerson Person
        {
            get { return ctrlPersonInfo1.Person; }
        }

        bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }

            set
            {
                _ShowAddPerson = value;
                btnAddNew.Visible = _ShowAddPerson;
            }
        }

        bool _EnableFilter = true;

        public bool EnableFilter
        {
            get
            {
                return _EnableFilter;
            }

            set
            {
                _EnableFilter = value;
                gbFilter.Enabled = _EnableFilter;
            }
        }

        private void _FindPerson()
        {
            switch (cmbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonInfo1.LoadPersonInfo(int.Parse(txtFilterBy.Text));
                    break;

                case "National No":
                    ctrlPersonInfo1.LoadPersonInfo(txtFilterBy.Text.Trim());
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && _EnableFilter)
                OnPersonSelected(ctrlPersonInfo1.PersonID);
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Clear();
            txtFilterBy.Focus();
        }

        private void txtFilterBy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                e.Cancel = true;
                txtFilterBy.Focus();
                errorProvider1.SetError(txtFilterBy, "This field can't be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFilterBy, "");
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            if (cmbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are invalid, check the red signals to validate");
                return;
            }

            _FindPerson();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cmbFilterBy.SelectedIndex = 1;
            txtFilterBy.Text = PersonID.ToString();
            ctrlPersonInfo1.LoadPersonInfo(PersonID);
        }

        public void LoadPersonInfo(string NationalNo)
        {
            cmbFilterBy.SelectedIndex = 0;
            txtFilterBy.Text = NationalNo;
            ctrlPersonInfo1.LoadPersonInfo(NationalNo);
        }

        private void DataBackEvent(object sender, int PersonId)
        {
            cmbFilterBy.SelectedIndex = 1;
            txtFilterBy.Text = PersonId.ToString();
            ctrlPersonInfo1.LoadPersonInfo(PersonId);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cmbFilterBy.SelectedIndex = 0;
        }


    }


}