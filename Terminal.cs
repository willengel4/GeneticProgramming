namespace GeneticProgramming
{
	public class Terminal : Symbol
	{
		private double value;

        public Terminal(double value)
		{
			this.value = value;
		}
		
		public override double Evaluate()
		{
			return value;
		}
		
		public override Symbol Create()
		{
			return new Terminal(value);
		}
		
		public override int GetMinChildren()
		{
			return 0;
		}
		
		public override string GetSymbol()
		{
			return value +"";
		}

		public override Terminal CreateEphemeral()
		{
			return null;
		}

		public double Value { get => value; set => this.value = value; }
	}
}