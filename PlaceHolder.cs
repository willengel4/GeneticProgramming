namespace GeneticProgramming
{
    class PlaceHolder : NumericalSymbol
    {
        public override Symbol Create()
        {
            return new PlaceHolder();
        }

        public override double Evaluate()
        {
            return Children[0].Evaluate();
        }

        public override int GetMinChildren()
        {
            return 1;
        }

        public override string GetSymbol()
        {
            return "ph ";
        }
    }
}