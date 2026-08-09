using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ReadMessage : IServiceMessage
{
	public ReadRequest ReadRequest;

	public ReadMessage()
	{
	}

	public ReadMessage(ReadRequest ReadRequest)
	{
		this.ReadRequest = ReadRequest;
	}

	public IServiceRequest GetRequest()
	{
		return ReadRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		ReadResponse readResponse = response as ReadResponse;
		if (readResponse == null)
		{
			readResponse = new ReadResponse();
			readResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new ReadResponseMessage(readResponse);
	}
}
