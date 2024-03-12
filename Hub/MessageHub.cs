﻿using Microsoft.AspNetCore.SignalR;
namespace IyizicoApi.Hub
{
    public sealed class MessageHub : DynamicHub
    {
        public static readonly Dictionary<string, string> TransactionConnections = new Dictionary<string, string>();

        public void RegisterTransactionId(string transactionId)
        {
            var connectionId = Context.ConnectionId;
            TransactionConnections[transactionId] = connectionId;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var item = TransactionConnections.FirstOrDefault(kvp => kvp.Value == connectionId);
            if (!item.Equals(default(KeyValuePair<string, string>)))
            {
                TransactionConnections.Remove(item.Key);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
