using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum CollCtrlOpParamsCollAvoidTiltDir
{
	AvoidByLeadlag,
	AvoidBySidetilt,
	AvoidByLeadlagAndSidetilt,
	AvoidByRotateAroundX,
	AvoidByRotateAroundY,
	AvoidByRotateAroundZ,
	AvoidByChangeFixedTiltAng,
	Conversion3To5Axis,
	Conversion3To3Plus2Axis,
	AvoidAutomatic
}
