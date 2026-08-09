using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum PubSubDiagnosticsCounterClassification
{
	[EnumMember(Value = "Information_0")]
	Information,
	[EnumMember(Value = "Error_1")]
	Error
}
