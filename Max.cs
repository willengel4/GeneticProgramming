namespace GeneticProgramming
{
	public class Max : Symbol
	{
		public override double evaluate() 
		{
			double max = children.Count > 0 ? children[0].evaluate() : 0;
			for(int i = 0; i < children.Count; i++)
				if(children[i].evaluate() > max)
					max = children[i].evaluate();
			return max;
		}
		
		public override Symbol create()
		{
			return new Max();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "max ";
		}
	}

}
