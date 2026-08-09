using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum NamingRuleType
{
	[EnumMember(Value = "Mandatory_1")]
	Mandatory = 1,
	[EnumMember(Value = "Optional_2")]
	Optional,
	[EnumMember(Value = "Constraint_3")]
	Constraint
}
