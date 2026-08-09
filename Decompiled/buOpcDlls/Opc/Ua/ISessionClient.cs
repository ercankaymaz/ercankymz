using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ISessionClient : ISessionClientMethods, IClientBase, IDisposable
{
	NodeId SessionId { get; }

	bool Connected { get; }
}
