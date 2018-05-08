/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Quiz_solver_MVVM"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using Quiz_solver_MVVM.Helpers;
using System;
//using Quiz_solver_MVVM.Views;

namespace Quiz_solver_MVVM.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }


        public StartViewModel Start
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartViewModel>();
            }
        }
        public CurrentQuestionViewModel CurrentQuestion
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CurrentQuestionViewModel>();
            }
        }
        public SummaryViewModel Summary
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SummaryViewModel>();
            }
        }



        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new FrameNavigationService();

            navigationService.Configure("Main", new Uri("../MainWindow.xaml", UriKind.Relative));
            navigationService.Configure("Start", new Uri("../Views/StartView.xaml", UriKind.Relative));
            navigationService.Configure("CurrentQuestion", new Uri("../Views/CurrentQuestionView.xaml", UriKind.Relative));
            //navigationService.Configure("Summary", new Uri("../Views/SummaryView.xaml", UriKind.Relative));

           
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
           
            SimpleIoc.Default.Register<MainViewModel>(true);
            SimpleIoc.Default.Register<StartViewModel>(true);
            SimpleIoc.Default.Register<CurrentQuestionViewModel>(true);
            //SimpleIoc.Default.Register<SummaryViewModel>(true);

        }


        //public static void Cleanup()
        //{
        //    // TODO Clear the ViewModels
        //}
    }
}