﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Presentation.Global_Classes
{
    public static class clsValidation
    {
        public static bool ValidateEmail(string Email)
        {
            string Pattern = "^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$";
            Regex regex = new Regex(Pattern);
            return regex.IsMatch(Email);
        }

        public static bool ValidateInt(string Number)
        {
            string Pattern = "^[0-9]*$";
            Regex regex = new Regex(Pattern);
            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            string Pattern = "^[0-9]*(?:\\.[0-9]*)?$";
            Regex regex = new Regex(Pattern);
            return regex.IsMatch(Number);
        }

        public static bool ValidateNumber(string Number)
        {
            return ValidateInt(Number) || ValidateFloat(Number);
        }
    }
}
