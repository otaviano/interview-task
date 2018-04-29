using IdeiaNoAr.Test.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace IdeiaNoAr.Test.Integration
{
    public class PersonIntegration
    {
        const string url = "https://api.pipedrive.com/v1/organizations/{0}/persons?start=0&api_token=ede052e70c0563b61f8efd8edbf580cab4401667";

        public IList<Person> GetPeopleFromOrganization(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(string.Format(url, id))).Result;

                var obj = new JavaScriptSerializer().Deserialize<dynamic>(response);

                return ExternalPersonToDomain(obj);
            }
        }

        private IList<Person> ExternalPersonToDomain(dynamic obj)
        {
            var list = obj["data"] as IEnumerable<dynamic>;
            var returnList = new List<Person>();

            foreach (var item in list)
            {
                returnList.Add(new Person
                {
                    ExternalId  = item["id"],
                    Name        = item["name"],
                    Info        = item["fe618e15cd7a9b9265e5b48cae2fb6f89697218f"],
                    Emails      = GetObj<Email>(item["email"] as IEnumerable<dynamic>),
                    Phones      = GetObj<Phone>(item["phone"] as IEnumerable<dynamic>)
                });
            }

            return returnList;
        }

        public IList<T> GetObj<T>(IEnumerable<dynamic> emails) 
            where T : IAuxStruct, new()
        {
            var list = new List<T>();

            foreach (var item in emails)
            {
                list.Add(new T
                {
                    Label = item["label"],
                    Value = item["value"],
                    Primary = Convert.ToBoolean(item["primary"])
                });
            };

            return list;
        }
    }
}
