using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
	class Program
	{
		static void Main(string[] args)
		{
			WithoutGenerics();
			WithGenerics();
			DelegateDemo();
		}


		static void WithoutGenerics()
		{
			ArrayList list = new ArrayList();
			list.Add(1);
			list.Add(2);
			list.Add(3);
			for (int n = 0; n < list.Count; n++)
			{
				// Castolni kell
				int i = (int)list[n];
				Console.WriteLine("Value: {0}", i);
			}
		}
		static void WithGenerics()
		{
			List<int> list = new List<int>();
			list.Add(1);
			list.Add(2);
			list.Add(3);
			for (int n = 0; n < list.Count; n++)
			{
				int i = list[n];
				Console.WriteLine("Value: {0}", i);
			}
		}

		private static void DelegateDemo()
		{
			List<int> list = new List<int>();
			list.Add(1);
			list.Add(2);
			list.Add(3);
			list = list.FindAll(MyFilter);
			for (int n = 0; n < list.Count; n++)
			{
				int i = list[n];
				Console.WriteLine("Value: {0}", i);
			}
		}

		static bool MyFilter(int i)
		{
			if (i % 2 == 1)
				return true;
			else
				return false;
		}
	}
}
