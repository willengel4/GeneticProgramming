namespace GeneticProgramming
{
	public class Or : Symbol
	{
		public override double evaluate() 
		{
			bool result = false;
			foreach(Symbol s in children)
				result = result || Helper.interpret(s.evaluate());
			return Helper.interpret(result);
		}
		
		public override Symbol create()
		{
			return new Or();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "or ";
		}
	}
}

