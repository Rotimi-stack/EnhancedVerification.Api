using EnhancedKycVerification.Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EnhancedKycVerification.Application.Common.EnhancedKycVerification.Command
{
    public class CallBackUrlCommand : IRequest<EnhancedKYCResponse>
    {
        public bool success { get; set; }
    }
}

