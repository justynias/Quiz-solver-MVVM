using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;


namespace Quiz_solver_MVVM.Helpers
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
