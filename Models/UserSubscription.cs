using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnet.web.api
{
	public class UserSubscription
	{
		public string UserName { get; set; }

		public List<string> Codes { get; set; }
	}
}