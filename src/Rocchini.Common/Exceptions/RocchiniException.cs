using System;

namespace Rocchini.Common.Exceptions
{
    public class RocchiniException : Exception
    {
        public string Code { get; }

        public RocchiniException()
        {
        }

        public RocchiniException(string code)
        {
            Code = code;
        }

        public RocchiniException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public RocchiniException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }
        public RocchiniException(Exception innerException, string message, params object[] args) : this(innerException, string.Empty, message, args)
        {
        }
        public RocchiniException(Exception innerException, string code, string message, params object[] args) : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
