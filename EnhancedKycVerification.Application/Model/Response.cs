using System;
using System.Collections.Generic;
using System.Text;

namespace EnhancedKycVerification.Application.Model
{
    public class Response
    {
        public string JSONVersion { get; set; } = String.Empty;
        public string SmileJobID { get; set; } = String.Empty;
        public PartnerParams PartnerParams { get; set; }
        public string ResultType { get; set; } = String.Empty;
        public string ResultText { get; set; } = String.Empty;
        public string ResultCode { get; set; } = String.Empty;
        public string IsFinalResult { get; set; } = String.Empty;
        public Actions Actions { get; set; }
        public string Country { get; set; } = String.Empty;
        public string IDType { get; set; } = String.Empty;
        public string IDNumber { get; set; } = String.Empty;
        public string ExpirationDate { get; set; } = String.Empty;
        public string FullName { get; set; } = String.Empty;
        public string DOB { get; set; } = String.Empty;
        public string Photo { get; set; } = String.Empty;
        public string signature { get; set; } = String.Empty;
        public DateTime timestamp { get; set; }
    }

    public class Actions
    {
        public string Verify_ID_Number { get; set; } = String.Empty;
        public string Return_Personal_Info { get; set; } = String.Empty;
    }

    public class PartnerParams
    {
        public string user_id { get; set; } = String.Empty;
        public string job_id { get; set; } = String.Empty;
        public int job_type { get; set; }
    }



    public class EnhancedKYCResponse
    {
        public string error { get; set; }
        public string code { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
