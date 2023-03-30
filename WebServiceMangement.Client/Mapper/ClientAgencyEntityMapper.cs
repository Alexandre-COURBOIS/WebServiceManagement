using System.Text.Json;

using WebServiceManagement.Client.Entity;
using WebServiceManagement.Core.Entity;
using WebServiceManagement.Core.Mapper;

namespace WebServiceManagement.Client.Mapper
{
    public class ClientAgencyEntityMapper : IAgencyEntityMapper<IAgencyType>
    {
        public AgencyEntity Map(string jsonResponse)
        {
            JsonDocument jsonArray = JsonDocument.Parse(jsonResponse);

            JsonElement json = jsonArray.RootElement[0];
            
            ClientAgencyEntity agencyEntity = JsonSerializer.Deserialize<ClientAgencyEntity>(json.ToString());
            
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
            agencyEntity.Id = json.GetProperty("id").ToString();
            agencyEntity.Code = json.GetProperty("code").ToString();
            agencyEntity.Libelle = json.GetProperty("libelle").ToString();
        }
    }
}
