namespace Bloom
{
    class Filter
    {
		private int m;
        private int n = 10000;
		private int l;
		private double p = 0.01;
		private int[] array;
		private int[] a;
		private int[] b;

		public Filter()
		{
			Random r = new Random();
			m = (int)(-n * Math.Log(p) / Math.Pow(Math.Log(2), 2));
			l = (int)(-Math.Log(p) / Math.Log(2));
			array = new int[m];
			for (int i = 0; i < m; i++)
				array[i] = 0;

			a = new int[l];
			b = new int[l];

			for (int i = 0; i < l; i++)
			{
				a[i] = r.Next(1, m);
				b[i] = r.Next(m);
			}
		}

		public long summ_string(string str)
		{
			int p_ = 123;
			int m_ = 1000000123;
			long res = 0;
			for (int i = 0; i < str.Length; i++)
				res += ((char)str[i] * (long)Math.Pow(p_, i))%m_;
			return res % m_;
		}

		public void Insert(string str)
		{
			long lth = summ_string(str);
			for (int i = 0; i < l; i++)
			{
				long temp = ((a[i] * lth)%m + b[i]) % m;
				array[temp] = 1;
			}
		}

		public bool Check(string str)
		{
			long lth = summ_string(str);
			for (int i = 0; i < l; i++)
			{
				long temp = ((a[i] * lth)%m + b[i]) % m;
				if (array[temp] == 0) return false;
			}
			return true;
		}

		public void Remove(string str)
		{
			long lth = summ_string(str);
			for (int i = 0; i < l; i++)
			{
				long temp = ((a[i] * lth) % m + b[i]) % m;
				array[temp] = 0;
			}
		}
	}

    public class Program
    {
    static void Main(string[] args)
        {
            Filter bloom = new Filter();
            string str;
            bool contin = true;
            while (contin)
            {
                str = Console.ReadLine();
                string[] s = str.Split(" ");
                switch (s[0])
                {
                    case ("+"):
                        bloom.Insert(s[1]);
                        break;
                    case ("-"):
                        bloom.Remove(s[1]);
                        break;
                    case ("?"):
                        bool cond = bloom.Check(s[1]);

                        if (cond)
                            Console.WriteLine(s[1] + ": YES");
                        else
                            Console.WriteLine(s[1] + ": NO");
                        break;
                    case ("#"):
                        Console.WriteLine("END OF FILE");
                        contin=false;
                        break;
                    default:
                        Console.WriteLine("WRONG OPERATION");
                        break;
                }
            }
        }
    }
}
