using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using Quiz_solver_MVVM.Helpers;
using Quiz_solver_MVVM.Models;

namespace Quiz_solver_MVVM.ViewModel
{
    public class CurrentQuestionViewModel : ViewModelBase
    {
        private IFrameNavigationService navigationService;
        //private string quizName;
        private QuizModel currentQuiz;
        //public string QuizName
        //{
        //    get
        //    {
        //        return quizName;
        //    }

        //    set
        //    {
        //        quizName = value;
        //        RaisePropertyChanged("QuizName");
        //        //Console.WriteLine(QuizName);

        //        //Messenger.Default.Send<string>(value);
        //    }
        //}
        public QuizModel CurrentQuiz
        {
            get
            {
                return currentQuiz;
            }

            set
            {
                currentQuiz = value;
                RaisePropertyChanged("CurrentQuizName");
                Console.WriteLine(CurrentQuiz.QuizName);
            }
        }


        public CurrentQuestionViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;

            Messenger.Default.Register<CurrentQuizMessage>(this, this.HandleCurrentQuizMessage);
            //Console.WriteLine("dupa");
        }

        private void HandleCurrentQuizMessage(CurrentQuizMessage message)
        {
            this.CurrentQuiz = message.Quiz;
           // this.QuizId = message.Quiz.QuizId;
            //this.QuestionsList = message.Quiz.QuestionsList;
        }
    }
}
