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

namespace Quiz_solver_MVVM.ViewModel
{

    public class CurrentQuestionViewModel : ViewModelBase
    {
        private IFrameNavigationService navigationService;
        private QuizModel currentQuiz;
        private QuestionModel currentQuestion;
        private int currentQuestionIndex;
         
        public QuestionModel CurrentQuestion
        {
            get
            {
                return currentQuestion;
            }

            set
            {
                currentQuestion = value;
                RaisePropertyChanged("CurrentQuestion");

            }
        }

        public QuizModel CurrentQuiz
        {
            get
            {
                return currentQuiz;
            }

            set
            {
                currentQuiz = value;
                RaisePropertyChanged("CurrentQuiz");
            }
        }


        public int CurrentQuestionIndex
        {
            get
            {
                return currentQuestionIndex;
            }

            set
            {
                currentQuestionIndex = value;
                RaisePropertyChanged("CurrentQuestionIndex");
               
            }
        }


        public RelayCommand NavigateToNextQuestionViewCmd { get; private set; }

        public CurrentQuestionViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;

            Messenger.Default.Register<CurrentQuizMessage>(this, this.HandleCurrentQuizMessage);
            NavigateToNextQuestionViewCmd = new RelayCommand(NavigateToNextQuestionView);
           
        }
 

        private void HandleCurrentQuizMessage(CurrentQuizMessage message)
        {
            this.CurrentQuiz = message.Quiz;
            if (CurrentQuiz.QuestionsList.Count() > 0)
            {
                this.CurrentQuestion = CurrentQuiz.QuestionsList.First();
                this.CurrentQuestionIndex = 0;

            }
        }

        private void NavigateToNextQuestionView()
        {
            CheckAnswers();
            CurrentQuestionIndex++;
            if(CurrentQuestionIndex < CurrentQuiz.QuestionsList.Count())
            {
                 CurrentQuestion = CurrentQuiz.QuestionsList.ElementAt(CurrentQuestionIndex);
            }
            else
            {
                Messenger.Default.Send<FinishedQuizMessage>(new FinishedQuizMessage
                {
                    Quiz = CurrentQuiz

                });
                navigationService.NavigateTo("Summary");
            }
         
        }
        private void  CheckAnswers()
        {

            try
            {
                if (CurrentQuestion.IsQuestionCorrect) CurrentQuiz.Result++;

            }
            catch (NullReferenceException) { }
        }
    }
}
