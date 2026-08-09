using System;

namespace ACadSharp.Header;

[Flags]
public enum IndexCreationFlags : byte
{
	NoIndex = 0,
	LayerIndex = 1,
	SpatialIndex = 2,
	LayerAndSpatialIndex = 3
}
