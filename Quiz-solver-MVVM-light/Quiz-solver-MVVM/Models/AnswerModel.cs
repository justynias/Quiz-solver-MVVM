using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Quiz_solver_MVVM.Models
{
    public class AnswerModel : ObservableObject
    {
        #region Fields
        private string answerName;
        private bool isValid;
        private Guid answerId;
        #endregion
        #region Properties
        public string AnswerName
        {
            get
            {
                return answerName;

            }
            set
            {
                if (answerName != value)
                {
                    answerName = value;
                    RaisePropertyChanged("AnswerName");
                }

            }
        }

        public bool IsValid
        {
            get
            {
                return isValid;

            }
            set
            {
                if (isValid != value)
                {
                    isValid = value;
                    RaisePropertyChanged("IsValid");
                }
            }
        }

        public Guid AnswerId
        {
            get
            {
                return answerId;
            }

            set
            {
                if (value != answerId)
                {
                    answerId = value;
                    RaisePropertyChanged("AnswerId");
                }

            }
        }
        #endregion
    }
}
