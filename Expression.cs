using System.Collections.Generic;

namespace GeneticProgramming
{
	public class Expression 
	{
		private Symbol root;
		private int numSymbols;

        public Expression(Symbol root, int numSymbols)
		{
			this.Root = root;
			this.NumSymbols = numSymbols;
		}
		
		private void IterateAndCount(Symbol node)
		{
			node.Id = NumSymbols++;
			foreach(Symbol c in node.Children)
				IterateAndCount(c);
		}
		
		public void SynchIds()
		{
			NumSymbols = 0;
			IterateAndCount(Root);
		}
		
		public Expression Copy()
		{
			Symbol copyRoot = Root.Copy();
			return new Expression(copyRoot, NumSymbols);
		}
		
		public Symbol FindSymbolWithId(Symbol r, int id)
		{
			if(r.Id == id)
				return r;
			
			if(r.Children.Count > 0)
			{
				foreach(Symbol s in r.Children)
				{
					Symbol searchResult = FindSymbolWithId(s, id);
					
					if(searchResult != null)
						return searchResult;
				}
			}
			
			return null;
		}

		public Symbol Root { get => root; set => root = value; }
        public int NumSymbols { get => numSymbols; set => numSymbols = value; }
    }
}
