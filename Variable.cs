namespace GeneticProgramming
{
	public class Variable : Terminal
	{
		private string variableId;
		
		public Variable(double value, string variableId) 
			: base(value)
		{
			this.variableId = variableId;
		}

        public Variable(double value) : base(value)
        {

        }

        public void setVariableId(string variableId)
		{
			this.variableId = variableId;
		}
		
		public string getVariableId()
		{
			return variableId;
		}
		
		public override Symbol create()
		{
			return new Variable(getValue(), variableId);
		}
		
		public override string getSymbol()
		{
			return variableId +"";
		}
	}
}

