using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum DepthCutsRoughParamsApplyDepthMode
{
	DcApplyWholeTp,
	DcApplyFirstSliceOnly,
	DcApplyFirstPassOnly
}
