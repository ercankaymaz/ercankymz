using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TpCalcMethodsParamsMethod
{
	TcmSurfaceBased = 0,
	TcmTriangleMeshBased = 1,
	TcmDrillingBased = 2,
	TcmWireframeBased = 3,
	TcmExistingToolpathBased = 4,
	TcmMultiBladePartsBased = 5,
	TcmSwarfMillingBased = 7,
	TcmPortMachiningBased = 8,
	TpcdTmbRotaryRough = 9,
	TpcdTmbRotaryFinish = 10,
	TpcdTmbRotary = 11,
	TcmMultiaxisRoughingBased = 12,
	TcmSawMachiningBased = 13,
	TcmOptic = 14,
	TcmTurning = 15,
	TcmRotaryMachiningBased = 16,
	TcmGeodesicMachiningBased = 17,
	TcmWeldingBased = 18,
	TcmOrthesisBased = 19,
	TcmCircularSawMachining = 20,
	TcmHammeringBased = 21,
	TcmAutomatic3Plus2AxisRoughing = 22,
	TcmTurnMillingBased = 23,
	TcmDeburringBased = 24,
	TcmSpeedShapeBased = 25,
	TcmAbrasiveCuttingBased = 26,
	TcmContouringBased = 27,
	TcmAdditive = 29,
	TcmRibMachining = 30,
	TcmKnifeGrindingMachining = 31,
	TcmHoleMakingBased = 32,
	TcmMultiAxisMoldAndDieBased = 33,
	TcmProbingBased = 34,
	TcmWireEdmBased = 35,
	TcmWafl = 37
}
