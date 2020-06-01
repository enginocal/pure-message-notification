using System;

namespace PureNotificationSystem.Common.Exceptions
{
    public class PureNotificationException : Exception
    {
        public string Code { get; }

        public PureNotificationException()
        {
        }

        public PureNotificationException(string code)
        {
            Code = code;
        }

        public PureNotificationException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public PureNotificationException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public PureNotificationException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public PureNotificationException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
