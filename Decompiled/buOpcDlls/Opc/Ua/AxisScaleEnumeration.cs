using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum AxisScaleEnumeration
{
	[EnumMember(Value = "Linear_0")]
	Linear,
	[EnumMember(Value = "Log_1")]
	Log,
	[EnumMember(Value = "Ln_2")]
	Ln
}
