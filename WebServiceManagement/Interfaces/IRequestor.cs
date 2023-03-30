using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceManagement.Core.Entity;

namespace WebServiceManagement.Core.Interfaces
{
    public interface IRequestor
    {
        Task<List<AgencyEntity>> getAgencies();
        
        Task<AgencyEntity> getAgency(int agencyId);
    }
}
