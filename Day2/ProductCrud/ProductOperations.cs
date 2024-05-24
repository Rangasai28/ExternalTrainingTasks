using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCrud
{

    public class ProductOperations
    {
        public List<Product> productsList = new List<Product>();

        public void AddProduct(Product item)
        {
            productsList.Add(item);
        }

        public void DeleteProduct(int index)
        {
            productsList.RemoveAt(index);
        }

        public void UpdateProduct(Product newPro,int id)
        {
            foreach (Product p in productsList)
            {
                if (p.productId == id)
                {
                    p.productName = newPro.productName;
                    p.productDescription = newPro.productDescription;
                    p.productImage = newPro.productImage;
                    p.productPrice = newPro.productPrice;
                }
            }
        }
        public List<Product> getProductList()
        {

            return productsList;
        }
    }
}
