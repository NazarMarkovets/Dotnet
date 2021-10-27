using System.Threading;
using Lib.Async.Factory;

namespace Lib.Async
{
    class Creator
    {
        private readonly MessageBuilder messageBuilder;

        public Creator(MessageBuilder messageBuilder) => this.messageBuilder = messageBuilder;

        public void CreateMessage(string name)
        {
            System.Console.WriteLine($"[CreateMessage] Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            messageBuilder.CreateInstance(name);
        }
    }
}
