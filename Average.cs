namespace GeneticProgramming
{
	public class Average : NumericalSymbol
	{
		public override double Evaluate() 
		{
			double sum = 0;

			foreach(Symbol s in Children)
				sum += s.Evaluate();

			return sum / Children.Count;
		}
		
		public override Symbol Create()
		{
			return new Average();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "avg ";
		}
	}
}

