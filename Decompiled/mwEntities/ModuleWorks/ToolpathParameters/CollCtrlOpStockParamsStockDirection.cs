using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum CollCtrlOpStockParamsStockDirection
{
	StDirectionInX = 0,
	StDirectionInY = 1,
	StDirectionInZ = 2,
	StDirectionCustomDefined = 4,
	StDirectionMachiningDirection = 5
}
