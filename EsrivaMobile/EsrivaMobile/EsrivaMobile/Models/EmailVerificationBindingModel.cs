using System;
using System.Collections.Generic;
using System.Text;

namespace EsrivaMobile.Models
{
    public class EmailVerificationBindingModel
    {
        public string TargetEmail { get; set; }
        public string OTPCode { get; set; }
    }
}
