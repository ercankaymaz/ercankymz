using System;

namespace ModuleWorks;

[Serializable]
public enum VerifierSelectionMode
{
	NoSelection,
	PointSelection,
	DistanceSelection,
	ZoomBoxSelection,
	ChunkKeepSelection,
	ChunkDeleteSelection,
	DynamicZoomSelection
}
