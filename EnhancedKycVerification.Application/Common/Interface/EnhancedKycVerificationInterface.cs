using EnhancedKycVerification.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnhancedKycVerification.Application.Common.Interface
{
    public interface EnhancedKycVerificationInterface
    {
        Task<EnhancedKYCResponse> GetEnhancedKYCVerification(EnhancedKycVerificationResources kyc);
        Task<EnhancedKYCResponse> CallBackUrl(CallbackUrlResource kyc);
    }
}
