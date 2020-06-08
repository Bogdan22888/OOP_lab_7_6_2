using System;

namespace Lab07___2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file name: ");
            string filename = Console.ReadLine();
            Products prod = new Products();
            prod.ReadData(filename);

			string menu = "\nEnter:\tA - add a new item\n\tE - edit item\n\tD - delete item\n\tO - output items\n\tS - save to a text file\n\t0 - exit the program";
			char user;
			do
			{
				Console.WriteLine(menu);
				user = Convert.ToChar(Console.ReadLine());

				switch (user)
				{
					case 'A':
						Product temp = new Product();
						Console.WriteLine("Enter product id: ");
						temp.productId = Convert.ToInt32(Console.ReadLine());
						temp.name = Console.ReadLine();
						temp.weight = Convert.ToInt32(Console.ReadLine());
						temp.productionCost = Convert.ToInt32(Console.ReadLine());
						temp.finalCost = Convert.ToInt32(Console.ReadLine());
						prod.Add(temp);
						break;
					case 'E':
						Console.WriteLine("Enter index of what item you want to edit: ");
						int ed = Convert.ToInt32(Console.ReadLine());
						prod.Edit(ed);
						break;
					case 'D':
						Console.WriteLine("Enter index of what item you want to delete: ");
						int del = Convert.ToInt32(Console.ReadLine());
						prod.Delete(del);
						break;
					case 'O':
						prod.Output();
						break;
					case 'S':
						Console.WriteLine("Enter a file name: ");
						string newFilename = Console.ReadLine();
						prod.Save(newFilename);
						break;
					//case 'L':
					//	Hour leastHour = Hour.LeastPassengers(ref hours);
					//	leastHour.Output();
					//	break;
					//case 'W':
					//	Hour mostWordsHour = Hour.MostWordsInComment(ref hours);
					//	mostWordsHour.Output();
						//break;
					case '0':
						break;
					default:
						throw new Exception("There is no such button in menu.");
				}
			} while (user != '0');
		}
    }
}
