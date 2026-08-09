using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public enum MarbleHMICommands
{
	None,
	ShowWarning,
	CNCParameterUpdate,
	ToolPage,
	KinematicPage,
	G54Page,
	G54PagePre,
	G54Set,
	AbsolutePage,
	AbsoluteSet,
	SettingsChanged,
	SaveCNCParameter,
	UpdateMarbleCamParametersFromControls,
	ParameterUpdate,
	StatusUpdate,
	MillingToolZero,
	MillingHeadToolZero,
	ToolSetActive,
	ToolChange,
	DoorOpen,
	DoorClose,
	MagazineOpen,
	MagazineClose,
	PensOpen,
	PensClose,
	HideWarning,
	MaterialUpdate,
	SaveCamParameter,
	JobUpdate,
	SelectionUpdate,
	MoveMouse
}
