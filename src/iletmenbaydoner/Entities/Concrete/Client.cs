using System.ComponentModel.DataAnnotations.Schema;
using iletmenbaydoner.Entities.Core;

namespace iletmenbaydoner.Entities.Concrete
{
    [Table("Clients", Schema = "db_iletmen_baydoner")]
    public class Client : EntityBaseModel, IEntity
    {
        public long ClientId { get; set; }
        public required string ClientName { get; set; }
    }
}