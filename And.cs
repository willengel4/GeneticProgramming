namespace GeneticProgramming
{
	public class And : LogicalSymbol
	{
        public override double Evaluate() 
		{
			bool result = true;
			foreach(Symbol s in Children)
				result = result && Helper.Interpret(s.Evaluate());
			return Helper.Interpret(result);
		}
		
		public override Symbol Create()
		{
			return new And();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "and ";
		}
    }
}

