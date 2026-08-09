using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class WriteMessage : IServiceMessage
{
	public WriteRequest WriteRequest;

	public WriteMessage()
	{
	}

	public WriteMessage(WriteRequest WriteRequest)
	{
		this.WriteRequest = WriteRequest;
	}

	public IServiceRequest GetRequest()
	{
		return WriteRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		WriteResponse writeResponse = response as WriteResponse;
		if (writeResponse == null)
		{
			writeResponse = new WriteResponse();
			writeResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new WriteResponseMessage(writeResponse);
	}
}
