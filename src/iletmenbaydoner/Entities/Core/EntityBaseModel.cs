using System.ComponentModel.DataAnnotations.Schema;

namespace iletmenbaydoner.Entities.Core
{
    public class EntityBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

    }
}