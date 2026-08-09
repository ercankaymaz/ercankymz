using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum FeedRateDefinition
{
	userDefined,
	basedOnStockMaterialAndTool
}
