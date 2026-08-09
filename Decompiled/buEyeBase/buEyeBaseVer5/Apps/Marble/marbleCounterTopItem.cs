using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCounterTopItem : buSerilization5
{
	public MarbleCountertopModes ItemMode = MarbleCountertopModes.None;

	public object ItemData = null;
}
