namespace GeneticProgramming
{
	public class Min : Symbol
	{
		public override double evaluate() 
		{
			double min = children.Count > 0 ? children[0].evaluate() : 0;
			for(int i = 0; i < children.Count; i++)
				if(children[i].evaluate() < min)
					min = children[i].evaluate();
			return min;
		}
		
		public override Symbol create()
		{
			return new Min();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "min ";
		}
	}
}

