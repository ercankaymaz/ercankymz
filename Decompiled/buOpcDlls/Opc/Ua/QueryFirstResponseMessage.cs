using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class QueryFirstResponseMessage
{
	public QueryFirstResponse QueryFirstResponse;

	public QueryFirstResponseMessage()
	{
	}

	public QueryFirstResponseMessage(QueryFirstResponse QueryFirstResponse)
	{
		this.QueryFirstResponse = QueryFirstResponse;
	}

	public QueryFirstResponseMessage(ServiceFault ServiceFault)
	{
		QueryFirstResponse = new QueryFirstResponse();
		if (ServiceFault != null)
		{
			QueryFirstResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
