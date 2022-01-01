namespace CampaignModule.Application.Commands
{
    public interface ICommandService
    {
        void Execute(string command, string[] args);
    }
}
