using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ReverseConnectEndpoint
{
	private bool m_enabled;

	private string m_serverUri;

	private string m_thumbprint;

	[DataMember(Name = "Enabled", Order = 1, IsRequired = false)]
	public bool Enabled
	{
		get
		{
			return m_enabled;
		}
		set
		{
			m_enabled = value;
		}
	}

	[DataMember(Name = "ServerUri", Order = 2, IsRequired = false)]
	public string ServerUri
	{
		get
		{
			return m_serverUri;
		}
		set
		{
			m_serverUri = value;
		}
	}

	[DataMember(Name = "Thumbprint", Order = 3, IsRequired = false)]
	public string Thumbprint
	{
		get
		{
			return m_thumbprint;
		}
		set
		{
			m_thumbprint = value;
		}
	}

	public ReverseConnectEndpoint()
	{
		Initialize();
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_enabled = false;
		m_serverUri = null;
		m_thumbprint = null;
	}
}
