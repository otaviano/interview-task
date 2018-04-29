using IdeiaNoAr.Test.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace IdeiaNoAr.Test.Integration
{
    public class OrganizationIntegration
    {
        const string url = "https://api.pipedrive.com/v1/organizations/{0}?api_token=ede052e70c0563b61f8efd8edbf580cab4401667";

        public Organization GetOrganization(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(string.Format(url, id))).Result;

                var obj = new JavaScriptSerializer().Deserialize<dynamic>(response);

                return ExternalOrganizationToDomain(obj);
            }
        }

        private static Organization ExternalOrganizationToDomain(dynamic obj)
        {
            if (!Convert.ToBoolean(obj["success"]))
                throw new ApplicationException("Falha na integração com o pipedrive");

            var objData = obj["data"];

            return new Organization
            {
                ExternalId = objData["id"],
                Name = objData["name"],
                Owner = new Person
                {
                    Name = objData["owner_id"]["name"],
                    ExternalId = objData["owner_id"]["id"],
                    Emails = new List<Email> { new Email { Value = objData["owner_id"]["email"] }  },
                },
                Address = new Address
                {
                    AddressDesc = objData["address"],
                    Subpremise = objData["address_subpremise"],
                    StreetNumber = objData["address_street_number"],
                    Route = objData["address_route"],
                    Sublocality = objData["address_sublocality"],
                    Locality = objData["address_locality"],
                    AdminAreaLevel1 = objData["address_admin_area_level_1"],
                    AdminAreaLevel2 = objData["address_admin_area_level_2"],
                    Country = objData["address_country"],
                    PostalCode = objData["address_postal_code"],
                    FormattedAddress = objData["address_formatted_address"]
                }
            };
        }
    }
}
