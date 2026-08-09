using System;

namespace buClass;

[Serializable]
public class ShortCutKey : buSerilization
{
	public ControlKeys FirstControlKey = ControlKeys.None;

	public ControlKeys SecondControlKey = ControlKeys.None;

	public ActionKeys Key = ActionKeys.KeyNone;

	public string Command = "None";

	public ShortCutKey()
	{
	}

	public ShortCutKey(ControlKeys FirstControl, ControlKeys SecondControl, ActionKeys key, string command)
	{
		Command = command;
		FirstControlKey = FirstControl;
		SecondControlKey = SecondControl;
		Key = key;
	}

	public override string ToString()
	{
		return FirstControlKey.ToString() + " + " + SecondControlKey.ToString() + " + " + Key.ToString() + " = " + Command.ToString();
	}
}
