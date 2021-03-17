using System;
using System.Net;
using ETModel;

namespace ETHotfix
{
	[MessageHandler(AppType.Gate)]
	public class C2G_GetUsernameHandler : AMRpcHandler<C2G_GetUserName, G2C_GetUsername>
	{
		protected override async ETTask Run(Session session, C2G_GetUserName request, G2C_GetUsername response, Action reply)
		{
			response.Username = session.GetComponent<SessionPlayerComponent>().Player.Account;
			reply();
			await ETTask.CompletedTask;
		}
	}
}