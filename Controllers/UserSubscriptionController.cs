using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dotnet.web.api
{
	public class UserSubscriptionController : BaseController
	{
		private static Dictionary<string, UserSubscription> _userSubscription;
		internal static Dictionary<string, UserSubscription> UserSubscription
		{
			get
			{
				if (_userSubscription == null)
				{
					_userSubscription = new Dictionary<string, UserSubscription>();

					var subscription = new UserSubscription()
					{
						UserName = "xiaoxiao",
						Codes = new List<string>() { "000001", "600000" }
					};
					_userSubscription.Add(subscription.UserName, subscription);
				}
				return _userSubscription;
			}
		}

		[HttpGet]
		public string Get()
		{
			var userData = UserAuthentication.GetUserDataFromRequest();
			if (userData == null)
			{
				return "No User Ticket";
			}

			UserSubscription subscription;
			if (UserSubscription.TryGetValue(userData.UserName, out subscription))
			{
				return string.Join(",", subscription.Codes);
			}

			return "No UserSubscription";
		}
	}
}
