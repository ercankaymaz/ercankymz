using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum ShaderVariableFlags
{
	Userpacked = 1,
	Used = 2,
	InterfacePointer = 4,
	InterfaceParameter = 8,
	None = 0
}
