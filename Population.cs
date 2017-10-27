
using System.Collections.Generic;

namespace GeneticProgramming
{
	public class Population 
	{
		private Evaluator evaluator;
		private int numGenomes;
		private ExpressionGenerator generator;
		private List<Genome> genomes;
		private int pCopy = 1;
		private int pCrossover = 9;
		private Genome populationBest;

        public Population(Evaluator evaluator, ExpressionGenerator expGen, int numGenomes)
		{
			this.evaluator = evaluator;
			this.generator = expGen;
			this.numGenomes = numGenomes;
			this.genomes = new List<Genome>();
			CreatePopulation();
		}
		
		public void CreatePopulation()
		{
			for(int i = 0; i < numGenomes; i++)
				genomes.Add(new Genome(generator.GenerateSymbolicExpression()));
		}
		
		public void EvaluatePopulation()
		{
			double maxFitness = -1;
			
			foreach(Genome g in genomes)
			{
				g.Fitness = evaluator.Evaluate(g.Expression);
				
				if(g.Fitness > maxFitness)
					maxFitness = g.Fitness;
			}
			
			foreach(Genome g in genomes)
			{
				g.Fitness = maxFitness - g.Fitness;

				if(populationBest == null || g.Fitness > populationBest.Fitness)
					populationBest = g;
			}
		}
		
		public Population CreateNextGeneration()
		{
			EvaluatePopulation();
			
			Population nextGeneration = new Population(evaluator, generator, numGenomes);
			
			for(int i = 0; i < numGenomes; i++)
			{
				int lotto = Helper.random.Next(pCopy + pCrossover);
				
				if(lotto < pCopy)
				{
					nextGeneration.Genomes.Add(SelectGenome().Copy());
				}
				else
				{
					Genome g1 = SelectGenome();
					Genome g2 = SelectGenome();
					
					CrossoverHandler crossoverHandler = new CrossoverHandler(g1.Expression, g2.Expression);
					crossoverHandler.PerformCrossover();
					
					nextGeneration.Genomes.Add(new Genome(crossoverHandler.Offspring1));
					nextGeneration.Genomes.Add(new Genome(crossoverHandler.Offspring2));

					i++;	
				}			
			}
			
			return nextGeneration;
		}
		
		private Genome SelectGenome()
		{
			double fitnessSum = 0.0;
			for(int i = 0; i < genomes.Count; i++)
				fitnessSum += genomes[i].Fitness;
			
			double lotto = Helper.random.NextDouble() * fitnessSum;
			double lo = 0.0, hi = 0.0;
					
			for(int i = 0; i < genomes.Count; i++)
			{
				hi = lo + genomes[i].Fitness;
							
				if(lotto <= hi)
					return genomes[i];
				
				lo = hi;
			}
			
			return null;
		}

		public Genome PopulationBest { get => populationBest; set => populationBest = value; }
        public List<Genome> Genomes { get => genomes; set => genomes = value; }
	}
}