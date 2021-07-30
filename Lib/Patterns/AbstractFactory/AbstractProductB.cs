namespace Lib.Patterns.AbstractFactory
{
    public class AbstractProductB: AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            throw new System.NotImplementedException();
        }

        public override AbstractProductB CreateProductB()
        {
            throw new System.NotImplementedException();
        }
    }
}