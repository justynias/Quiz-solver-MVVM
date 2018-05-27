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
    public class StartViewModel : ViewModelBase 
    {
        #region Fields
        private ObservableCollection<QuizModel> quizList;

        private QuizModel currentQuiz;
        private Guid currentQuizId;
 

        IFrameNavigationService navigationService;

        #endregion
        #region Properties

        
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

        public RelayCommand NavigateToCurrentQuestionViewCmd { get; private set; }
        public StartViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
            NavigateToCurrentQuestionViewCmd = new RelayCommand(NavigateToCurrentQuestionView, () => CurrentQuiz!=null);
            this.LoadQuizList();


        }

        #region Methods
        private void LoadQuizList()
        {
            try
            {
                using (System.IO.StreamReader r = new System.IO.StreamReader(@"E:\Cs\Quiz-solver-MVVM\data.json"))
                {
                    string json = r.ReadToEnd();
                    QuizList = JsonConvert.DeserializeObject<ObservableCollection<QuizModel>>(json);

                }
            }
            catch (System.IO.FileNotFoundException) { } 
            catch (JsonReaderException) { }

        }
        private void NavigateToCurrentQuestionView()
        {
            
            Messenger.Default.Send<CurrentQuizMessage>(new CurrentQuizMessage
            {
                Quiz = CurrentQuiz

            });
            navigationService.NavigateTo("CurrentQuestion");
        }

        #endregion

    }

}
