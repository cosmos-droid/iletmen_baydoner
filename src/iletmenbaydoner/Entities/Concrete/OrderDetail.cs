using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iletmenbaydoner.Entities.Core;



namespace iletmenbaydoner.Entites.Concrete
{
    [Table("OrderDetails", Schema = "db_iletmen_baydoner")]
    public class OrderDetail : EntityBaseModel, IEntity
    {
        public long OrderDetailId { get; set; }

        public string OrderNo { get; set; }
        public long ProductGroupTypeId { get; set; }

        [ForeignKey("OrderNo")]
        public OrderHeader? OrderHeader { get; set; }
    }
}