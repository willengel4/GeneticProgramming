namespace GeneticProgramming
{
	public class Variable : Terminal
	{
		private string variableId;
		private Evaluator evaluator;

		public Variable(double value, string variableId, Evaluator evaluator) 
			: base(value)
		{
			this.variableId = variableId;
			this.evaluator = evaluator;
		}

        public void setVariableId(string variableId)
		{
			this.variableId = variableId;
		}
		
		public override double evaluate()
		{
			return evaluator.getVariableValue(variableId);
		}

		public string getVariableId()
		{
			return variableId;
		}
		
		public override Symbol create()
		{
			return new Variable(getValue(), variableId, evaluator);
		}
		
		public override string getSymbol()
		{
			return variableId +"";
		}
	}
}

