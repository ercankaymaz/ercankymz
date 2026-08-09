using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IServiceMessage
{
	IServiceRequest GetRequest();

	object CreateResponse(IServiceResponse response);
}
