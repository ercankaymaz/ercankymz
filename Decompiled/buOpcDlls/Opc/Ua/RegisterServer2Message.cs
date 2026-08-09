using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterServer2Message : IServiceMessage
{
	public RegisterServer2Request RegisterServer2Request;

	public RegisterServer2Message()
	{
	}

	public RegisterServer2Message(RegisterServer2Request RegisterServer2Request)
	{
		this.RegisterServer2Request = RegisterServer2Request;
	}

	public IServiceRequest GetRequest()
	{
		return RegisterServer2Request;
	}

	public object CreateResponse(IServiceResponse response)
	{
		RegisterServer2Response registerServer2Response = response as RegisterServer2Response;
		if (registerServer2Response == null)
		{
			registerServer2Response = new RegisterServer2Response();
			registerServer2Response.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new RegisterServer2ResponseMessage(registerServer2Response);
	}
}
