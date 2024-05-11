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
    public partial class frmFindPerson : Form
    {
        int _PersonID;
        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

            MessageBox.Show($"Person {_PersonID}");
        }
    }
}
