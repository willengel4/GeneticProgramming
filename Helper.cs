using System;

namespace GeneticProgramming
{
	public class Helper 
	{
		public static bool Interpret(double d)
		{
			return d > 0;
		}
		
		public static double Interpret(bool b)
		{
			if(b)
				return 1.0;
			else
				return -1.0;
		}
		
		public static Random random = new Random();
	}
}

