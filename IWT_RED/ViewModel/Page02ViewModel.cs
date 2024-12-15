using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IWT_RED.Model;
using IWT_RED.ViewModel.Common;

namespace IWT_RED.ViewModel;
class Page02ViewModel : ViewModelBase, INextPage
{
    public event Action? NextPage;

    public PersonalDataModel PersonalData { get; set; } = new() { Name = "Фамилия, имя, отчетство", Email = "E-mail", Telephone = "Ваш телефон" };

    #region Commands
    #region SubmitPersonalDataCommand
    private RelayCommand? _submitPersonalDataCommand;

    public RelayCommand SubmitPersonalDataCommand
    {
        get
        {
            _submitPersonalDataCommand ??= new RelayCommand(SubmitPersonalData_Execute);
            return _submitPersonalDataCommand;
        }
    }

    public void SubmitPersonalData_Execute(object? parameter)
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
