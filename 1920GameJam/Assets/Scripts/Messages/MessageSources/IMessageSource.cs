namespace GameJam1920.Assets.Scripts.Messages.MessageSources
{
    public interface IMessageSource
    {
        MessageContent GetMessage(bool correct);
    }
}
