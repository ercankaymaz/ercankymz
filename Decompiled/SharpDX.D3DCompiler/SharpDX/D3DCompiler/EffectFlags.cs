using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum EffectFlags
{
	ChildEffect = 1,
	AllowSlowOperations = 2,
	None = 0
}
