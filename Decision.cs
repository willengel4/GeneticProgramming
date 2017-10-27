namespace GeneticProgramming
{
	public class Decision : Symbol
	{
		private int numOptions;
		
		public Decision(int numOptions)
			: base()
		{
			this.numOptions = numOptions;
		}
		
		public override double Evaluate() 
		{
			int maxIndex = 0;
			
			for(int i = 0; i < Children.Count; i++)
				if(Children[i].Evaluate() > Children[maxIndex].Evaluate())
					maxIndex = i;
			
			return maxIndex;
		}

		public override Symbol Create() 
		{
			return new Decision(numOptions);
		}

		public override int GetMinChildren() 
		{
			return numOptions;
		}

		public override string GetSymbol() 
		{
			return "decide ";
		}
	}
}
