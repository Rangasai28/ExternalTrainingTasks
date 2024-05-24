namespace WebApiProductCustomerAsync.Models;

public class CustomerProductDetails
{
    public int customerId { get; set; }
    public string customerName { get; set; }

    public List<Product> products {  get; set; }


    public CustomerProductDetails()
    {
        products = new List<Product>();
        
    }
}
