using EngineeringToolsCV_1.ViewModels;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Service
{
	public class MessageService : IMessageService
	{
		private ErrorMessageViewModel _vmdialogMessage;
		private MessageDialog dialogMessage;

		public MessageService(ErrorMessageViewModel vmdialogMessage)
		{
			this._vmdialogMessage = vmdialogMessage;
		}

		public void ShowErrorMessage(string message)
		{
			this.dialogMessage = new MessageDialog();
			this._vmdialogMessage.SetErrorMessage = message;
			this.dialogMessage.DataContext = this._vmdialogMessage;
			this.dialogMessage.Show();
		}
	}
}
