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
    public partial class frmPeopleHome : Form
    {
        DataTable _AllPeople;
        public frmPeopleHome()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _AllPeople = clsPerson.GetAllPeople();
            dgvAllPeople.DataSource = _AllPeople;

            if(dgvAllPeople.Rows.Count > 0)
            {
                dgvAllPeople.Columns[0].HeaderText = "Person ID";
                dgvAllPeople.Columns[1].HeaderText = "National No";

                dgvAllPeople.Columns[2].HeaderText = "Full Name";
                dgvAllPeople.Columns[2].Width = 220;

                dgvAllPeople.Columns[3].HeaderText = "Date Of Birth";
                dgvAllPeople.Columns[3].Width = 150;

                dgvAllPeople.Columns[4].HeaderText = "Gender";

                dgvAllPeople.Columns[8].HeaderText = "Country";

            }

            lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();
            cmbFilterBy.SelectedIndex = 0;
        }

        private void frmPeopleHome_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cmbFilterBy.Text != "None");

            txtFilterBy.Clear();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch(cmbFilterBy.Text)
            {
                case "Person ID":
                    FilterValue = "PersonID";
                    break;

                case "National No":
                    FilterValue = "NationalNo";
                    break;

                case "Full Name":
                    FilterValue = "FullName";
                    break;

                case "Last Name":
                    FilterValue = "LastName";
                    break;

                case "Gender":
                    FilterValue = "Gender";
                    break;

                case "Phone":
                    FilterValue = "Phone";
                    break;

                case "Country":
                    FilterValue = "Country";
                    break;

                case "Date Of Birth":
                    FilterValue = "DateOfBirth";
                    break;

                default:
                    FilterValue = "None";
                    break;
            }

            if (FilterValue == "None" || string.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                _AllPeople.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();
                return;
            }

            if (FilterValue == "PersonID")
                _AllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterValue, txtFilterBy.Text);
            else
                _AllPeople.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterValue, txtFilterBy.Text);

            lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _LoadData();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvAllPeople.CurrentRow.Cells[0].Value;

            if(MessageBox.Show($"Are you sure you want to delete person with ID = {PersonID}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person has been deleted successfully");
                    _LoadData();
                }                             
                else
                {
                    MessageBox.Show("Can't delete this person, he is related to other data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;

                }
                
            }
            else
            {
                MessageBox.Show("Process has been cancelled");
            }
        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }
    }
}
