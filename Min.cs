namespace GeneticProgramming
{
	public class Min : Symbol
	{
		public override double Evaluate() 
		{
			double min = Children.Count > 0 ? Children[0].Evaluate() : 0;
			for(int i = 0; i < Children.Count; i++)
				if(Children[i].Evaluate() < min)
					min = Children[i].Evaluate();
			return min;
		}
		
		public override Symbol Create()
		{
			return new Min();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "min ";
		}
	}
}