﻿using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses.Local_Licenses
{
    public partial class frmLicenseInfo : Form
    {
        int _LicenseID;
        clsLicense _License;
        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;

            ctrlLicenseInfo1.LoadLicenseInfo(LicenseID);
        }
    }
}
