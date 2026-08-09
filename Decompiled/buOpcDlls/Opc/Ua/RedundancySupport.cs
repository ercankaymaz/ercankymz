using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum RedundancySupport
{
	[EnumMember(Value = "None_0")]
	None,
	[EnumMember(Value = "Cold_1")]
	Cold,
	[EnumMember(Value = "Warm_2")]
	Warm,
	[EnumMember(Value = "Hot_3")]
	Hot,
	[EnumMember(Value = "Transparent_4")]
	Transparent,
	[EnumMember(Value = "HotAndMirrored_5")]
	HotAndMirrored
}
