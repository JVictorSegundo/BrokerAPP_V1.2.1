using BrokerAPP.Domain.EntitiesRelationship;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BrokerAPP.Domain
{
    public class Client : CommonAttributes
    {
        public int Age { get; private set; }
        public long Balance { get; private set; }


        public int ManagerId { get; set; }
        [JsonIgnore]
        public Manager Manager { get; set; }

        [JsonIgnore]
        public IEnumerable<ClientAsset> ClientsAssets { get; set; }


        public Client (string name, int age, long balance, int id)
        {
            Validate(name, age, balance, id);
        }

        private void Validate (string name, int age, long balance, int id)
        {
            DomainValidations.CheckIf(string.IsNullOrEmpty(name), "ERROR! Name cannot be null or empty");
            DomainValidations.CheckIf(string.IsNullOrWhiteSpace(name), "ERROR! Name cannot be white space");
            DomainValidations.CheckIf(Regex.IsMatch(name, @"[^A-Za-zâ-ûÂ-Ûá-úÁ-Úã-õÃ-Õ\s]"), "ERROR! Name cannot have special characters or numbers");
            DomainValidations.CheckIf(name.Length > 40, "ERROR! Name is too long [more then 40 characters]");
            DomainValidations.CheckIf(name.Length < 10, "ERROR! Name is too short [less then 10 characters]");

            DomainValidations.CheckIf(age >= 110, "ERROR! Age cannot be above 110 (Are you sure this person still alive?)");
            DomainValidations.CheckIf(age < 18, "ERROR! Age cannot be bellow 18 (You can't consume alcohol and already want to invest?)");

            Name = name;
            Age = age;
            Balance = balance;
            Id = id;
        }
    }
}
