using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Boss001
{
    public class RequiredValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           ValidationResult result = null;

            string content = value.ToString();
            bool isValid = !string.IsNullOrEmpty(content);
            result = new ValidationResult(isValid, isValid ? string.Empty : "Champ requis");

            return result;
        }
    }
}
