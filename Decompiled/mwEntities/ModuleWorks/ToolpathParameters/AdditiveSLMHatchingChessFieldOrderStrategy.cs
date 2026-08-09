using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AdditiveSLMHatchingChessFieldOrderStrategy
{
	LineBased,
	FieldBased,
	SpiralIn,
	SpiralOut,
	LastType
}
