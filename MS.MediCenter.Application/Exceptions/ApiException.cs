using System;
using System.Globalization;

namespace MS.MediCenter.Application.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException() : base() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, params object[] arg) : base(string.Format(CultureInfo.CurrentCulture, message, arg)) { }
    }
}
