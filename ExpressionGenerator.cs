using System.Collections.Generic;

namespace GeneticProgramming
{
	public class ExpressionGenerator 
	{
		private List<Symbol> functionSet;
		private List<Terminal> terminalSet;
		private List<Symbol> combinedSet;
		private int maxDepth;

        public ExpressionGenerator()
		{
			functionSet = new List<Symbol>();
			terminalSet = new List<Terminal>();
			combinedSet = new List<Symbol>();
			maxDepth = 4;
		}
		
		public Expression GenerateSymbolicExpression(Symbol specificRoot)
		{
			Create(specificRoot, 1);
			Expression exp = new Expression(specificRoot);
			return exp;
		}

		public Expression GenerateDecisionMaker(int numDecisions)
		{
			Decision d = new Decision(numDecisions);

			for(int i = 0; i < numDecisions; i++)
				d.Children.Add(new PlaceHolder());

			foreach(PlaceHolder ph in d.Children)
				Create(ph, 3);
			
			Expression exp = new Expression(d);
			return exp;
		}
		
		public Expression GenerateSymbolicExpression()
		{
			return GenerateSymbolicExpression(functionSet[Helper.random.Next(functionSet.Count)].Create());
		}
		
		public void Create(Symbol r, int depth)
		{
			if(r.GetType() == typeof(Terminal) || depth > maxDepth)
				return;

			for(int i = 0; i < r.GetMinChildren(); i++)
			{
				Symbol newSymbol = ChooseASymbol(r, depth);
				newSymbol.Parent = r;
				r.Children.Add(newSymbol);
				Create(newSymbol, depth + 1);
			}
		}

		private Symbol ChooseASymbol(Symbol r, int depth)
		{
			if(depth == maxDepth)
			{
				int randomIndex = Helper.random.Next(terminalSet.Count + 1);
				Symbol newSymbol = randomIndex < terminalSet.Count ? terminalSet[randomIndex].Create() : r.CreateEphemeral();
				return newSymbol;
			}
			else
			{
				int randomIndex = Helper.random.Next(combinedSet.Count + 1);
				Symbol newSymbol = randomIndex < combinedSet.Count ? combinedSet[randomIndex].Create() : r.CreateEphemeral();
				return newSymbol;
			}		
		}

		public void AddFunction(Symbol f)
		{
			functionSet.Add(f);
			SynchCombinedSet();
		}

		public void AddTerminal(Terminal t)
		{
			terminalSet.Add(t);
			SynchCombinedSet();
		}

		public void SynchCombinedSet()
		{
			combinedSet.Clear();
			foreach(Symbol s in functionSet)
				combinedSet.Add(s);
			foreach(Terminal t in terminalSet)
				combinedSet.Add(t);
		}

        public int MaxDepth { get => maxDepth; set => maxDepth = value; }
	}
}