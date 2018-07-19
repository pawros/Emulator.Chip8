using System;

namespace Emulator.Chip8.Events
{
    public class Publisher : IPublisher
    {
        public event EventHandler<EventArgs> EventPublisher;

        public void Publish(EventArgs args)
        {
            var handler = EventPublisher;
            handler?.Invoke(this, args);
        }
    }
}