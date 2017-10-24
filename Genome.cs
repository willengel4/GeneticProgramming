namespace GeneticProgramming
{
	public class Genome
	{
		private Expression expression;
		private double fitness;
		
		public Genome(Expression e)
		{
			expression = e;
			fitness = 0.0;
		}
		
		public void setFitness(double f)
		{
			fitness = f;
		}
		
		public double getFitness()
		{
			return fitness;
		}
		
		public Expression getExpression()
		{
			return expression;
		}
		
		public Genome copy()
		{
			return new Genome(expression.copy());
		}
	}
}
