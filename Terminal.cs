namespace GeneticProgramming
{
	public class Terminal : Symbol
	{
		private double value;
		
		public Terminal(double value)
		{
			this.value = value;
		}
		
		public override double evaluate()
		{
			return value;
		}
		
		/* Terminals should be shallow copied */
		public override Symbol create()
		{
			return new Terminal(value);
		}
		
		public override int getMinChildren()
		{
			return 0;
		}
		
		public override string getSymbol()
		{
			return value +"";
		}
		
		public void setValue(double value)
		{
			this.value = value;
		}
		
		public double getValue()
		{
			return value;
		}
	}
}
