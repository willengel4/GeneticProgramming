namespace GeneticProgramming
{
	public class Not : Symbol
	{
		public override double evaluate() 
		{
			return Helper.interpret(!Helper.interpret(children[0].evaluate()));
		}

		public override Symbol create() 
		{
			return new Not();
		}

		public override int getMinChildren() 
		{
			return 1;
		}

		public override string getSymbol() 
		{
			return "not ";
		}
	}
}

