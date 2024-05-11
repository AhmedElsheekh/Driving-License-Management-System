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
    public partial class frmUsersHome : Form
    {
        DataTable _AllUsers;
        public frmUsersHome()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _AllUsers = clsUser.GetAllUsers();
            dgvAllUsers.DataSource = _AllUsers;

            if(dgvAllUsers.Rows.Count > 0)
            {
                dgvAllUsers.Columns[0].HeaderText = "User ID";

                dgvAllUsers.Columns[1].HeaderText = "Person ID";

                dgvAllUsers.Columns[2].HeaderText = "Full Name";
                dgvAllUsers.Columns[2].Width = 220;

                dgvAllUsers.Columns[3].Width = 150;
            }

            lblNumberOfRecords.Text = dgvAllUsers.Rows.Count.ToString();
            cmbFilterBy.SelectedIndex = 0;
        }

        private void frmUsersHome_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFilterValue.Visible = cmbFilterBy.Text != "None";

            if(cmbFilterBy.Text == "Is Active")
            {
                cmbFilterValue.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                cmbFilterValue.DropDownStyle = ComboBoxStyle.Simple;
                cmbFilterValue.Text = "";
            }
        }

        private void cmbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch(cmbFilterBy.Text)
            {
                case "None":
                    break;
                case "User ID":
                    FilterValue = "UserID";
                    break;

                case "Person ID":
                    FilterValue = "PersonID";
                    break;

                case "Full Name":
                    FilterValue = "FullName";
                    break;

                case "Username":
                    FilterValue = "Username";
                    break;

                default:
                    break;
            }

            if(cmbFilterValue.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                cmbFilterValue_SelectedIndexChanged(null, null);
            }
            else
            {

                if (FilterValue == "None" || cmbFilterValue.Text == "")
                {
                    _AllUsers.DefaultView.RowFilter = "";
                    lblNumberOfRecords.Text = dgvAllUsers.Rows.Count.ToString();
                    return;
                }

                if (FilterValue == "PersonID" || FilterValue == "UserID")
                {
                    _AllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterValue, cmbFilterValue.Text.Trim());
                    lblNumberOfRecords.Text = dgvAllUsers.Rows.Count.ToString();
                    return;
                }
                else
                {
                    _AllUsers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterValue, cmbFilterValue.Text.Trim());
                }

                lblNumberOfRecords.Text = dgvAllUsers.Rows.Count.ToString();
            }

        }

        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            short FilterValue = -1;

            switch(cmbFilterValue.Text)
            {
                case "All":
                    break;

                case "Active":
                    FilterValue = 1;
                    break;

                case "Inactive":
                    FilterValue = 0;
                    break;
            }

            if(cmbFilterValue.Text == "All" || FilterValue == -1)
            {
                _AllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvAllUsers.Rows.Count.ToString();
                return;
            }
            else
            {
                _AllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", FilterValue);
            }

            lblNumberOfRecords.Text = dgvAllUsers.Rows.Count.ToString();
        }

        private void cmbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.Text == "Person ID" || cmbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _LoadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvAllUsers.CurrentRow.Cells[0].Value;

            if(MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show($"User with Id = {UserID} has been deleted successfully");
                    _LoadData();
                }
                else
                {
                    MessageBox.Show($"User Can't be deleted because it is related with other data");
                }
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void dgvAllUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
