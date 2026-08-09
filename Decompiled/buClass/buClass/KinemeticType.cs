using System;

namespace buClass;

[Serializable]
public enum KinemeticType
{
	CartezianXY_2Axis,
	CartezianXYZ_3Axis,
	CartezianXYZ_WristA_4Axis,
	CartezianXYZ_WristB_4Axis,
	CartezianXYZ_WristC_4Axis,
	CartezianXYZ_TableA_4Axis,
	CartezianXYZ_TableB_4Axis,
	CartezianXYZ_TableC_4Axis,
	CartezianXYZ_WristAB_5Axis,
	CartezianXYZ_WristAC_5Axis,
	CartezianXYZ_WristBC_5Axis,
	CartezianXYZ_TableAB_5Axis,
	CartezianXYZ_TableAC_5Axis,
	CartezianXYZ_TableBC_5Axis
}
