using System.Collections.Generic;

namespace GeneticProgramming
{
	public abstract class Symbol 
	{
		protected List<Symbol> children;
		protected int id;
		protected Symbol parent;
		
		public Symbol()
		{
			children = new List<Symbol>();
			parent = null;
		}
		
		public abstract double evaluate();
		public abstract Symbol create();
		public abstract int getMinChildren();
		public abstract string getSymbol();
		
		public List<Symbol> getChildren()
		{
			return children;
		}
		
		public Symbol copy()
		{
			Symbol cpy = create();
			cpy.setId(id);
			
			for(int i = 0; i < children.Count; i++)
			{
				Symbol newChild = children[i].copy();
				cpy.addSymbol(newChild);
				newChild.setParent(cpy);
			}
			
			return cpy;
		}
		
		public void addSymbol(Symbol s)
		{
			children.Add(s);
		}
		
		public string getExpression()
		{
			string expression = getSymbol();
			if(children.Count > 0)
			{
				expression = "(" + expression;
				for(int i = 0; i < children.Count; i++)
				{
					expression += children[i].getExpression();
					
					if(i != children.Count - 1)
						expression += " ";
				}
				expression = expression + ")";
			}
			
			return expression;
		}
		
		public void setId(int id)
		{
			this.id = id;
		}
		
		public int getId()
		{
			return id;
		}
		
		public Symbol getParent()
		{
			return parent;
		}
		
		public void setParent(Symbol p)
		{
			this.parent = p;
		}
	}
}

