using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCrud
{
    public  class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }

        public string productDescription { get; set; }

        public string productImage { get; set; }

        public decimal productPrice {  get; set; }

        public Product()
        {
             
        }
        public Product(int pId,string pName,string pDiscription,string pImage,decimal pPrice)
        {
            productId = pId;
            productName = pName;
            productDescription = pDiscription;
            productImage = pImage;
            productPrice = pPrice;
        }


    }
}
