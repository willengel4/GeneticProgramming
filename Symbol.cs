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

		public List<Symbol> Children { get => children; set => children = value; }
        public int Id { get => id; set => id = value; }
        public Symbol Parent { get => parent; set => parent = value; }
    }
}