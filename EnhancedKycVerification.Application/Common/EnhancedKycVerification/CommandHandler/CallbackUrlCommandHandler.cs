using EnhancedKycVerification.Application.Common.EnhancedKycVerification.Command;
using EnhancedKycVerification.Application.Common.Interface;
using EnhancedKycVerification.Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnhancedKycVerification.Application.Common.EnhancedKycVerification.CommandHandler
{
    public class CallbackUrlCommandHandler : IRequestHandler<CallBackUrlCommand, EnhancedKYCResponse>
    {
        private readonly EnhancedKycVerificationInterface _kyc;
        public CallbackUrlCommandHandler(EnhancedKycVerificationInterface kyc)
        {
            _kyc = kyc;
        }
        public async Task<EnhancedKYCResponse> Handle(CallBackUrlCommand request, CancellationToken cancellationToken)
        {
            var data = new CallbackUrlResource
            {
                success = request.success
            };
            return await _kyc.CallBackUrl(data);
        }
    }
}
