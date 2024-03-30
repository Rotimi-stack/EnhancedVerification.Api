using EnhancedKycVerification.Application.Common.EnhancedKycVerification.Command;
using EnhancedKycVerification.Application.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnhancedVerification.Api.Controllers
{
    public class EnhancedKycVerificationController : BaseController
    {
        [HttpPost("/enhanced/kyc/verification")]
        public async Task<ActionResult<EnhancedKYCResponse>> GetEnhancedKYCVerification(EnhancedVerificationCommand lyc)
        {
            return await Mediator.Send(lyc);
        }

        [HttpPost("/callbackUrl")]
        public async Task<ActionResult<EnhancedKYCResponse>> CallBackUrl(CallBackUrlCommand vyc)
        {
            return await Mediator.Send(vyc);
        }
    }
}
