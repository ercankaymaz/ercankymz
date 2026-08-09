using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ConfigurationLocation
{
	private string m_filePath;

	[DataMember(IsRequired = true, Order = 0)]
	public string FilePath
	{
		get
		{
			return m_filePath;
		}
		set
		{
			m_filePath = value;
		}
	}
}
