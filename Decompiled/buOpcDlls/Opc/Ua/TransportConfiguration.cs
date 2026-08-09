using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class TransportConfiguration
{
	private string m_uriScheme;

	private string m_typeName;

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 0)]
	public string UriScheme
	{
		get
		{
			return m_uriScheme;
		}
		set
		{
			m_uriScheme = value;
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
	public string TypeName
	{
		get
		{
			return m_typeName;
		}
		set
		{
			m_typeName = value;
		}
	}

	public TransportConfiguration()
	{
	}

	public TransportConfiguration(string urlScheme, Type type)
	{
		m_uriScheme = urlScheme;
		m_typeName = type.AssemblyQualifiedName;
	}
}
