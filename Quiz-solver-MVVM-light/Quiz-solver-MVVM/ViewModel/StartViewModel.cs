using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using CommonServiceLocator;
using Quiz_solver_MVVM.Helpers;
using Quiz_solver_MVVM.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace Quiz_solver_MVVM.ViewModel
{
    public class StartViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<QuizModel> quizList;

        private QuizModel currentQuiz;
        private Guid currentQuizId;

        IFrameNavigationService navigationService;

        #endregion
        #region Properties

        public RelayCommand NavigateToCurrentQuestionViewCmd { get; private set; }
        public ObservableCollection<QuizModel> QuizList
        {
            get
            {
                return quizList;
            }

            set
            {
                quizList = value;
                RaisePropertyChanged("QuizList");
                
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
                RaisePropertyChanged("CurrentQuizName");
                //Console.WriteLine(CurrentQuiz.QuizName);
            }
        }



        public Guid CurrentQuizId
        {
            get
            {
                return currentQuizId;
            }

            set
            {
                currentQuizId = value;
                RaisePropertyChanged("CurrentQuiz");
                foreach (var q in QuizList)
                {
                    if (q.QuizId == value)
                    {
                        CurrentQuiz = q;
                    }
                }
                
            }
        }
        #endregion


        public StartViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
            NavigateToCurrentQuestionViewCmd = new RelayCommand(NavigateToCurrentQuestionView);
           /// Messenger.Default.Register<MVVMMessage>(this, this.SaveMessage);
            Messenger.Default.Register<QuizModel>(this, this.HandleCurrentQuizMessage);
            this.LoadQuizList();


        }

        #region Methods
        private void LoadQuizList()
        {
            
            using (System.IO.StreamReader r = new System.IO.StreamReader(@"E:\Cs\data.json"))
            {
                string json = r.ReadToEnd();
                QuizList = JsonConvert.DeserializeObject<ObservableCollection<QuizModel>>(json);
                 
            }
            #endregion
        }
        private void NavigateToCurrentQuestionView()
        {
            
            Messenger.Default.Send<CurrentQuizMessage>(new CurrentQuizMessage
            {
                Quiz = CurrentQuiz

            });
            navigationService.NavigateTo("CurrentQuestion");
            //check if CurrentQuiz is not null!
        }

        private void HandleCurrentQuizMessage(QuizModel msg)
        {
            CurrentQuiz = msg;
        }
    }
}
