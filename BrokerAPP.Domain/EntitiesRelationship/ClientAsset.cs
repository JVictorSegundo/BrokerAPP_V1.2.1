using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAPP.Domain.EntitiesRelationship
{
    public class ClientAsset
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
