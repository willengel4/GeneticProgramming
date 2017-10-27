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
            generator.setMaxDepth(5);
            generator.addToFunctionSet(new Add());
            generator.addToFunctionSet(new Multiply());
            generator.addToFunctionSet(new Average());
            generator.addToFunctionSet(new Decision(4));
            generator.addToFunctionSet(new Max());

            generator.addToTerminalSet(x1);
            generator.addToTerminalSet(x2);
            
            
            Genome bestGenome = null;
            Population currentPopulation = new Population(evaluator, generator, 50);
        
            for(int i = 0; i < 20; i++)
            {
                Population next = currentPopulation.createNextGeneration();

                if(bestGenome == null || currentPopulation.getBestGenome().getFitness() > bestGenome.getFitness())
                    bestGenome = currentPopulation.getBestGenome();
                
                Console.WriteLine("Best Fitness: " + bestGenome.getFitness());
                
                currentPopulation = next;
            }
            
            Console.WriteLine(bestGenome.getExpression().getRoot().getExpression());
            Console.WriteLine("Best Error: " + evaluator.evaluate(bestGenome.getExpression()));
        }
    }
}
