using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dotnet.web.api
{
	public class BaseController : ApiController
	{
		public string Options()
		{
			return null; // HTTP 200 response with empty body
		}
	}
}
