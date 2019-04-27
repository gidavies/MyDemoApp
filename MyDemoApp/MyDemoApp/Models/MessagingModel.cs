using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace MyDemoApp.Web.Models
{
    public class MessagingModel
    {
        public string SBConnString { get; set; }
        public string SBQueue { get; set; }
        public string SBMessage { get; set; }

        public async Task SendMessageAsync(MessagingModel model)
        {
            try
            {
                IQueueClient queueClient = new QueueClient(model.SBConnString, model.SBQueue);

                // Create the message to send to the queue.
                var message = new Message(Encoding.UTF8.GetBytes(model.SBMessage));

                await queueClient.SendAsync(message);
            }
            catch (Exception ex)
            {
                //ToDo: Handle exceptions
            }

        }
    }
}
