using EngineeringToolsCV_1.ViewModels;

namespace EngineeringToolsCV_1.Service
{
   
    public interface INavigateService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
    
}
