using System;
using System.Threading.Tasks;
using Nml.Refactor.Me.Dependencies;
using Nml.Refactor.Me.MessageBuilders;

namespace Nml.Refactor.Me.Notifiers
{
	public class SmsNotifier : BaseNotifier<string>, INotifier
	{
		private readonly ILogger _logger = LogManager.For<SmsNotifier>();

		public SmsNotifier(IMessageBuilder<string> messageBuilder, IOptions options)
			: base(messageBuilder, options)
		{
		}
		
		public override async Task Notify(NotificationMessage message)
		{
			var smsApiClient = new SmsApiClient(_options.Sms.ApiUri, _options.Sms.ApiKey);
			var smsMessage = _messageBuilder.CreateMessage(message);

			try
			{
				// not sure which variable is the mobile number, so I just put the message.From
				await smsApiClient.SendAsync(message.From, smsMessage);
				_logger.LogTrace($"SMS sent.");
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Failed to send SMS. {e.Message}");
				throw;
			}
		}
	}
}
