namespace GeneticProgramming
{
    public abstract class NumericalSymbol : Symbol
    {
        public override Terminal CreateEphemeral()
        {
		    return new Terminal((Helper.random.NextDouble() * 2) - 1);
        }
    }
}