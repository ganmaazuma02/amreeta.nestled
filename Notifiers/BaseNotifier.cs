using Nml.Refactor.Me.Dependencies;
using Nml.Refactor.Me.MessageBuilders;
using System;
using System.Threading.Tasks;

namespace Nml.Refactor.Me.Notifiers
{
    public abstract class BaseNotifier<TMessageType>
    {
        protected readonly IMessageBuilder<TMessageType> _messageBuilder;
        protected readonly IOptions _options;

        public BaseNotifier(IMessageBuilder<TMessageType> messageBuilder, IOptions options)
        {
            _messageBuilder = messageBuilder ?? throw new ArgumentNullException(nameof(messageBuilder));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public abstract Task Notify(NotificationMessage message);
    }
}
