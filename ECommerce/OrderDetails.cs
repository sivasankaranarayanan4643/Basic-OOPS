using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    /// <summary>
    /// Enum status for getting the order status of the instance of <see cref="OrderDetails"/>
    /// </summary>
    public enum Status { Select, Ordered, Cancelled }
    public class OrderDetails
    {
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        /// <summary>
        /// static field for auto incrementation of the order id of the instance of <see cref="OrderDetails"/>
        /// </summary>
        private static int s_idInfo = 1000;
        /// <summary>
        /// Read only property holds the order ID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        /// <value></value>
        public string OrderId { get; }
        /// <summary>
        /// property holds the customer ID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// property holds the product ID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        /// <value></value>
        public string ProductId { get; set; }
        /// <summary>
        /// Property holds the Total Price of the instance of <see cref="OrderDetails"/>
        /// </summary>
        /// <value></value>
        public double TotalPrice { get; set; }
        /// <summary>
        /// property holds the date of the purchase of the instance of <see cref="OrderDetails"/>
        /// </summary>
        /// <value></value>
        public DateOnly PurchaseDate { get; set; }
        /// <summary>
        /// Property holds the qunatity of the instance of <see cref="OrderDetails"/>
        /// </summary>
        /// <value></value>
        public int Quantity { get; set; }
        /// <summary>
        /// Property holds the status of the order of the instance of <see cref="OrderDetails"/>
        /// </summary>
        /// <value></value>

        public Status Status { get; set; }

        /// <summary>
        /// for initializing values for the properties of the instance of <see cref="OrderDetails"/>
        /// </summary>

        public OrderDetails()
        {
            s_idInfo++;
            OrderId = "OID" + s_idInfo;
            DateTime Date = DateTime.Now;
            PurchaseDate = DateOnly.FromDateTime(Date);
            Status = (Status)1;
        }
        //To show order history
        /// <summary>
        /// For showing the order history of the user of the instance of <see cref="OrderDetails"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool OrderHistory(string id, string type)
        {

            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Order ID   Customer ID   Product ID   Total Price   Purchase Date   Quantitiy Pucrchased   Order Status ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            bool isPresent = false;
            foreach (OrderDetails orders in orderList)
            {
                if (orders.CustomerId == id && type == "ALL")
                {
                    Console.WriteLine($"{orders.OrderId.PadRight(13, ' ')}{orders.CustomerId.PadRight(14, ' ')}{orders.ProductId.PadRight(14, ' ')}{orders.TotalPrice.ToString().PadRight(13, ' ')}{orders.PurchaseDate.ToString("dd/MM/yyyy").PadRight(25, ' ')}{orders.Quantity.ToString().PadRight(15, ' ')}{orders.Status}");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                    isPresent = true;
                }
                else if (orders.CustomerId == id && type == "Ordered" && orders.Status == (Status)1)
                {
                    Console.WriteLine($"{orders.OrderId.PadRight(13, ' ')}{orders.CustomerId.PadRight(14, ' ')}{orders.ProductId.PadRight(14, ' ')}{orders.TotalPrice.ToString().PadRight(13, ' ')}{orders.PurchaseDate.ToString("dd/MM/yyyy").PadRight(25, ' ')}{orders.Quantity.ToString().PadRight(15, ' ')}{orders.Status}");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                    isPresent = true;
                }
            }
            if (!isPresent)
            {
                Console.WriteLine("No orders made");
            }
            return isPresent;
        }
    }


}