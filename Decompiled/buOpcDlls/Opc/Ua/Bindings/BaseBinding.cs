using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public abstract class BaseBinding
{
	private IServiceMessageContext m_messageContext;

	public IServiceMessageContext MessageContext
	{
		get
		{
			return m_messageContext;
		}
		set
		{
			m_messageContext = value;
		}
	}

	protected BaseBinding(NamespaceTable namespaceUris, IEncodeableFactory factory, EndpointConfiguration configuration)
	{
		m_messageContext = new ServiceMessageContext
		{
			MaxStringLength = configuration.MaxStringLength,
			MaxByteStringLength = configuration.MaxByteStringLength,
			MaxArrayLength = configuration.MaxArrayLength,
			MaxMessageSize = configuration.MaxMessageSize,
			Factory = factory,
			NamespaceUris = namespaceUris
		};
	}
}
