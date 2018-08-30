using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Emulator.Chip8.Gui.ViewModels
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null)
            {
                return properties.TryGetValue(propertyName, out var value) ? (T) value : default(T);
            }

            return default(T);
        }

        protected void Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (propertyName != null)
            {
                if (!properties.TryGetValue(propertyName, out object existingValue) || existingValue != (object) value)
                {
                    properties[propertyName] = value;
                    RaisePropertyChangedEvent(propertyName);
                }
            }
        }
    }
}