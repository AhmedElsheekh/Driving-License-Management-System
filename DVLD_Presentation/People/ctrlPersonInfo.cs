using DVLD_Business;
using DVLD_Presentation.Properties;
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
    public partial class ctrlPersonInfo : UserControl
    {
        int _PersonID = -1;
        clsPerson _Person;

        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson Person
        {
            get { return _Person; }
        }

        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.GetPersonByID(PersonID);

            if(Person == null)
            {
                MessageBox.Show("Person is not found, wrong person Id");
                _ResetDefaultValues();
                return;
            }

            _FillPersonInfo();

        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.GetPersonByNationalNo(NationalNo);

            if(_Person == null)
            {
                MessageBox.Show("Person is not found, wrong person Id");
                _ResetDefaultValues();
                return;
            }

            _PersonID = _Person.PersonID;
            _FillPersonInfo();
        }

        private void _ResetDefaultValues()
        {
            lblPersonID.Text = "???";
            lblFullName.Text = "???";
            lblNationalNo.Text = "???";
            lblCountry.Text = "???";
            lblBirthDate.Text = "???";
            lblGender.Text = "???";
            lblAddress.Text = "???";
            lblEmail.Text = "???";
            pbPersonImage.Image = Resources.Male_512;

            lklUpdatePerson.Enabled = false;
        }

        private void _FillPersonInfo()
        {
            lblPersonID.Text = _PersonID.ToString();
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalityCountryID.ToString();
            lblCountry.Text = _Person.Country.CountryName;
            lblBirthDate.Text = _Person.DateOfBirth.ToShortDateString();
            lblGender.Text = -Person.Gender == 0 ? "Male" : "Female";
            lblAddress.Text = _Person.Address;
            lblEmail.Text = _Person.Email.ToString();
            lblPhone.Text = _Person.Phone;

            if (_Person.ImagePath == "")
            {
                if (_Person.Gender == 0)
                    pbPersonImage.Image = Resources.Male_512;
                else
                    pbPersonImage.Image = Resources.Female_512;
            }
            else
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            lklUpdatePerson.Enabled = true;
        }

        private void lklUpdatePerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }

        private void ctrlPersonInfo_Load(object sender, EventArgs e)
        {
            if (_PersonID == -1)
                lklUpdatePerson.Enabled = false;
        }
    }
}
