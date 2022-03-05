using System;

namespace BrokerAPP.Domain
{
    public class DomainValidations : Exception
    {
        public DomainValidations(string error) : base(error)
        {}


        public static void CheckIf (bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidations(message);
        }

        public static void CheckIfInteger (string number)
        {
            bool isConvertible = int.TryParse(number, out int response);

            if (!isConvertible)
                throw new DomainValidations("ERROR! Just number are allow");
        }
    }
}
