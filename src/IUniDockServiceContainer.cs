namespace NP.Ava.UniDockService
{
    public interface IUniDockServiceContainer
    {
        IUniDockService DockService { get; }

        void SetNewDockService();

        void RestoreLayout();
    }
}
