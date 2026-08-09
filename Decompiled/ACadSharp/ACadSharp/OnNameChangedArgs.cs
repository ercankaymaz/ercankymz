using System;

namespace ACadSharp;

public class OnNameChangedArgs : EventArgs
{
	public string OldName { get; }

	public string NewName { get; }

	public OnNameChangedArgs(string oldName, string newName)
	{
		OldName = oldName;
		NewName = newName;
	}
}
