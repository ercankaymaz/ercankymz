using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public enum MarbleOperationSelectionCommand
{
	None,
	Item,
	Operation,
	Wire,
	WireItem,
	Tool,
	Parameter,
	Cam,
	Panel,
	EdgeOutside,
	EdgeInside,
	WireOutsideItem,
	WireInsideItem,
	CamNode,
	ShapeInside,
	Message,
	CamList,
	CamListNode
}
