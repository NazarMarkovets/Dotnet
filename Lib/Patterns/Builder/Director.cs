namespace Lib.Patterns.Builder
{
    public class Director
    {
        private string _firstPart;
        private string _lastPart;

        public Director(string firstPart, string lastPart)
        {
            _firstPart = firstPart;
            _lastPart = lastPart;
        }

        public void ChangeParts(string newFirstPart, string newLastPart)
        {
            _firstPart = newFirstPart;
            _lastPart = newLastPart;
        }

        public void Construct(AstractBuilder builder)
        {
            builder.AddFirstPart(_firstPart);
            builder.AddLastPart(_lastPart);
        }
    }
}