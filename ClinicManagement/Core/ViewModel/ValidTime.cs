using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ClinicManagement.Core.ViewModel
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime time;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                                                  "HH:mm",
                                                  CultureInfo.CurrentCulture,
                                                  DateTimeStyles.None,
                                                  out time);
            return isValid;
        }
    }
}