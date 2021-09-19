using System.Linq;
using System.IO;
using System.Collections.Generic;
using ExLambda.Entities;
using System;
using System.Globalization;

namespace ExLambda
{
	class Program
	{
		static void Main(string[] args)
		{
			
			string path = @"C:\Users\MAON\Projetos\Exercicios Udemy\ExLambda\ExLambda\ExLambda\Produtos.txt";

			List<Products> list = new List<Products>();

			// Código usado para ler e listar o arquivo
			using (StreamReader leitorArquivo = File.OpenText(path))
			{
				while (!leitorArquivo.EndOfStream) {
					string[] fields = leitorArquivo.ReadLine().Split(',');
					string name = fields[0];
					double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
					list.Add(new Products(name, price));
				}
			}

			//Calcular média usando LINQ
			var average = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
			Console.WriteLine($"Average price {average.ToString("F2", CultureInfo.InvariantCulture)}");

			Console.WriteLine("******************************");


			//Mostrar os produtos abaixo da média e ordenados em decrescente
			var names = list.Where(p => p.Price < average).OrderByDescending(p => p.Name);
			foreach (var name in names)
			{
				Console.WriteLine($"Below the average {name.Name}");
			}
		}
	}
}
