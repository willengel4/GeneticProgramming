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
		
		public override double Evaluate()
		{
			return evaluator.GetVariableValue(variableId);
		}
		
		public override Symbol Create()
		{
			return new Variable(Value, variableId, evaluator);
		}
		
		public override string GetSymbol()
		{
			return variableId + "";
		}

		public string VariableId { get => variableId; set => variableId = value; }
	}
}