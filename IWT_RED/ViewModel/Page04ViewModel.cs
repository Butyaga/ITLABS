using System.Windows;
using System.Windows.Threading;
using IWT_RED.ViewModel.Common;

namespace IWT_RED.ViewModel;
class Page04ViewModel : ViewModelBase, INextPage
{
    const int _timeSpanInSeconds = 20;
    private DispatcherTimer _timer;

    public event Action? NextPage;

    public Page04ViewModel()
    {
        TimeSpan time = TimeSpan.FromSeconds(_timeSpanInSeconds);
        _timer = new DispatcherTimer(time, DispatcherPriority.Normal, SwitchToNextPage, Application.Current.Dispatcher);
        _timer.Start();
    }
    private void SwitchToNextPage(object? sender, EventArgs e)
    {
        _timer.Stop();
        _timer.Tick -= SwitchToNextPage;
        NextPage?.Invoke();
    }

    #region Commands

    #region ShowPDFIwtCommand
    private RelayCommand? _showPDFIwtCommand;

    public RelayCommand ShowPDFIwtCommand
    {
        get
        {
            _showPDFIwtCommand ??= new RelayCommand(ShowPDFIwt_Execute);
            return _showPDFIwtCommand;
        }
    }

    public void ShowPDFIwt_Execute(object? parameter)
    {
        Stub("Показать Iwt PDF");
    }
    #endregion

    #region ShowPDFRedCommand
    private RelayCommand? _sShowPDFRedCommand;

    public RelayCommand ShowPDFRedCommand
    {
        get
        {
            _sShowPDFRedCommand ??= new RelayCommand(ShowPDFRed_Execute);
            return _sShowPDFRedCommand;
        }
    }

    public void ShowPDFRed_Execute(object? parameter)
    {
        Stub("Показать Red PDF");
    }
    #endregion
    #endregion

    private static void Stub(string msg)
    {
        MessageBox.Show($"Заглушка: {msg}");
    }
}
