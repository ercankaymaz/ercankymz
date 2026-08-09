using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishMessage : IServiceMessage
{
	public PublishRequest PublishRequest;

	public PublishMessage()
	{
	}

	public PublishMessage(PublishRequest PublishRequest)
	{
		this.PublishRequest = PublishRequest;
	}

	public IServiceRequest GetRequest()
	{
		return PublishRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		PublishResponse publishResponse = response as PublishResponse;
		if (publishResponse == null)
		{
			publishResponse = new PublishResponse();
			publishResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new PublishResponseMessage(publishResponse);
	}
}
