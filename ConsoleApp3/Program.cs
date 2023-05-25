using System;

namespace PriceList
{
    class Program
    {
        static void Main(string[] args)
        {
            PRICE[] priceList = new PRICE[8];

            for (int i = 0; i < priceList.Length; i++)
            {
                Console.WriteLine($"Enter information for product #{i + 1}:");
                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Store name: ");
                string storeName = Console.ReadLine();
                Console.Write("Price (RUB): ");
                double price = double.Parse(Console.ReadLine());

                priceList[i] = new PRICE(id, storeName, price);
            }

            Array.Sort(priceList);

            Console.Write("Enter product name to search: ");
            string productName = Console.ReadLine();

            bool found = false;

            foreach (PRICE price in priceList)
            {
                if (price.ID.ToString() == productName)
                {
                    Console.WriteLine($"Product ID: {price.ID}");
                    Console.WriteLine($"Store name: {price.StoreName}");
                    Console.WriteLine($"Price: {price.Price} RUB");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Product with ID '{productName}' not found.");
            }
        }
    }

    class PRICE : ICloneable, IComparable<PRICE>
    {
        public int ID { get; set; }
        public string StoreName { get; set; }
        public double Price { get; set; }

        public PRICE(int id, string storeName, double price)
        {
            ID = id;
            StoreName = storeName;
            Price = price;
        }

        public object Clone()
        {
            return new PRICE(ID, StoreName, Price);
        }

        public int CompareTo(PRICE other)
        {
            return ID.CompareTo(other.ID);
        }
    }

    class PriceComparer : IComparer<PRICE>
    {
        public int Compare(PRICE x, PRICE y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}