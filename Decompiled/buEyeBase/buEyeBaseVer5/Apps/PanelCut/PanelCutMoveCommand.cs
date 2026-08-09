using System;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public enum PanelCutMoveCommand
{
	AxisMove,
	SawUp,
	SawDown,
	Finished,
	ClamperOn,
	ClamperOff,
	SideReclaimOn,
	SideReclaimOff,
	FrontReclaimOn,
	FrontReclaimOff,
	CutMaterial,
	AddMaterial,
	RemoveMaterial,
	PartFinished
}
