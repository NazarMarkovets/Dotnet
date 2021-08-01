namespace Lib.Patterns.Builder
{
    public class ConcreteBuilderA: AstractBuilder
    {
        private Product _product;

        public ConcreteBuilderA()
        {
            _product = new Product();
        }
        public override void AddFirstPart(string firstPart)
        {
            _product.AddToList(firstPart);
        }

        public override void AddLastPart(string lastPart)
        {
            _product.AddToList(lastPart);
        }

        public override Product ReturnAllProducts()
        {
            return _product;
        }
        
    }
}