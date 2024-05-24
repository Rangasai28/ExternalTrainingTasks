namespace WebApiEFAssignment.Models
{
    public class CustomerProductTemp
    {
        public int customerId { get; set; }
        public string customerName { get; set; }

        public List<Product> Products { get; set; }

      
    }
}
