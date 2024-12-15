using System.Windows.Controls;
using IWT_RED.ViewModel.Common;
using IWT_RED.View;

namespace IWT_RED.ViewModel;
class MainWindowViewModel : ViewModelBase
{
    private readonly List<Type> _pageTypes = [typeof(Page01), typeof(Page02), typeof(Page03), typeof(Page04)];
    private int _currentPageIndex = 0;

    public MainWindowViewModel()
    {
        if (Activator.CreateInstance(_pageTypes[_currentPageIndex]) is Page page)
        {
            CurrentPage = page;
        }
    }

    public void NextPage()
    {
        _currentPageIndex++;
        if (_currentPageIndex >= _pageTypes.Count)
        {
            _currentPageIndex = 0;
        }

        if (Activator.CreateInstance(_pageTypes[_currentPageIndex]) is Page page)
        {
            CurrentPage = page;
        }
    }

    #region CurrentPage_Property
    private Page _currentPage = null!;
    public Page CurrentPage
    {
        get { return _currentPage; }
        set
        {
            if (_currentPage == value)
                return;

            ChangeSubs(_currentPage, value);
            _currentPage = value;
            OnPropertyChanged();
        }
    }
    #endregion

    private void ChangeSubs(Page currentPage, Page newPage)
    {
        if (currentPage?.DataContext is INextPage currentViewModel)
        {
            currentViewModel.NextPage -= NextPage;
        }

        if (newPage.DataContext is INextPage newViewModel)
        {
            newViewModel.NextPage += NextPage;
        }
    }
}
