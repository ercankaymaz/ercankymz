using System;

namespace buClass;

[Serializable]
public enum CamTriangularMeshType
{
	Rough = 0,
	ParallelCuts = 1,
	ProjectCurves = 2,
	ConstantZ = 3,
	ConstantCusp = 4,
	Flatlands = 5,
	Pencil = 6,
	Geodesic = 7,
	Projection = 8,
	RotaryRough = 9,
	RotaryFinish = 10,
	Rotary = 11,
	Trochoidal = 12,
	ConstantZPlusConstantCusp = 13,
	ConstantZPlusParallelCuts = 14,
	Rough3Plus2 = 15,
	ProjectionAround = 16,
	ProjectionAlong = 17,
	None = 999
}
