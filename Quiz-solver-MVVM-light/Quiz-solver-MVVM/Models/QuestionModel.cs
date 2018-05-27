using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

        public bool IsQuestionCorrect
        {
            get
            {
                for (int i = 0; i < AnswersList.Count(); i++)
                {
                    if (AnswersList.ElementAt(i).IsValid != AnswersList.ElementAt(i).UserAnswer)
                    {
                        return false;
                    }

                }  
                return true;

            }

        }
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
