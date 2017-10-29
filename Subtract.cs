namespace GeneticProgramming
{
	public class Subtract : NumericalSymbol
	{
        public Subtract()
        {
        }

        public override double Evaluate()
		{
			return Children[0].Evaluate() - Children[1].Evaluate();
		}
		
		public override Symbol Create()
		{
			return new Subtract();
		}
		
		public override int GetMinChildren()
		{
			return 2;
		}
		
		public override string GetSymbol()
		{
			return "sub ";
		}
    }
}