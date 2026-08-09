using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum StripFlags
{
	CompilerStripReflectionData = 1,
	CompilerStripDebugInformation = 2,
	CompilerStripTestBlobs = 4,
	CompilerStripPrivateData = 8,
	CompilerStripRootSignature = 0x10,
	None = 0
}
