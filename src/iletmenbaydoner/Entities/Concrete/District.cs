using System.ComponentModel.DataAnnotations.Schema;
using iletmenbaydoner.Entities.Core;

namespace iletmenbaydoner.Entities.Concrete
{
    [Table("Districts",Schema ="db_iletmen_baydoner")]
    public class District : EntityBaseModel, IEntity
    {
        public long DistrictId { get; set; }
        public string? DistrictName { get; set; }
    }

}