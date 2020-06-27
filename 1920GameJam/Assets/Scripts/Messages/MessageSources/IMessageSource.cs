namespace GameJam1920.Assets.Scripts.Messages.MessageSources
{
    public interface IMessageSource
    {
        void SetupSource(MessageData messageData);
        MessageContent GetMessage(bool correct);
    }
}
