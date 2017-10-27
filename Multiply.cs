namespace GeneticProgramming
{
	public class Multiply : Symbol
	{
		public override double Evaluate() 
		{
			double product = 1.0;
			foreach(Symbol s in Children)
				product *= s.Evaluate();
			return product;
		}
		
		public override Symbol Create()
		{
			return new Multiply();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "mult ";
		}
	}
}