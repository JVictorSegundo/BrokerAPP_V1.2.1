using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BrokerAPP.Domain
{
    public class AssetGroup : CommonAttributes
    {
        public IEnumerable<Asset> Assets { get; set; }

        public AssetGroup (string name, int id)
        {
            Validate(name, id);
        }

        private void Validate (string name, int id)
        {
            DomainValidations.CheckIf(string.IsNullOrEmpty(name), "ERROR! Name cannot be null or empty");
            DomainValidations.CheckIf(string.IsNullOrWhiteSpace(name), "ERROR! Name cannot be white space");
            DomainValidations.CheckIf(Regex.IsMatch(name, @"[^A-Za-zâ-ûÂ-Ûá-úÁ-Úã-õÃ-Õ\s]"), "ERROR! Name cannot have special characters or numbers");
            DomainValidations.CheckIf(name.Length > 20, "ERROR! Name is too long [more then 20 characters]");
            DomainValidations.CheckIf(name.Length < 3, "ERROR! Name is too short [less then 3 characters]");

            Name = name;
            Id = id;
        }
    }
}
