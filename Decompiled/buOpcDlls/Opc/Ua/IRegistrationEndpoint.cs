using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface IRegistrationEndpoint : IEndpointBase
{
	IAsyncResult BeginRegisterServer(RegisterServerMessage request, AsyncCallback callback, object asyncState);

	RegisterServerResponseMessage EndRegisterServer(IAsyncResult result);

	IAsyncResult BeginRegisterServer2(RegisterServer2Message request, AsyncCallback callback, object asyncState);

	RegisterServer2ResponseMessage EndRegisterServer2(IAsyncResult result);
}
