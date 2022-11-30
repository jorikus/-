using System;

namespace ConsoleApp3
{
	class Abiturient
	{
		public Abiturient(string se, string ne, string oc, string adr, int[] o)
		{
			surname = se;
			name = ne;
			otec = oc;
			adress = adr;
			ocen = o;
		}
		string surname;
		string name;
		string otec;
		string adress;
		int[] ocen;

		string O(int[] array)
		{
			string res = "";
			for (int i = 0; i < array.Length; i++)
			{
				res += $"{Convert.ToString(array[i])} ";
			}
			return res;
		}
		public bool udovl()
		{
			int[] massiv = ocen;
			for (int i = 0; i < massiv.Length; i++)
			{
				if (massiv[i] <= 2)
				{
					return false;
				}
			}
			return true;
		}
		public bool summ(int sum)
		{
			int[] massiv = ocen;
			int main_sum = 0;
			for (int i = 0; i < massiv.Length; i++)
			{
				main_sum += massiv[i];
			}

			if (sum >= main_sum)
			{
				return true;
			}
			return false;
		}

		public int return_summ()
		{
			int[] massiv = ocen;
			int main_sum = 0;
			for (int i = 0; i < massiv.Length; i++)
			{
				main_sum += massiv[i];
			}
			return main_sum;
		}

		public string print()
		{
			return String.Format($"Фамилия: {surname}\nИмя: {name}\nОтчество: {otec}\nАдресс: {adress}\nОценки: {O(ocen)}");

		}
	}
	class Program
	{
		static Abiturient[] Sort(Abiturient[] array)
		{
			int len = array.Length;
			for (int i = 1; i < len; i++)
			{
				for (int j = 0; j < len - i; j++)
				{
					if (array[j].return_summ() < array[j + 1].return_summ())
					{
						Abiturient temp = array[j + 1];
						array[i] = array[j];
						array[j] = temp;

					}
				}
			}
			return array;
		}

		static void Main(string[] args)
		{
			Random rnd = new Random();

			string[] array1 = new string[4] { "Окулов", "Акулов", "Брехин", "Брёхин" };
			string[] array2 = new string[4] { "Максим", "Олег", "Рюрик", "Умер" };
			string[] array3 = new string[4] { "Акулович", "Кабанович", "Окулович", "Егорович" };
			string[] array4 = new string[4] { "Ул. Юности 11", "Ул. Юности 12", "Ул. Юности 13", "Ул. Юности 14" };

			int n = 10;
			Abiturient[] array = new Abiturient[n];

			for (int i = 0; i < n; i++)
			{
				string f = array1[rnd.Next(0, 4)];
				string i1 = array2[rnd.Next(0, 4)];
				string otc = array3[rnd.Next(0, 4)];
				string ad = array4[rnd.Next(0, 4)];
				int[] mark = new int[4] { rnd.Next(1, 6), rnd.Next(1, 6), rnd.Next(1, 6), rnd.Next(1, 6) };
				Abiturient a = new Abiturient(f, i1, otc, ad, mark);
				array[i] = a;
			}
			for (int i = 0; i < n; i++)
			{
				Console.Write(array[i].print());
				Console.Write($"\nСумма балов: {array[i].return_summ()}");
				Console.Write("\n\n");
			}

			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("Список абитуриентов, имеющих неудовлетворительные оценки");
			for (int i = 0; i < n; i++)
			{
				if (!array[i].udovl())
				{
					Console.Write(array[i].print());
					Console.Write($"\nСумма балов: {array[i].return_summ()}");
					Console.Write("\n\n");
				}
			}

			Console.WriteLine("----------------------------------------------");
			Console.Write("Введите сумму баллов: ");
			int sum = int.Parse(Console.ReadLine());
			Console.WriteLine("Список абитуриентов, сумма баллов у которых не меньше заданной");
			for (int i = 0; i < n; i++)
			{
				if (!array[i].summ(sum))
				{
					Console.Write(array[i].print());
					Console.Write($"\nСумма балов: {array[i].return_summ()}");
					Console.Write("\n\n");
				}
			}

			Console.WriteLine("----------------------------------------------");
			Console.Write("Введите кол-во: ");
			int N = int.Parse(Console.ReadLine());
			array = Sort(array);
			int pp_sum = 0;
			for (int i = 0; i < N; i++)
            {
				Console.Write(array[i].print());
				Console.Write($"\nСумма балов: {array[i].return_summ()}");
				Console.Write("\n\n");
				pp_sum = array[i].return_summ();
			}

			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("Cписок абитуриентов, имеющих полупроходной балл");
			int k = 0;
			for (int i = 0; i < n; i++)
            {
				if (array[i].return_summ() == pp_sum)
                {
					k++;
				}
            }

			if (k > 1)
            {
				for (int i = 0; i < n; i++)
				{
					if (array[i].return_summ() == pp_sum)
                    {
						Console.Write(array[i].print());
						Console.Write($"\nСумма балов: {array[i].return_summ()}");
						Console.Write("\n\n");
					}
				}
			}
		}
	}
}