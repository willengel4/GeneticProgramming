namespace GeneticProgramming
{
    public abstract class LogicalSymbol : Symbol
    {
        public override Terminal CreateEphemeral()
        {
            return new Terminal(Helper.Interpret(Helper.random.Next(2) > 0));
        }
    }
}