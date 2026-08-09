using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum TsnFailureCode
{
	[EnumMember(Value = "NoFailure_0")]
	NoFailure,
	[EnumMember(Value = "InsufficientBandwidth_1")]
	InsufficientBandwidth,
	[EnumMember(Value = "InsufficientResources_2")]
	InsufficientResources,
	[EnumMember(Value = "InsufficientTrafficClassBandwidth_3")]
	InsufficientTrafficClassBandwidth,
	[EnumMember(Value = "StreamIdInUse_4")]
	StreamIdInUse,
	[EnumMember(Value = "StreamDestinationAddressInUse_5")]
	StreamDestinationAddressInUse,
	[EnumMember(Value = "StreamPreemptedByHigherRank_6")]
	StreamPreemptedByHigherRank,
	[EnumMember(Value = "LatencyHasChanged_7")]
	LatencyHasChanged,
	[EnumMember(Value = "EgressPortNotAvbCapable_8")]
	EgressPortNotAvbCapable,
	[EnumMember(Value = "UseDifferentDestinationAddress_9")]
	UseDifferentDestinationAddress,
	[EnumMember(Value = "OutOfMsrpResources_10")]
	OutOfMsrpResources,
	[EnumMember(Value = "OutOfMmrpResources_11")]
	OutOfMmrpResources,
	[EnumMember(Value = "CannotStoreDestinationAddress_12")]
	CannotStoreDestinationAddress,
	[EnumMember(Value = "PriorityIsNotAnSrcClass_13")]
	PriorityIsNotAnSrcClass,
	[EnumMember(Value = "MaxFrameSizeTooLarge_14")]
	MaxFrameSizeTooLarge,
	[EnumMember(Value = "MaxFanInPortsLimitReached_15")]
	MaxFanInPortsLimitReached,
	[EnumMember(Value = "FirstValueChangedForStreamId_16")]
	FirstValueChangedForStreamId,
	[EnumMember(Value = "VlanBlockedOnEgress_17")]
	VlanBlockedOnEgress,
	[EnumMember(Value = "VlanTaggingDisabledOnEgress_18")]
	VlanTaggingDisabledOnEgress,
	[EnumMember(Value = "SrClassPriorityMismatch_19")]
	SrClassPriorityMismatch,
	[EnumMember(Value = "FeatureNotPropagated_20")]
	FeatureNotPropagated,
	[EnumMember(Value = "MaxLatencyExceeded_21")]
	MaxLatencyExceeded,
	[EnumMember(Value = "BridgeDoesNotProvideNetworkId_22")]
	BridgeDoesNotProvideNetworkId,
	[EnumMember(Value = "StreamTransformNotSupported_23")]
	StreamTransformNotSupported,
	[EnumMember(Value = "StreamIdTypeNotSupported_24")]
	StreamIdTypeNotSupported,
	[EnumMember(Value = "FeatureNotSupported_25")]
	FeatureNotSupported
}
