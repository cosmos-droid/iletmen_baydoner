using iletmenbaydoner.Entities.Core;

namespace iletmenbaydoner.Entities.Concrete
{
    public class Client : EntityBaseModel, IEntity
    {
        public long ClientId { get; set; }
        public string ClientName { get; set; }
    }
}