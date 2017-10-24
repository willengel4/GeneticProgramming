namespace GeneticProgramming
{
	public class Add : Symbol
	{
		public override double evaluate() 
		{
			double sum = 0.0;
			foreach(Symbol s in getChildren())
				sum += s.evaluate();		
			return sum;
		}
		
		public override Symbol create()
		{
			return new Add();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "add ";
		}
	}
}

