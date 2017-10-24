namespace GeneticProgramming
{
	public class Divide : Symbol
	{
		public override double evaluate()
		{
			if(children[1].evaluate() == 0)
				return 0;
			
			return children[0].evaluate() / children[1].evaluate();
		}
		
		public override Symbol create()
		{
			return new Divide();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "div ";
		}
	}
}
