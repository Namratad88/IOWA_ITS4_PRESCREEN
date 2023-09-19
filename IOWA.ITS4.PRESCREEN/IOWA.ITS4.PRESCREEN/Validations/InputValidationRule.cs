using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IOWA.ITS4.PRESCREEN.Validations
{
    public class InputValidationRule 
    {
        public Boolean validationRule(string mapID, string adjacentMapID,ref string errorMessage)
        {
            if(mapID.Length==0 || adjacentMapID.Length == 0) {
                errorMessage = "Enter County Code";
                return false;
            }
            if (mapID.Length > 2 || adjacentMapID.Length > 2)
            {
                errorMessage = "County code cannot exceed two digits";
                return false;
            }

            Regex regex = new Regex("^[0-9]{1,2}$");
            if (!regex.IsMatch(mapID) || !regex.IsMatch(adjacentMapID))
            {
                errorMessage ="County code cannot have characters";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
