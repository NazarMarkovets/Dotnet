namespace Lib.Patterns.Builder
{
    public abstract class AstractBuilder
    {
        public abstract void AddFirstPart(string firstPart);
        public abstract void AddLastPart(string lastPart);
        public abstract Product ReturnAllProducts();
    }
}