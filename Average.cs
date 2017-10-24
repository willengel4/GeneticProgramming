namespace GeneticProgramming
{
	public class Average : Add
	{
		public override double evaluate() 
		{
			return base.evaluate() / children.Count;
		}
		
		public override Symbol create()
		{
			return new Average();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "avg ";
		}
	}
}

