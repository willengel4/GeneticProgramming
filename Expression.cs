using System.Collections.Generic;

namespace GeneticProgramming
{
	public class Expression 
	{
		private Symbol root;
		private int numSymbols;
		
		public Expression(Symbol root, int numSymbols)
		{
			this.root = root;
			this.numSymbols = numSymbols;
		}
		
		private void iterateAndCount(Symbol node)
		{
			node.setId(numSymbols++);
			foreach(Symbol c in node.getChildren())
				iterateAndCount(c);
		}
		
		public void synchIds()
		{
			numSymbols = 0;
			iterateAndCount(root);
		}
		
		public Symbol getRoot()
		{
			return root;
		}
		
		public int getNumSymbols()
		{
			return numSymbols;
		}
		
		public Expression copy()
		{
			Symbol copyRoot = root.copy();
			return new Expression(copyRoot, numSymbols);
		}
		
		public void setRoot(Symbol r)
		{
			this.root = r;
		}
		
		public Symbol findSymbolWithId(Symbol r, int id)
		{
			if(r.getId() == id)
				return r;
			
			if(r.getChildren().Count > 0)
			{
				foreach(Symbol s in r.getChildren())
				{
					Symbol searchResult = findSymbolWithId(s, id);
					
					if(searchResult != null)
						return searchResult;
				}
			}
			
			return null;
		}
	}
}
