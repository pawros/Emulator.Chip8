using System;

namespace Emulator.Chip8.Events
{
    interface IPublisher
    {
        event EventHandler<EventArgs> EventPublisher;
        void Publish(EventArgs args);
    }
}