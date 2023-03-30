using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceManagement.Core.Entity;

namespace WebServiceManagement.Core.Mapper
{
    public interface IAgencyEntityMapper
    {
        public AgencyEntity MapSingle(string jsonResponse);

        public List<AgencyEntity> MapList(string jsonResponse);
    }
}
