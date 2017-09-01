using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart
{
    public delegate void CartEvent(object sender, Product p);

    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();
            EventListener listener = new EventListener(cart);

            cart.AddToCart(new Product("I001", "Item 01", 75.50));
            Console.ReadKey();
        }
    }

    class EventListener
    {
        private ShoppingCart List;

        public EventListener(ShoppingCart list)
        {
            List = list;
            // Add "ListChanged" to the Changed event on "List".
            List.Add += new CartEvent(ListChanged);
        }

        // This will be called whenever the list changes.
        private void ListChanged(object sender, Product p)
        {
            Console.WriteLine("Product " + p.Pr_name + " was added to the cart");
        }

        public void Detach()
        {
            // Detach the event and delete the list
            List.Add -= new CartEvent(ListChanged);
            List = null;
        }
    }


    public class Product : IComparable<Product>
    {
        private string pr_code;

        public string Pr_code
        {
            get { return pr_code; }
            set { pr_code = value; }
        }

        private string pr_name;

        public string Pr_name
        {
            get { return pr_name; }
            set { pr_name = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Product(string pr_code, string pr_name, double price)
        {
            this.pr_code = pr_code;
            this.pr_name = pr_name;
            this.price = price;
        }

        public int CompareTo(Product other)
        {
            int result = 0;

            if (other.price > this.price)
            {
                result = -1;
            }
            else if (other.price < this.price)
            {
                result = 1;
            } else {
                result = 0;
            } 

            return result;
        }
    }

    class ShoppingCart
    {
        private List<Product> productList;

        public Product this [int i]
        {
            get { return productList[i]; }
            set { productList[i] = value; }
        }

        internal List<Product> ProductList
        {
            get { return productList; }
            set { productList = value; }
        }

        public ShoppingCart(List<Product> productList)
        {
            this.productList = productList;
        }

        public ShoppingCart()
        {
            this.productList = new List<Product>();
        }

        public void AddToCart(Product product)
        {
            productList.Add(product);
            OnChanged(product);
        }

        public void DisplayCart()
        {
            foreach (Product product in productList)
            {
                Console.WriteLine(product.Pr_name);
            }
        }
        
        public event CartEvent Add;
        protected virtual void OnChanged(Product p)
        {
            if (Add != null)
                Add(this, p);
        }
      
    }
}
