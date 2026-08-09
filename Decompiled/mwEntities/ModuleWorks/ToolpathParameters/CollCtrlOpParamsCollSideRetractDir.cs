using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum CollCtrlOpParamsCollSideRetractDir
{
	AvoidByRetractInZ,
	AvoidByRetractInXy,
	AvoidByRetractInXz,
	AvoidByRetractInYz,
	AvoidByRetractInZMin,
	AvoidByRetractInX,
	AvoidByRetractInXMin,
	AvoidByRetractInY,
	AvoidByRetractInYMin,
	AvoidByRetractAlongSurfNorm,
	AvoidByRetractAwayFromOrigin,
	AvoidByRetractMoveToCenterOfCont,
	AvoidByRetractOptInXy,
	AvoidByRetractOptInXz,
	AvoidByRetractOptInYz,
	AvoidByRetractInCustomDir,
	AvoidByRetractAlongToolContactLine,
	AvoidByRetractAwayFromContactLine,
	AvoidByRetractAlongToolBottomPlane
}
