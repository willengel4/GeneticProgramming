using System.Collections.Generic;

namespace GeneticProgramming
{
	public class ExpressionGenerator 
	{
		private List<Symbol> functionSet;
		private List<Terminal> terminalSet;
		private int maxDepth;
		private int currentId;
		
		public ExpressionGenerator()
		{
			functionSet = new List<Symbol>();
			terminalSet = new List<Terminal>();
			maxDepth = 10;
			currentId = 0;
		}
		
		public Expression generateSymbolicExpression(Symbol specificRoot)
		{
			currentId = 0;
			specificRoot.setId(currentId++);
			create(specificRoot, 1);
			return new Expression(specificRoot, currentId);
		}
		
		public Expression generateSymbolicExpression()
		{
			int randomIndex = Helper.random.Next(functionSet.Count);
			Symbol root = functionSet[randomIndex].create();				
			return generateSymbolicExpression(root);
		}
		
		public void create(Symbol r, int depth)
		{
			for(int i = 0; i < r.getMinChildren(); i++)
			{
				int randomIndex;
				if(depth < maxDepth)
					randomIndex = Helper.random.Next(functionSet.Count + terminalSet.Count);
				else
					randomIndex = Helper.random.Next(terminalSet.Count) + functionSet.Count;
				
				if(randomIndex < functionSet.Count && depth < maxDepth)
				{
					Symbol child = functionSet[randomIndex].create();
					child.setId(currentId++);
					child.setParent(r);
					r.addSymbol(child);
					create(child, depth + 1);
				}
				else
				{
					int termIndex = randomIndex - functionSet.Count;
					Terminal t = (Terminal)terminalSet[termIndex].create();
					t.setParent(r);
					t.setId(currentId++);
					r.addSymbol(t);
				}
			}
		}
		
		public void addToFunctionSet(Symbol f)
		{
			functionSet.Add(f);
		}
		
		public void addToTerminalSet(Terminal t)
		{
			terminalSet.Add(t);
		}
		
		public void setMaxDepth(int m)
		{
			maxDepth = m;
		}
		
		public int getMaxDepth()
		{
			return maxDepth;
		}
		
		public int getNumSymbols()
		{
			return currentId;
		}
	}

}

