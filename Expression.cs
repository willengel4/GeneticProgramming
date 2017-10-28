using System.Collections.Generic;

namespace GeneticProgramming
{
	public class Expression 
	{
		private Symbol root;
		private int numSymbols;

        public Expression(Symbol root)
		{
			this.Root = root;
			this.NumSymbols = numSymbols;
			SynchIds();
		}
		
		public void SynchIds()
		{
			numSymbols = 0;
			Queue<Symbol> searchQueue = new Queue<Symbol>();
			searchQueue.Enqueue(root);
			Symbol currSymbol;

			while(searchQueue.TryDequeue(out currSymbol))
			{
				currSymbol.Id = numSymbols++;
				foreach(Symbol s in currSymbol.Children)
					searchQueue.Enqueue(s);
			}
		}
		
		public Expression Copy()
		{
			return new Expression(Root.Copy());
		}

		public Symbol Root { get => root; set => root = value; }
        public int NumSymbols { get => numSymbols; set => numSymbols = value; }
    }
}