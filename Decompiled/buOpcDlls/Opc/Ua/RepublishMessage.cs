using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RepublishMessage : IServiceMessage
{
	public RepublishRequest RepublishRequest;

	public RepublishMessage()
	{
	}

	public RepublishMessage(RepublishRequest RepublishRequest)
	{
		this.RepublishRequest = RepublishRequest;
	}

	public IServiceRequest GetRequest()
	{
		return RepublishRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		RepublishResponse republishResponse = response as RepublishResponse;
		if (republishResponse == null)
		{
			republishResponse = new RepublishResponse();
			republishResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new RepublishResponseMessage(republishResponse);
	}
}
