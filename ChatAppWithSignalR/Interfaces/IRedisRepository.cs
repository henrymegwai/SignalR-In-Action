using ChatAppWithSignalR.Models;

namespace ChatAppWithSignalR.Interfaces
{
    public interface IRedisRepository
    {
        Task<ChatMessage> Get(string key); 
    }
}
