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
			
			Symbol subtree1 = Offspring1.FindSymbolWithId(Offspring1.Root, crossoverPoint1);
			Symbol subtree2 = Offspring2.FindSymbolWithId(Offspring2.Root, crossoverPoint2);
			
			Symbol parent1 = subtree1.Parent;
			Symbol parent2 = subtree2.Parent;
			
			if(parent1 == null && parent2 == null)
			{
			}
			else if(parent1 == null)
			{			
				Offspring1.Root = subtree2;
				
				int subtree2Index = -1;
				for(int i = 0; i < parent2.Children.Count; i++)
					if(parent2.Children[i] == subtree2)
						subtree2Index = i;
				parent2.Children[subtree2Index] =  subtree1;
			}
			else if(parent2 == null)
			{
				Offspring2.Root = subtree1;
				
				int subtree1Index = -1;
				for(int i = 0; i < parent1.Children.Count; i++)
					if(parent1.Children[i] == subtree1)
						subtree1Index = i;
				parent1.Children[subtree1Index] = subtree2;
			}
			else
			{	
				int subtree1Index = -1;
				for(int i = 0; i < parent1.Children.Count; i++)
					if(parent1.Children[i] == subtree1)
						subtree1Index = i;
				
				int subtree2Index = -1;
				for(int i = 0; i < parent2.Children.Count; i++)
					if(parent2.Children[i] == subtree2)
						subtree2Index = i;
				
				parent1.Children[subtree1Index] = subtree2;
				parent2.Children[subtree2Index] = subtree1;
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