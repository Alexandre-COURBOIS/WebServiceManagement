using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceManagement.Core.Entity;
using WebServiceManagement.Core.Interfaces;

namespace WebServiceManagement.Requestor
{
    public abstract class Requestor : IRequestor
    {
        abstract public Task<List<AgencyEntity>> getAgencies();
        abstract public Task<AgencyEntity> getAgency(int agencyId);
    }
}
