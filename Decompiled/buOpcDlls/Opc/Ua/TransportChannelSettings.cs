using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public class TransportChannelSettings
{
	private EndpointDescription m_description;

	private EndpointConfiguration m_configuration;

	private X509Certificate2 m_clientCertificate;

	private X509Certificate2Collection m_clientCertificateChain;

	private X509Certificate2 m_serverCertificate;

	private ICertificateValidator m_certificateValidator;

	private NamespaceTable m_namespaceUris;

	private IEncodeableFactory m_channelFactory;

	public EndpointDescription Description
	{
		get
		{
			return m_description;
		}
		set
		{
			m_description = value;
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

	public X509Certificate2 ClientCertificate
	{
		get
		{
			return m_clientCertificate;
		}
		set
		{
			m_clientCertificate = value;
		}
	}

	public X509Certificate2Collection ClientCertificateChain
	{
		get
		{
			return m_clientCertificateChain;
		}
		set
		{
			m_clientCertificateChain = value;
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
}
