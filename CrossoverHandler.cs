namespace GeneticProgramming
{
	public class CrossoverHandler 
	{
		private Expression parent1, parent2;
		private Expression offspring1, offspring2;
		
		public CrossoverHandler(Expression parent1, Expression parent2)
		{
			this.parent1 = parent1;
			this.parent2 = parent2;
		}
		
		public void performCrossover()
		{
			offspring1 = this.parent1.copy();
			offspring2 = this.parent2.copy();
			
			int crossoverPoint1 = Helper.random.Next(this.parent1.getNumSymbols());
			int crossoverPoint2 = Helper.random.Next(this.parent2.getNumSymbols());
			
			Symbol subtree1 = offspring1.findSymbolWithId(offspring1.getRoot(), crossoverPoint1);
			Symbol subtree2 = offspring2.findSymbolWithId(offspring2.getRoot(), crossoverPoint2);
			
			Symbol parent1 = subtree1.getParent();
			Symbol parent2 = subtree2.getParent();
			
			if(parent1 == null && parent2 == null)
			{
			}
			else if(parent1 == null)
			{			
				offspring1.setRoot(subtree2);
				
				int subtree2Index = -1;
				for(int i = 0; i < parent2.getChildren().Count; i++)
					if(parent2.getChildren()[i] == subtree2)
						subtree2Index = i;
				parent2.getChildren()[subtree2Index] =  subtree1;
			}
			else if(parent2 == null)
			{
				offspring2.setRoot(subtree1);
				
				int subtree1Index = -1;
				for(int i = 0; i < parent1.getChildren().Count; i++)
					if(parent1.getChildren()[i] == subtree1)
						subtree1Index = i;
				parent1.getChildren()[subtree1Index] = subtree2;
			}
			else
			{
				
				int subtree1Index = -1;
				for(int i = 0; i < parent1.getChildren().Count; i++)
					if(parent1.getChildren()[i] == subtree1)
						subtree1Index = i;
				
				int subtree2Index = -1;
				for(int i = 0; i < parent2.getChildren().Count; i++)
					if(parent2.getChildren()[i] == subtree2)
						subtree2Index = i;
				
				parent1.getChildren()[subtree1Index] = subtree2;
				parent2.getChildren()[subtree2Index] = subtree1;
			}
			
			offspring1.synchIds();
			offspring2.synchIds();
		}
		
		public Expression getParent1()
		{
			return parent1;
		}
		
		public Expression getParent2()
		{
			return parent2;
		}
		
		public Expression getOffspring1()
		{
			return offspring1;
		}
		
		public Expression getOffspring2()
		{
			return offspring2;
		}
	}
}
