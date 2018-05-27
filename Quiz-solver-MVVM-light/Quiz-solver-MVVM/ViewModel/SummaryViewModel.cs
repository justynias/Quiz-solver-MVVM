using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using Quiz_solver_MVVM.Helpers;
using Quiz_solver_MVVM.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Media;

namespace Quiz_solver_MVVM.ViewModel
{
    public class SummaryViewModel : ViewModelBase
    {

        private IFrameNavigationService navigationService;
        private QuizModel finishedQuiz;
        public QuizModel FinishedQuiz
        {
            get
            {
                return finishedQuiz;
            }

            set
            {
                finishedQuiz = value;
                RaisePropertyChanged("FinishedQuiz");
            }
        }

        public SummaryViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
            Messenger.Default.Register<FinishedQuizMessage>(this, this.HandleFinishedQuizMessage);
        }


        private void HandleFinishedQuizMessage(FinishedQuizMessage message)
        {
            this.FinishedQuiz = message.Quiz;
        }
    }
}
