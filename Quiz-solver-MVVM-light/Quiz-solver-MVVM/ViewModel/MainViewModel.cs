using GalaSoft.MvvmLight;
using Quiz_solver_MVVM.Helpers;


namespace Quiz_solver_MVVM.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// 
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        IFrameNavigationService navigationService;

        #endregion

        public MainViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        #region Properties / Commands

        #endregion

        #region Methods



        #endregion
    }
}
    
