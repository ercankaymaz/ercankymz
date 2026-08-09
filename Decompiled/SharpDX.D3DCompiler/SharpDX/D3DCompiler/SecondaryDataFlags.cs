using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum SecondaryDataFlags
{
	MergeUnorderedAccessViewSlots = 1,
	PreserveTemplateSlots = 2,
	RequireTemplateMatch = 4,
	None = 0
}
