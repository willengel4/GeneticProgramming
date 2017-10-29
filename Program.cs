using System;

namespace GeneticProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleEvaluator evaluator = new ExampleEvaluator();

            Variable x1 = new Variable(4, "x1", evaluator);
            Variable x2 = new Variable(10, "x2", evaluator);
                    
            ExpressionGenerator generator = new ExpressionGenerator();
            generator.MaxDepth = 5;
            generator.AddFunction(new Add()); 
            generator.AddFunction(new Multiply());
            generator.AddFunction(new Average());
            generator.AddFunction(new Decision(4));
            generator.AddFunction(new Max());

            generator.AddTerminal(x1);
            generator.AddTerminal(x2);
            
            Genome bestGenome = null;
            Population currentPopulation = new Population(evaluator, generator, 100);

            for(int i = 0; i < 100; i++)
            {
                Population next = currentPopulation.CreateNextGeneration();

                if(bestGenome == null || currentPopulation.PopulationBest.Fitness > bestGenome.Fitness)
                    bestGenome = currentPopulation.PopulationBest;
                
                Console.WriteLine("Best Fitness: " + bestGenome.Fitness);
                
                currentPopulation = next;
            }
            
            Console.WriteLine(bestGenome.Expression.Root.GetExpression());
            Console.WriteLine("Best Error: " + evaluator.Evaluate(bestGenome.Expression));
        }
    }
}