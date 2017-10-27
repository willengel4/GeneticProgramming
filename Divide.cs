namespace GeneticProgramming
{
	public class Divide : Symbol
	{
		public override double Evaluate()
		{
			if(Children[1].Evaluate() == 0)
				return 0;
			
			return Children[0].Evaluate() / Children[1].Evaluate();
		}
		
		public override Symbol Create()
		{
			return new Divide();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "div ";
		}
	}
}
