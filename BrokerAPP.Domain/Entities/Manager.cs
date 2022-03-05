using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BrokerAPP.Domain
{
    public class Manager : CommonAttributes
    {
        public int Age { get; private set; }


        public IEnumerable<Client> Clients { get; set; }


        public Manager (string name, int age, int id)
        {
            Validate(name, age, id);
        }


        public void Validate (string name, int age, int id)
        {
            DomainValidations.CheckIf(string.IsNullOrEmpty(name), "ERROR! Name cannot be null or empty");
            DomainValidations.CheckIf(string.IsNullOrWhiteSpace(name), "ERROR! Name cannot be white space");
            DomainValidations.CheckIf(Regex.IsMatch(name, @"[^A-Za-zâ-ûÂ-Ûá-úÁ-Úã-õÃ-Õ\s]"), "ERROR! Name cannot have special characters or numbers");
            DomainValidations.CheckIf(name.Length > 40, "ERROR! Name is too long [more then 40 characters]");
            DomainValidations.CheckIf(name.Length < 10, "ERROR! Name is too short [less then 10 characters]");

            DomainValidations.CheckIf(age >= 70, "ERROR! Age cannot be above 70 (Go home granpa!)");
            DomainValidations.CheckIf(age < 20, "ERROR! Age cannot be bellow 20 (Too young to assume so responsibility)");

            Name = name;
            Age = age;
            Id = id;
        }
    }
}
