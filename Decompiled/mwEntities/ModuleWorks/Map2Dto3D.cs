using System;

namespace ModuleWorks;

[Serializable]
[Obsolete("Deprecated since Release 2021.08. Refer to MeshHelper.ExtrudeContour for details.")]
public enum Map2Dto3D
{
	XYtoXYZ,
	XYtoXZY,
	XYtoYZX
}
