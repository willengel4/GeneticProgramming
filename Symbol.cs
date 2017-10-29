using System.Collections.Generic;

namespace GeneticProgramming
{
	public abstract class Symbol 
	{
        private List<Symbol> children;
        private int id;
        private Symbol parent;

        public Symbol()
		{
			Children = new List<Symbol>();
			Parent = null;
		}
		
		public abstract double Evaluate();
		public abstract Symbol Create();
		public abstract int GetMinChildren();
		public abstract string GetSymbol();
		public abstract Terminal CreateEphemeral();

		public Symbol Copy()
		{
			Symbol cpy = Create();
			cpy.Id = id;
			
			for(int i = 0; i < Children.Count; i++)
			{
				Symbol newChild = Children[i].Copy();
				cpy.Children.Add(newChild);
				newChild.Parent = cpy;
			}
			
			return cpy;
		}
		
		public string GetExpression()
		{
			string expression = GetSymbol();
			if(Children.Count > 0)
			{
				expression = "(" + expression;
				for(int i = 0; i < Children.Count; i++)
				{
					expression += Children[i].GetExpression();
					
					if(i != Children.Count - 1)
						expression += " ";
				}
				expression = expression + ")";
			}
			
			return expression;
		}

		public void ReplaceChild(Symbol prevChild, Symbol newChild)
		{
			int subtreeIndex = -1;
			for(int i = 0; i < Children.Count; i++)
				if(Children[i] == prevChild)
					subtreeIndex = i;
			Children[subtreeIndex] = newChild;
		}

		public Symbol FindSymbolWithId(int searchId)
		{
			if(this.id == searchId)
				return this;
			
			foreach(Symbol s in children)
			{
				Symbol searchResult = s.FindSymbolWithId(searchId);
				if(searchResult != null)
					return searchResult;
			}
			
			return null;
		}

		public List<Symbol> Children { get => children; set => children = value; }
        public int Id { get => id; set => id = value; }
        public Symbol Parent { get => parent; set => parent = value; }
    }
}