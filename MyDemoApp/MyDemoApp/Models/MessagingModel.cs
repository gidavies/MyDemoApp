using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.ServiceBus;

namespace MyDemoApp.Web.Models
{
    public class MessagingModel
    {
        public string SBConnString { get; set; }
        public string SBQueue { get; set; }
        public string SBTopic { get; set; }
        public string SBMessage { get; set; }
        public bool SBIsQueue { get; set; }
        public TelemetryClient telemetryClient { get; set; }

        public void SendMessage()
        {
            if (telemetryClient != null)
            {
                var properties = SBIsQueue ? new Dictionary <string, string> {{"type", "queue"}, {"name", SBQueue}} : new Dictionary <string, string> {{"type", "topic"}, {"name", SBTopic}};
                telemetryClient.TrackEvent("Messages", properties);
            }
            
            _ =  this.SBIsQueue ? SendMessageToQueue() : SendMessageToTopic();
        }

        private async Task SendMessageToQueue()
        {
            IQueueClient queueClient = new QueueClient(SBConnString, SBQueue);
            var message = new Message(Encoding.UTF8.GetBytes(SBMessage));
            await queueClient.SendAsync(message);
        }

        private async Task SendMessageToTopic()
        {
            ITopicClient topicClient = new TopicClient(SBConnString, SBTopic);
            var message = new Message(Encoding.UTF8.GetBytes(SBMessage));
            await topicClient.SendAsync(message);
        }
    }
}
