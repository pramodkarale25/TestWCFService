using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace TestWCFService.Service
{
	[ServiceContract]
	public interface IJSONServiceTrialNError
	{
		//Default message exchange pattern is Request-Reply
		[OperationContract]//(IsOneWay = true)] - only request dont want reply
						   // [OperationContract(ConcurrencyMode = ConcurrencyMode.Reentrant)] - duplex
		[WebGet(ResponseFormat = WebMessageFormat.Json)]
		int DoWork();

		[OperationContract]
		[WebInvoke(
			ResponseFormat = WebMessageFormat.Json,
			Method = "GET",
			BodyStyle = WebMessageBodyStyle.Bare,
			UriTemplate = "GetAllHeros"
			)]
		List<SuperHero> GetAllHeros();
	}
}
