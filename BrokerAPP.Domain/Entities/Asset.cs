using BrokerAPP.Domain.EntitiesRelationship;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BrokerAPP.Domain
{
    public class Asset : CommonAttributes
    {
        
        public IEnumerable<ClientAsset> ClientsAssets { get; set; }


        public int AssetGroupId { get; set; }
        [JsonIgnore]
        public AssetGroup AssetGroup { get; set; }


        public Asset (string name, int id)
        {
            Validate(name, id);
        }


        public void Validate (string name, int id)
        {
            DomainValidations.CheckIf(string.IsNullOrEmpty(name), "ERROR! Name cannot be null or empty");
            DomainValidations.CheckIf(string.IsNullOrWhiteSpace(name), "ERROR! Name cannot be white space");
            DomainValidations.CheckIf(Regex.IsMatch(name, @"[^A-Za-z0-9\s]"), "ERROR! Name cannot have special characters or numbers");
            DomainValidations.CheckIf(name.Length > 15, "ERROR! Name is too long [more then 15 characters]");
            DomainValidations.CheckIf(name.Length < 2, "ERROR! Name is too short [less then 2 characters]");

            Name = name;
            Id = id;
        }
    }
}
