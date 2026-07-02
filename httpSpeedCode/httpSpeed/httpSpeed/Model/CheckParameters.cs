using System;
using System.Collections.Generic;
using System.Text;

namespace httpSpeed.Model
{
    public class CheckParameters
    {
        public bool PortIsValid(string port)
        {
            return int.TryParse(port, out int value);
        }
        public bool DomainIsValid(string domain)
        {
            return domain.Contains(":");
        }
    }
}
