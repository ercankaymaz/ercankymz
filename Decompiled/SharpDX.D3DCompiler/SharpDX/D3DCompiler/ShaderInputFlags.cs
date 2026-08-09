using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum ShaderInputFlags
{
	Userpacked = 1,
	ComparisonSampler = 2,
	TextureComponent0 = 4,
	TextureComponent1 = 8,
	TextureComponents = 0xC,
	Unused = 0x10,
	None = 0
}
