namespace GeneticProgramming
{
	public class Max : Symbol
	{
		public override double Evaluate() 
		{
			double max = Children.Count > 0 ? Children[0].Evaluate() : 0;
			for(int i = 0; i < Children.Count; i++)
				if(Children[i].Evaluate() > max)
					max = Children[i].Evaluate();
			return max;
		}
		
		public override Symbol Create()
		{
			return new Max();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "max ";
		}
	}

}
