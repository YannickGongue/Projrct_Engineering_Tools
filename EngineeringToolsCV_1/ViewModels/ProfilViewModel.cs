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
		private IFileDialogService _FiledialogService;
		private IImageService _imageService;
		private IMessageService _messageService;
		private INavigationBarService _navigationBarService;
		private readonly IStudentInfo _StudentInfo;
		private MStudentInformations _mStudent;
		private IStudentWorkInfo _StudentWorkInfo;

		private MStudentWorkInfo _mStudentWorkInfo;

		public ViewModelCommand NavigateUpdateCommand { get; }

		public ProfilViewModel(NavigationStore navigateStore,
									  INavigationBarService navigationBarService,
								     IMessageService messageService,
								     IImageService imageService,
								     IStudentInfo StudentInfo,
									  IFileDialogService FiledialogService,
									  MStudentInformations mStudent,
									  IStudentWorkInfo StudentWorkInfo,
								     MStudentWorkInfo mStudentWorkInfo)
		{
			this._navigationBarService = navigationBarService;
			this._messageService = messageService;
			this._imageService = imageService;
			this._StudentInfo = StudentInfo;
			this._mStudent = mStudent;
			this._StudentWorkInfo = StudentWorkInfo;
			this._mStudentWorkInfo = mStudentWorkInfo;
			this._FiledialogService = FiledialogService;


			this.NavigateUpdateCommand = new NavigateCommand<DashboardViewModel>(
													new LayoutNavigationService<DashboardViewModel>(navigateStore,
													() => new DashboardViewModel(navigateStore,
													                             this._navigationBarService,
													                             this._messageService,
													                             this._StudentInfo,
													                             this._StudentWorkInfo,
													                             this._imageService,
																						  this._FiledialogService,
													                             this._mStudent,
													                             this._mStudentWorkInfo),
													this._navigationBarService.CreateNavigationBar("Home -> Profil -> Dashboard")));
		}

	}
}
   