using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectSound.WinForms.Helper
{
    static class ErrorHandler
    {
        public const string txtfield = "Required field";
        public const string CheckedListBoxfield = "You need to choose at least one item";
        public const string FormatChecker = "Incorrect format";

        public static bool RequiredFiled(Control control, ErrorProvider err, string message = txtfield)
        {
            bool valid = true;

            if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
                valid = false;
            else if (control is ComboBox && (control as ComboBox).SelectedIndex == -1)
                valid = false;
            else if (control is RichTextBox && string.IsNullOrEmpty((control as RichTextBox).Text))
                valid = false;
            else if (control is PictureBox && (control as PictureBox).Image == null)
                valid = false;
            else if (control is CheckedListBox)
                valid = false;

            if (!valid)
            {
                err.SetError(control, message);
                return false;
            }

            err.Clear();
            return true;
        }

        public static bool CheckFormatOfRunningTime(Control control, ErrorProvider err, string message = txtfield)
        {
            string Timeformat = "^(2[0-3]|[01]?[0-9]):([0-5]?[0-9]):([0-5]?[0-9])$";
            if (!Regex.IsMatch(control.Text, Timeformat))
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }
        public static bool CheckFormatOfEmail(Control control, ErrorProvider err, string message = txtfield)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(control.Text);
                if (addr.Address == control.Text)
                {
                    err.Clear();
                }
                return true;
            }
            catch
            {
                err.SetError(control, message);
                return false;
            }
            

        }
        public static bool CheckIfPassEqual(Control control, Control control1, ErrorProvider err, string message = txtfield)
        {
            if (control1.Text == control.Text)
            {
                err.Clear();
                return true;
            }
            else
            {
                err.SetError(control, message);
                err.SetError(control1, message);
                return false;
            }
        }
    }
}
