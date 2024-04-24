using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    /// <summary>
    /// class holds the details of the customer of the instance of <see cref="CustomerDetails"/>
    /// </summary>
    public class CustomerDetails
    {
        /// <summary>
        /// static field for auto incrementation of the customer ID of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        private static int s_idInfo = 1000;
        /// <summary>
        /// read only property holds the customer ID of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        /// <value></value>
        public string CustomerId { get; }
        /// <summary>
        /// Property holds the name of the customer of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Property holds the city of the customer of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        /// <value></value>
        public string City { get; set; }
        /// <summary>
        /// Property holds the phone number of the customer of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        /// <value></value>
        public long Phone { get; set; }
        /// <summary>
        /// Property holds the Balance of the customer of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        /// <value></value>
        public double Balance { get; set; }
        /// <summary>
        /// Property holds the Mail of the customer of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        /// <value></value>
        public string Mail { get; set; }
        /// <summary>
        /// For initializing the value for the properties of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        public CustomerDetails()
        {
            s_idInfo++;
            CustomerId = "CID" + s_idInfo;
        }
    //To make purchase
    /// <summary>
    /// for make purchase of the instance of <see cref="CustomerDetails"/>
    /// </summary>
        public void Purchase()
        {
            ProductDetails.productInfo();
            Console.Write("Enter the Product Id you want to purchase: ");
            string id = Console.ReadLine().ToUpper();
            bool isPresent = false;
            while (!isPresent)
            {
                foreach (ProductDetails products in ProductDetails.productList)
                {
                    if (products.ProductId == id)
                    {
                        Console.WriteLine("Enter the quantity you want: ");
                        int quantity = int.Parse(Console.ReadLine());
                        if (products.Stock >= quantity)
                        {
                            Console.WriteLine("Delivery Charge is 50");
                            double totalPrice = (quantity * products.Price) + 50;
                            Console.WriteLine($"Total Price= {totalPrice}");
                            if (Balance >= totalPrice)
                            {
                                DeductBalance(totalPrice);
                                OrderDetails orders = new OrderDetails();
                                orders.CustomerId = CustomerId;
                                orders.ProductId = id;
                                orders.TotalPrice = totalPrice;
                                orders.Quantity = quantity;
                                OrderDetails.orderList.Add(orders);
                                products.Stock -= quantity;
                                Console.WriteLine($"Order placed successfully. OrderID: {orders.OrderId}");
                                Console.WriteLine($"Your order will be delivered on {orders.PurchaseDate.AddDays(products.ShippingDuration).ToString("dd/MM/yyyy")}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient wallet balance. Please Reacharge and purchase again");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Required count not available. Current availability is {products.Stock}");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        isPresent = true;
                    }
                }
                if (!isPresent)
                {
                    Console.WriteLine("Invalid ProductID");
                    Console.Write("Enter a valid Product ID: ");
                    id = Console.ReadLine().ToUpper();
                }
            }
        }
        //to cancel order
        /// <summary>
        /// For cancelling the order of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        public void CancelOrder()
        {
            bool isPresent = OrderDetails.OrderHistory(CustomerId, "Ordered");
            if (isPresent)
            {
                Console.Write("Enter the OrderId you want to cancel: ");
                string id = Console.ReadLine().ToUpper();
                bool isValid = false;
                while (!isValid)
                {
                    foreach (OrderDetails order in OrderDetails.orderList)
                    {
                        if (order.OrderId == id && order.Status == (Status)1)
                        {
                            order.Status = (Status)2;
                            WalletRecharge(order.TotalPrice);
                            ProductDetails.IncreaseStock(order.ProductId, order.Quantity);
                            isValid = true;
                            Console.WriteLine($"Order ID: {order.OrderId} Cancelled Successfully");
                        }
                    }
                    if (!isValid)
                    {
                        Console.WriteLine("Order ID invalid");
                        Console.Write("Enter the valid OrderID: ");
                        id = Console.ReadLine().ToUpper();
                    }
                }
            }
        }
        /// <summary>
        /// for adding amount to the wallet balance of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        /// <param name="amount"></param>
        public void WalletRecharge(double amount)
        {
            Balance += amount;
        }
        /// <summary>
        /// for deducting amount from the wallet balance of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        public void DeductBalance(double amount)
        {
            Balance -= amount;
        }
    }
}