using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsPattern
{
	TcTmbRough,
	TcTmbParallelCuts,
	TcTmbProjectCurves,
	TcTmbConstantZ,
	TcTmbConstantCusp,
	TcTmbFlatlands,
	TcTmbPencil,
	[Obsolete("Deprecated since 2025.12. Please use TpCalcMethodsParamsMethod::TcmGeodesicMachiningBased instead of TpCalcMethodsParamsMethod::TcmTriangleMeshBased with TcTmbGeodesic.")]
	TcTmbGeodesic,
	TcTmbProjection,
	TcbTmbRotaryRough,
	TcbTmbRotaryFinish,
	TcbTmbRotary,
	TcTmbTrochoidal,
	TcTmbConstantZPlusConstantCusp,
	TcTmbConstantZPlusParallelCuts
}
