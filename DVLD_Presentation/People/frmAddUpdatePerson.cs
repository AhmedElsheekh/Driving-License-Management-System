using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation.People
{
    public partial class frmAddUpdatePerson : Form
    {
        enum enMode { AddNew = 0, Update = 1}
        enum enGender { Male = 0, Female = 1}

        enMode _Mode;
        int _PersonID = -1;
        clsPerson _Person;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
        }

        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        private void _FillCountriesInComboBox()
        {
            DataTable AllCountries = clsCountry.GetAllCountries();

            foreach(DataRow Row in AllCountries.Rows)
            {
                cmbCountry.Items.Add(Row["CountryName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();
            _Person = new clsPerson();

            lblPersonID.Text = "NA";
            txtFirstName.Text = txtSecondName.Text = txtThirdName.Text = txtLastName.Text = "";
            txtNationalNo.Clear();

            dtBirthDate.MaxDate = DateTime.Now.AddYears(-18);
            dtBirthDate.MinDate = dtBirthDate.MaxDate.AddYears(-100);
            dtBirthDate.Value = dtBirthDate.MaxDate;

            rbMale.Checked = true;
            pbPersonImage.Image = Resources.Male_512;

            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            cmbCountry.SelectedIndex = cmbCountry.FindString("Egypt");

            lklRemoveImage.Visible = pbPersonImage.ImageLocation != null;
        }

        private void _FillPersonData()
        {
            _FillCountriesInComboBox();
            _Person = clsPerson.GetPersonByID(_PersonID);

            if(_Person == null)
            {
                MessageBox.Show("Person isn't found, Invalid Person ID");
                return;
            }

            lblPersonID.Text = _PersonID.ToString();

            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtBirthDate.Value = _Person.DateOfBirth;

            if (_Person.Gender == (byte)enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Select();

            txtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            cmbCountry.SelectedIndex = cmbCountry.FindString(_Person.Country.CountryName);

            if (_Person.ImagePath != "")
                pbPersonImage.ImageLocation = _Person.ImagePath;
            else
                pbPersonImage.ImageLocation = null;

            lklRemoveImage.Visible = _Person.ImagePath != "";


        }

        private void _LoadData()
        {
            if(_Mode == enMode.AddNew)
            {
                this.Text = "Add New Person";
                lblTitle.Text = "Add New Person";
                _ResetDefaultValues();
            }
            else
            {
                this.Text = "Update Person";
                lblTitle.Text = "Update Person";
                _FillPersonData();
            }
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
        }

        private void lklSetImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmb;*.gif";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.ImageLocation = openFileDialog1.FileName;

                if (pbPersonImage.ImageLocation != null)
                    lklRemoveImage.Visible = true;
            }
        }

        private void lklRemoveImage_Click(object sender, EventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            lklRemoveImage.Visible = false;
        }



        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if(string.IsNullOrWhiteSpace(txt.Text))
            {
                e.Cancel = true;
                txt.Focus();
                errorProvider1.SetError(txt, "This Field Can't Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "This Field Can't Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "");
            }

            if(clsPerson.IsPersonExistsByNationalNo(txtNationalNo.Text) && txtNationalNo.Text != _Person.NationalNo)
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "This National No Is Already Exists");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "");
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!clsValidation.ValidateEmail(txtEmail.Text))
                {
                    e.Cancel = true;
                    txtEmail.Focus();
                    errorProvider1.SetError(txtEmail, "Invalid Email Format");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtEmail, "");
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private bool _HandlePersonImage()
        {
            if(pbPersonImage.ImageLocation == null)
            {
                _Person.ImagePath = "";
                return true;
            }

            if(pbPersonImage.ImageLocation != _Person.ImagePath)
            {
                if(_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch(Exception ex)
                    {

                    }
                }

                string SourceFile = pbPersonImage.ImageLocation.ToString();

                if(clsUtil.CopyImageFileToDestinationFolder(ref SourceFile))
                {
                    _Person.ImagePath = SourceFile;
                    return true;
                }
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are invalid or empty, check the red signals to validate");
                return;
            }

            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;

            if (string.IsNullOrWhiteSpace(txtThirdName.Text))
                _Person.ThirdName = "";
            else
                _Person.ThirdName = txtThirdName.Text;

            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.DateOfBirth = dtBirthDate.Value;

            if (rbMale.Checked)
                _Person.Gender = (int)enGender.Male;
            else
                _Person.Gender = (int)enGender.Female;

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                _Person.Address = "";
            else
                _Person.Address = txtAddress.Text;

            _Person.Phone = txtPhone.Text;

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                _Person.Email = "";
            else
                _Person.Email = txtEmail.Text;

            int NationalityCountryID = clsCountry.GetCountryInfoByName(cmbCountry.Text).CountryID;
            _Person.NationalityCountryID = NationalityCountryID;

            if (!_HandlePersonImage())
                return;

            if(_Person.Save())
            {
                MessageBox.Show("Data Saved Successfully");

                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                this.Text = "Update Person";
                lblTitle.Text = "Update Person";

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Failed To Save Data");
            }

        }
    }
}
