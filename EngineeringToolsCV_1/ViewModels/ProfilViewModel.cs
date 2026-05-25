using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.Components;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
	public class ProfilViewModel: ViewModelBase
	{
		private IImageService _imageService;
		private IMessageService _messageService;
		private INavigationBarService _navigationBarService;
		private readonly IStudentInfo _userInfo;
		private MStudentInformations _mStudent;
		private IStudentWorkInfo _userWorkInfo;
		private MStudentWorkInfo _mUserWorkInfo;

		public ViewModelCommand NavigateUpdateCommand { get; }

		public ProfilViewModel(NavigationStore navigateStore,
									  INavigationBarService navigationBarService,
								     IMessageService messageService,
								     IImageService imageService,
								     IStudentInfo userInfo,
									  MStudentInformations mStudent,
									  IStudentWorkInfo userWorkInfo,
								     MStudentWorkInfo mUserWorkInfo)
		{
			this._navigationBarService = navigationBarService;
			this._messageService = messageService;
			this._imageService = imageService;
			this._userInfo = userInfo;
			this._mStudent = mStudent;
			this._userWorkInfo = userWorkInfo;
			this._mUserWorkInfo = mUserWorkInfo;

			this.NavigateUpdateCommand = new NavigateCommand<DashboardViewModel>(
													new LayoutNavigationService<DashboardViewModel>(navigateStore,
													() => new DashboardViewModel(navigateStore,
													                             this._navigationBarService,
													                             this._messageService,
													                             this._userInfo,
													                             this._userWorkInfo,
													                             this._imageService,
													                             this._mStudent,
													                             this._mUserWorkInfo),
													this._navigationBarService.CreateNavigationBar("Home -> Profil -> Dashboard")));
		}

	}
}
   