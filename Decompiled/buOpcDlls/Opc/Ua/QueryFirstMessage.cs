using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class QueryFirstMessage : IServiceMessage
{
	public QueryFirstRequest QueryFirstRequest;

	public QueryFirstMessage()
	{
	}

	public QueryFirstMessage(QueryFirstRequest QueryFirstRequest)
	{
		this.QueryFirstRequest = QueryFirstRequest;
	}

	public IServiceRequest GetRequest()
	{
		return QueryFirstRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		QueryFirstResponse queryFirstResponse = response as QueryFirstResponse;
		if (queryFirstResponse == null)
		{
			queryFirstResponse = new QueryFirstResponse();
			queryFirstResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new QueryFirstResponseMessage(queryFirstResponse);
	}
}
