namespace GeneticProgramming
{
	public class Add : Symbol
	{
		public override double Evaluate() 
		{
			double sum = 0.0;
			foreach(Symbol s in Children)
				sum += s.Evaluate();		
			return sum;
		}
		
		public override Symbol Create()
		{
			return new Add();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "add ";
		}
	}
}