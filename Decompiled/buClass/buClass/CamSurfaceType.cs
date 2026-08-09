using System;

namespace buClass;

[Serializable]
public enum CamSurfaceType
{
	SurfaceParalel = 0,
	MeshParalel = 1,
	MeshConstantZ = 2,
	MeshRough = 3,
	None = 999
}
