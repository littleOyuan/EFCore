namespace CRM.Domain.Entities
{
    public partial class Customer : Entity
    {
        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }
    }
}
