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
		
		public override double evaluate() 
		{
			int maxIndex = 0;
			
			for(int i = 0; i < children.Count; i++)
				if(children[i].evaluate() > children[maxIndex].evaluate())
					maxIndex = i;
			
			return maxIndex;
		}

		public override Symbol create() 
		{
			return new Decision(numOptions);
		}

		public override int getMinChildren() 
		{
			return numOptions;
		}

		public override string getSymbol() 
		{
			return "decide ";
		}

	}
}
