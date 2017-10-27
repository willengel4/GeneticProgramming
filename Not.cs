namespace GeneticProgramming
{
	public class Not : Symbol
	{
		public override double Evaluate() 
		{
			return Helper.Interpret(!Helper.Interpret(Children[0].Evaluate()));
		}

		public override Symbol Create() 
		{
			return new Not();
		}

		public override int GetMinChildren() 
		{
			return 1;
		}

		public override string GetSymbol() 
		{
			return "not ";
		}
	}
}