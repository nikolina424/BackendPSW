using System;
using System.Runtime.Serialization;

namespace PSWHospital.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg) { }
        protected NotFoundException(SerializationInfo info,
                                          StreamingContext context) : base(info, context) { }
    }
}
