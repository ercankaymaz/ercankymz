using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public class TransportListenerSettings
{
	private EndpointDescriptionCollection m_descriptions;

	private EndpointConfiguration m_configuration;

	private X509Certificate2 m_serverCertificate;

	private X509Certificate2Collection m_serverCertificateChain;

	private ICertificateValidator m_certificateValidator;

	private NamespaceTable m_namespaceUris;

	private IEncodeableFactory m_channelFactory;

	private bool m_reverseConnectListener;

	public EndpointDescriptionCollection Descriptions
	{
		get
		{
			return m_descriptions;
		}
		set
		{
			m_descriptions = value;
		}
	}

	public EndpointConfiguration Configuration
	{
		get
		{
			return m_configuration;
		}
		set
		{
			m_configuration = value;
		}
	}

	public X509Certificate2 ServerCertificate
	{
		get
		{
			return m_serverCertificate;
		}
		set
		{
			m_serverCertificate = value;
		}
	}

	public X509Certificate2Collection ServerCertificateChain
	{
		get
		{
			return m_serverCertificateChain;
		}
		set
		{
			m_serverCertificateChain = value;
		}
	}

	public ICertificateValidator CertificateValidator
	{
		get
		{
			return m_certificateValidator;
		}
		set
		{
			m_certificateValidator = value;
		}
	}

	public NamespaceTable NamespaceUris
	{
		get
		{
			return m_namespaceUris;
		}
		set
		{
			m_namespaceUris = value;
		}
	}

	public IEncodeableFactory Factory
	{
		get
		{
			return m_channelFactory;
		}
		set
		{
			m_channelFactory = value;
		}
	}

	public bool ReverseConnectListener
	{
		get
		{
			return m_reverseConnectListener;
		}
		set
		{
			m_reverseConnectListener = value;
		}
	}
}
