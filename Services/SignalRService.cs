
using IyizicoApi.Controllers;
using IyizicoApi.Hub;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNetCore.SignalR;
namespace IyizicoApi.Services
{
    public sealed class SignalRService
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public SignalRService(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendPaymentStatus(string transactionId, CallbackData data)
        {
            await _hubContext.Clients.Client(MessageHub.TransactionConnections[data.ConversationId]).SendAsync("ReceivePaymentStatus", data);
        }
    }
}
