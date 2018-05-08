using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Quiz_solver_MVVM.Models
{
    public class QuestionModel : ObservableObject
    {
        #region Fields
        private string questionName;
        private ObservableCollection<AnswerModel> answersList;
        private Guid questionId;
        #endregion

        #region Properties
        public string QuestionName
        {
            get
            {
                return questionName;
            }

            set
            {
                if (value != questionName)
                {
                    questionName = value;
                    RaisePropertyChanged("QuestionName");
                }
            }
        }

        public ObservableCollection<AnswerModel> AnswersList
        {
            get
            {
                return answersList;
            }

            set
            {
                if (value != answersList)
                {
                    answersList = value;
                    RaisePropertyChanged("AnswersList");
                }
            }
        }
        public Guid QuestionId
        {
            get
            {
                return questionId;
            }

            set
            {
                if (value != questionId)
                {
                    questionId = value;
                    RaisePropertyChanged("QuestionId");
                }

            }
        }
        #endregion
    }
}
