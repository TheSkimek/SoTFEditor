using System;
using System.Collections.Generic;
using System.Linq;

namespace SoTFEditor
{
    public class CustomTextBox: System.Windows.Forms.TextBox
    {
        public string parentItemId { get; set; }
        public string oldValue { get; set; }
        public bool changedValue { get; set; }

        public void validateCustomTextBoxNumber(object? sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if((e.KeyChar == '-'))
            {
                (sender as TextBox).Text = "-1";
                e.Handled = true;
            }
        }
    }
}
