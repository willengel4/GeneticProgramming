using System;
using System.Collections.Generic;

namespace GeneticProgramming
{
	public class ExampleEvaluator : Evaluator
	{
		private List<double> x1s;
		private List<double> x2s;
		private List<double> ys;
		private Dictionary<string, double> currentVariables;

		public ExampleEvaluator()
		{
			x1s = new List<double>();
			x2s = new List<double>();
			ys = new List<double>();
						
			x1s.Add(4);
			x2s.Add(3);
			ys.Add(19);
			
			x1s.Add(2);
			x2s.Add(3);
			ys.Add(7);
			
			x1s.Add(7);
			x2s.Add(10);
			ys.Add(59);
			
			x1s.Add(1);
			x2s.Add(10);
			ys.Add(11);

			currentVariables = new Dictionary<string, double>();
			currentVariables.Add("x1", 0.0);
			currentVariables.Add("x2", 0.0);
		}
		
		public override double Evaluate(Expression e) 
		{			
			double totalError = 0.0;
			
			for(int i = 0; i < ys.Count; i++)
			{
				currentVariables["x1"] = x1s[i];
				currentVariables["x2"] = x2s[i];

				double prediction = e.Root.Evaluate();
				double err = Math.Abs(prediction - ys[i]);
				totalError += err;
			}
			
			if(totalError > 200)
				totalError = 200;
			
			return totalError;
		}

		public override double GetVariableValue(string variableId)
		{
			return currentVariables[variableId];
		}
	}
}