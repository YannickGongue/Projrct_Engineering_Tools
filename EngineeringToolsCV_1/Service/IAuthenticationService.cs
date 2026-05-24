using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.Service
{
	public interface IAuthenticationService
	{
		Task<DataTable> LoginAsync();
	}
}
