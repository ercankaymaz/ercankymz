using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum UserDefinedParamsParamType
{
	UdpPtBool,
	UdpPtInt,
	UdpPtDouble,
	UdpPtString,
	UdpPtVectord,
	UdpPtVectordList,
	UdpPtBoolList,
	UdpPtIntList,
	UdpPtDoubleList,
	UdpPtStringList
}
