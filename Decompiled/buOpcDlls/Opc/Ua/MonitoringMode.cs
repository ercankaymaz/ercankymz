using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum MonitoringMode
{
	[EnumMember(Value = "Disabled_0")]
	Disabled,
	[EnumMember(Value = "Sampling_1")]
	Sampling,
	[EnumMember(Value = "Reporting_2")]
	Reporting
}
