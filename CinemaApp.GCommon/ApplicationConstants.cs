
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.GCommon;

public static class ApplicationConstants
{
    public const string AppDateFormat = "yyyy-mm-dd";

    public static class TempDataKeys
    {
        public const string SuccessMessage = "SuccessMessage";
        public const string ErrorMessage = "ErrorMessage";
    }

    public static class CinemaConstants
    {
        public const int NameMinLength = 4;

        public const int NameMaxLength = 20;

    }
    public static class ValidationMessages
    {
        public const string RequiredError = "Field is required.";
        public const string MinLengthError = "Field {0} must be min {2} symbols length.";
        public const string MaxLengthError = "Field {0} must be max {1} symbols length.";

    }
}


