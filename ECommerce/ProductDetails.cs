using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    /// <summary>
    /// Class holds the property for the product details of the instance of <see cref="ProductDetails"/>
    /// </summary>
    public class ProductDetails
    {
        public static List<ProductDetails> productList = new List<ProductDetails>();
        /// <summary>
        /// static field for the auto incrementation of the product ID of the instance of <see cref="ProductDetails"/>
        /// </summary>
        private static int s_idInfo = 100;
        /// <summary>
        /// read only  property holds the product id of the instance of <see cref="ProductDetails"/>
        /// </summary>
        /// <value></value>
        public string ProductId { get;  }
        /// <summary>
        /// property holds the product name of the instance of <see cref="ProductDetails"/>
        /// </summary>
        /// <value></value>
        public string ProductName { get; set; }
        /// <summary>
        /// property holds the price of the product of the instance of the <see cref="ProductDetails"/>
        /// </summary>
        /// <value></value>
        public double Price { get; set; }
        /// <summary>
        /// property holds the stock availabilty of the product of the instance of <see cref="ProductDetails"/>
        /// </summary>
        /// <value></value>
        public int Stock { get; set; }
        /// <summary>
        /// property holds the shipping duration of the product of the instance of <see cref="ProductDetails"/>
        /// </summary>
        /// <value></value>
        public int ShippingDuration { get; set; }
        /// <summary>
        /// For initializing the values for the property of the instance of <see cref="ProductDetails"/>
        /// </summary>
        public ProductDetails()
        {
            s_idInfo++;
            ProductId = "PID" + s_idInfo;
        }
        /// <summary>
        /// for initializing the products of the instance of <see cref="ProductDetails"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stock"></param>
        /// <param name="price"></param>
        /// <param name="duration"></param>
        public static void Products(string name, int stock, double price, int duration)
        {
            ProductDetails product = new ProductDetails();
            product.ProductName = name;
            product.Price = price;
            product.Stock = stock;
            product.ShippingDuration = duration;
            productList.Add(product);
        }
        //to create product information and availability
        /// <summary>
        /// For showing the product information of the instance of <see cref="ProductDetails"/>
        /// </summary>
        public static void productInfo()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("Product ID     Product Name      Available Stock Quantity    Price Per Quantity  Shipping Duration");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            foreach (ProductDetails products in productList)
            {
                Console.WriteLine($"  {products.ProductId.PadRight(11, ' ')}{products.ProductName.PadRight(32, ' ')}{products.Stock.ToString().PadRight(22, ' ')}{products.Price.ToString().PadRight(20, ' ')}{products.ShippingDuration}");
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
            }
        }

        //To increase the stock quantity if cancelled
        /// <summary>
        /// for increasing the stock for the cancelled products of the instance of <see cref="ProductDetails"/>
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="quantity"></param>
        public static void IncreaseStock(string ID, int quantity)
        {
            foreach (ProductDetails product in productList)
            {
                if (product.ProductId == ID)
                {
                    product.Stock += quantity;
                }
            }
        }
    }
}