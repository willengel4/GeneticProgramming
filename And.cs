namespace GeneticProgramming
{
	public class And : Symbol
	{
        public override double evaluate() 
		{
			bool result = true;
			foreach(Symbol s in children)
				result = result && Helper.interpret(s.evaluate());
			return Helper.interpret(result);
		}
		
		public override Symbol create()
		{
			return new And();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "and ";
		}
    }
}

