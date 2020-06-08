using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab07___2
{
    public class Product : IComparable
    {
        public int productId;
        public string name;
        public int weight;
        public int productionCost;
        public int finalCost;

        public Product()
        {
            productId = 0;
            name = "";
            weight = 0;
            productionCost = 0;
            finalCost = 0;
        }

        int IComparable.CompareTo(object obj)
        {
            Product prod = obj as Product;
            if (this.finalCost < prod.finalCost)
                return -1;
            else if (this.finalCost > prod.finalCost)
                return 1;
            else
                return 0;
        }

        public class SortByWeight : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                Product prod1 = obj1 as Product;
                Product prod2 = obj2 as Product;
                if (prod1.weight > prod2.weight) return 1;
                else if (prod1.weight < prod2.weight) return -1;
                else return 0;
            }
        }

        public class SortByProductCost : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                Product prod1 = obj1 as Product;
                Product prod2 = obj2 as Product;
                if (prod1.productionCost > prod2.productionCost) return 1;
                else if (prod1.productionCost < prod2.productionCost) return -1;
                else return 0;
            }
        }
    }

    public class Products : IEnumerable
    {
        private Product[] products;
        private int size;

        public Products()
        {
            products = new Product[10];
            size = 0;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++) yield return products[i];
        }

        public void Add(Product p)
        {
            if (size >= 10) return;
            products[size] = p;
            size++;
        }

        public void ReadData(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            Product temp;
            string[] prodInfo = new string[5];
            while (!reader.EndOfStream)
            {
                temp = new Product();
                prodInfo = reader.ReadLine().Split(' ');
                temp.productId = Convert.ToInt32(prodInfo[0]);
                temp.name = prodInfo[1];
                temp.weight = Convert.ToInt32(prodInfo[2]);
                temp.productionCost = Convert.ToInt32(prodInfo[3]);
                Add(temp);
            }
            reader.Close();
        }

        public void Edit(int index)
        {
            try
            {
                Console.WriteLine("Enter new info:");
                Console.WriteLine("Enter product id: ");
                products[index].productId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter product name: ");
                products[index].name = Console.ReadLine();
                Console.WriteLine("Enter product weight: ");
                products[index].weight = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter production cost: ");
                products[index].productionCost = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter production final cost: ");
                products[index].finalCost = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format!");
            }
        }

        public void Delete(int index)
        {
            List<Product> pr = new List<Product>(products);
            pr.RemoveAt(index);
            products = pr.ToArray();
        }

        public void Output()
        {
            int index = 1;
            foreach (Product product in products)
            {
                Console.WriteLine("Product #" + index);
                Console.WriteLine("Product ID: " + product.productId);
                Console.WriteLine("Product name: " + product.name);
                Console.WriteLine("Product production cost: " + product.productionCost);
                Console.WriteLine("Product final cost: " + product.finalCost);
                Console.WriteLine();
                index++;
            }
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            foreach (Product product in products)
            {
                writer.WriteLine(product.productId + " " + product.name + " " + product.weight + " " + product.productionCost + " " + product.finalCost);
            }
            writer.Flush();
            writer.Close();
        }
    }
}
