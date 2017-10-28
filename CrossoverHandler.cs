namespace GeneticProgramming
{
	public class CrossoverHandler 
	{
		private Expression parent1;
		private Expression parent2;
		private Expression offspring1;
		private Expression offspring2;

        public CrossoverHandler(Expression parent1, Expression parent2)
		{
			this.Parent1 = parent1;
			this.Parent2 = parent2;
		}

		public void PerformCrossover()
		{
			Offspring1 = this.Parent1.Copy();
			Offspring2 = this.Parent2.Copy();
			
			int crossoverPoint1 = Helper.random.Next(this.Parent1.NumSymbols);
			int crossoverPoint2 = Helper.random.Next(this.Parent2.NumSymbols);
			
			Symbol subtree1 = Offspring1.Root.FindSymbolWithId(crossoverPoint1);
			Symbol subtree2 = Offspring2.Root.FindSymbolWithId(crossoverPoint2);
			
			Symbol parent1 = subtree1.Parent;
			Symbol parent2 = subtree2.Parent;
			
			if(parent1 == null && parent2 == null) { }
			else if(parent1 == null)
			{
				Offspring1.Root = subtree2;
				parent2.ReplaceChild(subtree2, subtree1);
			}
			else if(parent2 == null)
			{
				Offspring2.Root = subtree1;
				parent1.ReplaceChild(subtree1, subtree2);
			}
			else
			{
				parent1.ReplaceChild(subtree1, subtree2);
				parent2.ReplaceChild(subtree2, subtree1);
			}
			
			Offspring1.SynchIds();
			Offspring2.SynchIds();
		}

		public Expression Parent1 { get => parent1; set => parent1 = value; }
        public Expression Parent2 { get => parent2; set => parent2 = value; }
        public Expression Offspring1 { get => offspring1; set => offspring1 = value; }
        public Expression Offspring2 { get => offspring2; set => offspring2 = value; }
	}
}