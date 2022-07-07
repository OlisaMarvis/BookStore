using Marvis.BookStore.Models;
using Microsoft.Extensions.Options;

namespace Marvis.BookStore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlertConfiguration;

        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> newBookAlertConfiguration)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration;
        }
        public string GetName()
        {
            return _newBookAlertConfiguration.CurrentValue.BookName;
        }
    }
}
