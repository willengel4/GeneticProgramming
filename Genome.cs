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

        public Genome Copy()
		{
			return new Genome(expression.Copy());
		}

		public Expression Expression { get => expression; set => expression = value; }
        public double Fitness { get => fitness; set => fitness = value; }
	}
}
