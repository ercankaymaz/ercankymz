using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum BrokerTransportQualityOfService
{
	[EnumMember(Value = "NotSpecified_0")]
	NotSpecified,
	[EnumMember(Value = "BestEffort_1")]
	BestEffort,
	[EnumMember(Value = "AtLeastOnce_2")]
	AtLeastOnce,
	[EnumMember(Value = "AtMostOnce_3")]
	AtMostOnce,
	[EnumMember(Value = "ExactlyOnce_4")]
	ExactlyOnce
}
