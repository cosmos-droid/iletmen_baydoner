using System.ComponentModel.DataAnnotations.Schema;
using iletmenbaydoner.Entities.Core;

namespace iletmenbaydoner.Entities.Concrete
{
    [Table("Branches", Schema = "db_iletmen_baydoner")]
    public class Branch : EntityBaseModel, IEntity
    {
        public long BranchId { get; set; }
        public long ClientId { get; set; }
        public string? BranchName { get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; set; }

    }
}