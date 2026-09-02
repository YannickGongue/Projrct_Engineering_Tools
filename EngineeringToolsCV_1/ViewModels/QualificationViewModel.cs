using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EngineeringToolsCV_1.ViewModels
{
    public class QualificationViewModel : ViewModelBase
    {
		private OpenFileDialog dialog;
		private IFileDialogService _fileDialogService;
		private IImageService _imageService;
		private IMessageService _messageService;
		private INavigationBarService _navigationBarService;
		private readonly IStudentInfo _IstudentInfo;
		private IStudentWorkInfo _IstudentWorkInfo;
		private MStudentWorkInfo _mUserWorkInfo;

		private MStudentInformations _mStudentInfos;
		private NavigationStore navigationStore;


		public ICommand NavigateReturnCommand { get; set; }

		  public QualificationViewModel(NavigationStore navigationStore,
												  IImageService imageService,
											IMessageService messageService,
											IStudentInfo IstudentInfo,
											IStudentWorkInfo IstudentWorkInfo,
											MStudentWorkInfo mUserWorkInfo,
											INavigationBarService navigationBarService,
											MStudentInformations mStudentInfos,
											IFileDialogService fileDialogService)
        {
            this.navigationStore = navigationStore;
            this._fileDialogService = fileDialogService;
            this._imageService = imageService;
            this._messageService = messageService;
            this._IstudentInfo = IstudentInfo;
            this._IstudentWorkInfo = IstudentWorkInfo;
            this._mUserWorkInfo = mUserWorkInfo;
            this._navigationBarService = navigationBarService;
            this._mStudentInfos = mStudentInfos;
			this.executeCancelCommand(navigationStore);

		}

		// Ergänzte Methoden mit den erwarteten Signaturen
		private void executeCancelCommand(NavigationStore navigationStore)
		{
			this.NavigateReturnCommand = new NavigateCommand<DashboardViewModel>(
							  new LayoutNavigationService<DashboardViewModel>(navigationStore,
							  () => new DashboardViewModel(navigationStore,
																	 this._navigationBarService,
																	 this._messageService,
																	 this._IstudentInfo,
																	 this._IstudentWorkInfo,
																	 this._imageService,
																	 this._fileDialogService,
																	 this._mStudentInfos,
																	 this._mUserWorkInfo),
							  this._navigationBarService.CreateNavigationBar("Home->Profil-> Dashboard")));
		}
	}
}
