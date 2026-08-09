using System;

namespace ModuleWorks;

[Serializable]
public enum WorkpieceDrawMode
{
	Solid,
	Deviation,
	Tool,
	Operation,
	ToolPathSegmentLength,
	HeightChange,
	OrientationChange,
	Chunks,
	Texture,
	TexturePlusCollisions,
	TargetId,
	GougeExcess,
	RemovedMaterial,
	DeviationOffset,
	OperationType,
	ClimbAndConventional,
	RemovedVolume,
	Reserved1,
	Reserved2,
	NotInitialized
}
