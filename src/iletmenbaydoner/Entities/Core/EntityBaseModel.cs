using System.ComponentModel.DataAnnotations.Schema;

namespace iletmenbaydoner.Entities.Core
{
    public class EntityBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}