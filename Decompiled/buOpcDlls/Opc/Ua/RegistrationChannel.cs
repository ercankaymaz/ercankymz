using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegistrationChannel : UaChannelBase<IRegistrationChannel>, IRegistrationChannel, IChannelBase
{
	public static ITransportChannel Create(ApplicationConfiguration configuration, EndpointDescription description, EndpointConfiguration endpointConfiguration, X509Certificate2 clientCertificate, IServiceMessageContext messageContext)
	{
		ITransportChannel transportChannel = UaChannelBase.CreateUaBinaryChannel(configuration, description, endpointConfiguration, clientCertificate, messageContext);
		if (transportChannel == null)
		{
			Uri url = new Uri(description.EndpointUrl);
			transportChannel = new RegistrationChannel();
			TransportChannelSettings transportChannelSettings = new TransportChannelSettings();
			transportChannelSettings.Configuration = endpointConfiguration;
			transportChannelSettings.Description = description;
			transportChannelSettings.ClientCertificate = clientCertificate;
			transportChannel.Initialize(url, transportChannelSettings);
		}
		return transportChannel;
	}

	internal RegistrationChannel()
	{
	}

	public RegisterServerResponseMessage RegisterServer(RegisterServerMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginRegisterServer(request, null, null);
		}
		return base.Channel.EndRegisterServer(result);
	}

	public IAsyncResult BeginRegisterServer(RegisterServerMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginRegisterServer(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public RegisterServerResponseMessage EndRegisterServer(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndRegisterServer(uaChannelAsyncResult.InnerResult);
	}

	public Task<RegisterServerResponseMessage> RegisterServerAsync(RegisterServerMessage request)
	{
		return base.Channel.RegisterServerAsync(request);
	}

	public RegisterServer2ResponseMessage RegisterServer2(RegisterServer2Message request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginRegisterServer2(request, null, null);
		}
		return base.Channel.EndRegisterServer2(result);
	}

	public IAsyncResult BeginRegisterServer2(RegisterServer2Message request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginRegisterServer2(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public RegisterServer2ResponseMessage EndRegisterServer2(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndRegisterServer2(uaChannelAsyncResult.InnerResult);
	}

	public Task<RegisterServer2ResponseMessage> RegisterServer2Async(RegisterServer2Message request)
	{
		return base.Channel.RegisterServer2Async(request);
	}
}
