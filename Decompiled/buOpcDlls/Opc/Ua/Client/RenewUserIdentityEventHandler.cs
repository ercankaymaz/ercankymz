using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate IUserIdentity RenewUserIdentityEventHandler(ISession session, IUserIdentity identity);
