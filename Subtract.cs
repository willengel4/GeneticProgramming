namespace GeneticProgramming
{
	public class Subtract : Symbol
	{
        public Subtract()
        {
        }

        public override double evaluate()
		{
			return children[0].evaluate() - children[1].evaluate();
		}
		
		public override Symbol create()
		{
			return new Subtract();
		}
		
		public override int getMinChildren()
		{
			return 2;
		}
		
		public override string getSymbol()
		{
			return "sub ";
		}
    }
}