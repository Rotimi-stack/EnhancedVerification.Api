using EnhancedKycVerification.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhancedKycVerification.Application.Common.Interface
{
    public interface IKycContext
    {
        DbSet<tblRequestandResponseLogs> tblRequestAndResponse { get; set; }
    }
}
