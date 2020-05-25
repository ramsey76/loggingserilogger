using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace logging
{
    [Serializable]
    public sealed class LoggingContext : Dictionary<string, object>
    {
        public LoggingContext() : base()
        {}

        private LoggingContext(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {}

        public void PushProperty(string name, object value, bool destructureObjects = false)
        {   
            this.Add(name, value);
        }

        public void PopProperty(string name)
        {

            if (this.ContainsKey(name))
                this.Remove(name);
        }
    }
}