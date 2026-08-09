using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum RegisterComponentMaskFlags : byte
{
	All = 0xF,
	ComponentW = 8,
	ComponentX = 1,
	ComponentY = 2,
	ComponentZ = 4,
	None = 0
}
