namespace GeneticProgramming
{
	public class Average : Add
	{
		public override double Evaluate() 
		{
			return base.Evaluate() / Children.Count;
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

