using IWT_RED.ViewModel.Common;

namespace IWT_RED.ViewModel;
class Page01ViewModel : ViewModelBase, INextPage
{
    public event Action? NextPage;

    #region ChangePage_Command
    private RelayCommand? _changePageCommand;

    public RelayCommand ChangePageCommand
    {
        get
        {
            _changePageCommand ??= new RelayCommand(ChangePageCommand_Execute);
            return _changePageCommand;
        }
    }

    public void ChangePageCommand_Execute(object? parameter)
    {
        NextPage?.Invoke();
    }
    #endregion
}
