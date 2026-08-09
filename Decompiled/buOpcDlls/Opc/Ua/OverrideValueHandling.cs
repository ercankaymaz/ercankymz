using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum OverrideValueHandling
{
	[EnumMember(Value = "Disabled_0")]
	Disabled,
	[EnumMember(Value = "LastUsableValue_1")]
	LastUsableValue,
	[EnumMember(Value = "OverrideValue_2")]
	OverrideValue
}
