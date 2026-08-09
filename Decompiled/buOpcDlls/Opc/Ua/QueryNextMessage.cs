using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class QueryNextMessage : IServiceMessage
{
	public QueryNextRequest QueryNextRequest;

	public QueryNextMessage()
	{
	}

	public QueryNextMessage(QueryNextRequest QueryNextRequest)
	{
		this.QueryNextRequest = QueryNextRequest;
	}

	public IServiceRequest GetRequest()
	{
		return QueryNextRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		QueryNextResponse queryNextResponse = response as QueryNextResponse;
		if (queryNextResponse == null)
		{
			queryNextResponse = new QueryNextResponse();
			queryNextResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new QueryNextResponseMessage(queryNextResponse);
	}
}
