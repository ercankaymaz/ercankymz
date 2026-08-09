using System;
using buClass;

namespace buControls.Components.Marble;

[Serializable]
public class ItemCommandEventArgs
{
	public MarbleOperationMenuCommands Command = MarbleOperationMenuCommands.None;

	public int OperationIndex = -1;

	public bool Enable = false;

	public bool Selected = false;

	public int OperationID = -1;

	public int IndexControl = -1;

	public ItemCommandEventArgs()
	{
	}

	public ItemCommandEventArgs(MarbleOperationMenuCommands command, int operationIndex, bool enable, int operationID, int indexControl, bool selected)
	{
		Command = command;
		OperationIndex = operationIndex;
		Enable = enable;
		OperationID = operationID;
		IndexControl = indexControl;
		Selected = selected;
	}
}
