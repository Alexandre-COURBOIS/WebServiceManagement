using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebServiceManagement.Client.Entity;
using WebServiceManagement.Core.Entity;
using WebServiceManagement.Core.Mapper;

namespace WebServiceManagement.Client.Mapper
{
    public class ClientAgencyEntityMapper : IAgencyEntityMapper<IAgencyType>
    {
        public AgencyEntity MapSingle(string jsonResponse)
        {
            JsonElement json = JsonDocument.Parse(jsonResponse).RootElement;

            ClientAgencyEntity agencyEntity = JsonSerializer.Deserialize<ClientAgencyEntity>(json);

            setEntityFields(agencyEntity, json);

            return agencyEntity;
        }

        public List<AgencyEntity> MapList(string jsonResponse)
        {
            try
            {
                JsonElement json = JsonDocument.Parse(jsonResponse).RootElement;

                List<AgencyEntity> agencyEntities = new List<AgencyEntity>();

                var listItems = new List<JsonElement>(json.EnumerateArray());

                foreach(JsonElement agency in listItems)
                {
                   try
                    {
                        ClientAgencyEntity agencyEntity = new ClientAgencyEntity()
                        {
                            Id = agency.GetProperty("id").ToString(),
                            Code = agency.GetProperty("code").ToString(),
                            Libelle = agency.GetProperty("libelle").ToString()
                        };
                        agencyEntities.Add(agencyEntity);
                    }
                    catch(JsonException ex)
                    {
                       
                    }
                }

                return agencyEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
  
        }

        private void setEntityFields(ClientAgencyEntity agencyEntity, JsonElement json)
        {

            //TODO

        }
    }
}
