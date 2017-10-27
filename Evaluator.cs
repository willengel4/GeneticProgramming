namespace GeneticProgramming
{
	public abstract class Evaluator 
	{
		public abstract double Evaluate(Expression e);
		public abstract double GetVariableValue(string variableId);
	}
}