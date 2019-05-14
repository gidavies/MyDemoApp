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

        public void SendMessage(MessagingModel model, TelemetryClient telemetry)
        {
            var telemetryDetails = "Message sent to ";
            telemetryDetails += model.SBIsQueue ? "queue: " + model.SBQueue : "topic: " + model.SBTopic;
            telemetry.TrackEvent(telemetryDetails);
            
            _ =  model.SBIsQueue ? SendMessageToQueue(model) : SendMessageToTopic(model);
        }

        private async Task SendMessageToQueue(MessagingModel model)
        {
            IQueueClient queueClient = new QueueClient(model.SBConnString, model.SBQueue);
            var message = new Message(Encoding.UTF8.GetBytes(model.SBMessage));
            await queueClient.SendAsync(message);
        }

        private async Task SendMessageToTopic(MessagingModel model)
        {
            ITopicClient topicClient = new TopicClient(model.SBConnString, model.SBTopic);
            var message = new Message(Encoding.UTF8.GetBytes(model.SBMessage));
            await topicClient.SendAsync(message);
        }
    }
}
