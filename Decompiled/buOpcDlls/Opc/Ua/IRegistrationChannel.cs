using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface IRegistrationChannel : IChannelBase
{
	RegisterServerResponseMessage RegisterServer(RegisterServerMessage request);

	IAsyncResult BeginRegisterServer(RegisterServerMessage request, AsyncCallback callback, object asyncState);

	RegisterServerResponseMessage EndRegisterServer(IAsyncResult result);

	Task<RegisterServerResponseMessage> RegisterServerAsync(RegisterServerMessage request);

	RegisterServer2ResponseMessage RegisterServer2(RegisterServer2Message request);

	IAsyncResult BeginRegisterServer2(RegisterServer2Message request, AsyncCallback callback, object asyncState);

	RegisterServer2ResponseMessage EndRegisterServer2(IAsyncResult result);

	Task<RegisterServer2ResponseMessage> RegisterServer2Async(RegisterServer2Message request);
}
