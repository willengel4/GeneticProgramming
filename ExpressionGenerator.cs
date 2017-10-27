using System.Collections.Generic;

namespace GeneticProgramming
{
	public class ExpressionGenerator 
	{
		private List<Symbol> functionSet;
		private List<Terminal> terminalSet;
		private int maxDepth;

        public ExpressionGenerator()
		{
			functionSet = new List<Symbol>();
			terminalSet = new List<Terminal>();
			maxDepth = 10;
		}
		
		public Expression GenerateSymbolicExpression(Symbol specificRoot)
		{
			Create(specificRoot, 1);
			Expression exp = new Expression(specificRoot);
			return exp;
		}
		
		public Expression GenerateSymbolicExpression()
		{
			return GenerateSymbolicExpression(functionSet[Helper.random.Next(functionSet.Count)].Create());
		}
		
		public void Create(Symbol r, int depth)
		{
			for(int i = 0; i < r.GetMinChildren(); i++)
			{
				int randomIndex;
				if(depth < maxDepth)
					randomIndex = Helper.random.Next(functionSet.Count + terminalSet.Count);
				else
					randomIndex = Helper.random.Next(terminalSet.Count) + functionSet.Count;
				
				if(randomIndex < functionSet.Count && depth < maxDepth)
				{
					Symbol child = functionSet[randomIndex].Create();
					child.Parent = r;
					r.Children.Add(child);
					Create(child, depth + 1);
				}
				else
				{
					int termIndex = randomIndex - functionSet.Count;
					Terminal t = (Terminal)terminalSet[termIndex].Create();
					t.Parent = r;
					r.Children.Add(t);
				}
			}
		}

		public List<Symbol> FunctionSet { get => functionSet; set => functionSet = value; }
        public List<Terminal> TerminalSet { get => terminalSet; set => terminalSet = value; }
        public int MaxDepth { get => maxDepth; set => maxDepth = value; }
	}
}