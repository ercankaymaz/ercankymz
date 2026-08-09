using System;

namespace buClass;

[Serializable]
public enum CamWireFrameType
{
	None,
	Contour,
	Pocket,
	FloorFinish,
	Engrave,
	TextEngrave,
	Chamfer2D,
	Face,
	Trochoidal,
	CenterPath,
	Profile3Axis,
	Profile5Axis
}
