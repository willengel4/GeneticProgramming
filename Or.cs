namespace GeneticProgramming
{
	public class Or : LogicalSymbol
	{
		public override double Evaluate() 
		{
			bool result = false;
			foreach(Symbol s in Children)
				result = result || Helper.Interpret(s.Evaluate());
			return Helper.Interpret(result);
		}
		
		public override Symbol Create()
		{
			return new Or();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "or ";
		}
	}
}