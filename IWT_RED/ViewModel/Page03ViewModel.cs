using System.Windows;
using IWT_RED.ViewModel.Common;

namespace IWT_RED.ViewModel;

class Page03ViewModel : ViewModelBase, INextPage
{
    public event Action? NextPage;

    private string _pinCode = "000";
    public string PinCode
    {
        get => _pinCode;
        set
        {
            _pinCode = value;
            OnPropertyChanged();
        }
    }

    #region Commands
    #region SubmitAuthentificationCommand
    private RelayCommand? _submitAuthentificationCommand;

    public RelayCommand SubmitAuthentificationCommand
    {
        get
        {
            _submitAuthentificationCommand ??= new RelayCommand(SubmitAuthentification_Execute);
            return _submitAuthentificationCommand;
        }
    }

    public void SubmitAuthentification_Execute(object? parameter)
    {
        NextPage?.Invoke();
    }
    #endregion

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
