using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum HoleMakingSharedParamsOrderingMode
{
	userDefined,
	bottomLeftStartHorizontalZig,
	bottomLeftStartHorizontalZigZag,
	bottomLeftStartVerticalZig,
	bottomLeftStartVerticalZigZag,
	upperLeftStartHorizontalZig,
	upperLeftStartHorizontalZigZag,
	upperLeftStartVerticalZig,
	upperLeftStartVerticalZigZag,
	bottomRightStartHorizontalZig,
	bottomRightStartHorizontalZigZag,
	bottomRightStartVerticalZig,
	bottomRightStartVerticalZigZag,
	upperRightStartHorizontalZig,
	upperRightStartHorizontalZigZag,
	upperRightStartVerticalZig,
	upperRightStartVerticalZigZag,
	shortestWay
}
