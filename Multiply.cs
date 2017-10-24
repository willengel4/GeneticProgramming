namespace GeneticProgramming
{
	public class Multiply : Symbol
	{
		public override double evaluate() 
		{
			double product = 1.0;
			foreach(Symbol s in children)
				product *= s.evaluate();
			return product;
		}
		
		public override Symbol create()
		{
			return new Multiply();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "mult ";
		}
	}
}

