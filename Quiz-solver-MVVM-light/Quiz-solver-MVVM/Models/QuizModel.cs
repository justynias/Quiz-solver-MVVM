using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
//using QuizCreator.Additionals;
using System.Collections.ObjectModel;


namespace Quiz_solver_MVVM.Models
{
    public class QuizModel : ObservableObject
    {
        #region Fields
        private string quizName;
        private Guid quizId;
        private ObservableCollection<QuestionModel> questionsList;
        private float result = 0;
        #endregion
        #region Properties
        public string QuizName
        {
            get
            {
                return quizName;
            }

            set
            {
                if (value != quizName)
                {
                    quizName = value;
                    RaisePropertyChanged("QuizName");
                }
            }
        }

        public float Result
        {
            get
            {

                return result;
            }

            set
            {
                if (value != result)

                 result = value;
                RaisePropertyChanged("Result");
            }
        }
        public ObservableCollection<QuestionModel> QuestionsList
        {
            get
            {

                return questionsList;
            }

            set
            {
                if (value != questionsList)

                    questionsList = value;
                RaisePropertyChanged("QuestionsList");
            }
        }

        public Guid QuizId
        {
            get
            {
                return quizId;
            }

            set
            {
                if (value != quizId)
                {
                    quizId = value;
                    RaisePropertyChanged("QuizId");
                }

            }
        }
        #endregion

    }
}
