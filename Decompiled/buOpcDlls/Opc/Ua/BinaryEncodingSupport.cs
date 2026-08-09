using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public enum BinaryEncodingSupport
{
	[EnumMember]
	Optional,
	[EnumMember]
	Required,
	[EnumMember]
	None
}
