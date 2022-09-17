using Newtonsoft.Json.Linq;
using Nml.Refactor.Me.Dependencies;
using Nml.Refactor.Me.MessageBuilders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Nml.Refactor.Me.Notifiers
{
    public abstract class WebhookBaseNotifier : BaseNotifier<JObject>
    {
        protected HttpClient client;
        protected WebhookBaseNotifier(IMessageBuilder<JObject> messageBuilder, IOptions options) 
            : base(messageBuilder, options)
        {
            client = new HttpClient();
        }

        protected HttpRequestMessage GenerateHttpRequestMessageForWebhook(string webhookUri)
        {
            var serviceEndPoint = new Uri(webhookUri);
            return new HttpRequestMessage(HttpMethod.Post, serviceEndPoint);
        }
    }
}
