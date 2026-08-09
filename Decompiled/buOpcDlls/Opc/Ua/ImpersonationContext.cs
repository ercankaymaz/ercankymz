using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Opc.Ua;

[ComVisible(true)]
public class ImpersonationContext
{
	public IPrincipal Principal { get; set; }
}
