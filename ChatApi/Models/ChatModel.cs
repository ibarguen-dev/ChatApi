namespace ChatApi.Models
{
    public class ChatModel
    {
        public int? idChat {  get; set; }
        public string chat {  get; set; }
        public UserModel ouser { get; set; }
        public ServerModel oserver { get; set; }
    }
}
