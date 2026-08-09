using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class QueryNextResponseMessage
{
	public QueryNextResponse QueryNextResponse;

	public QueryNextResponseMessage()
	{
	}

	public QueryNextResponseMessage(QueryNextResponse QueryNextResponse)
	{
		this.QueryNextResponse = QueryNextResponse;
	}

	public QueryNextResponseMessage(ServiceFault ServiceFault)
	{
		QueryNextResponse = new QueryNextResponse();
		if (ServiceFault != null)
		{
			QueryNextResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
