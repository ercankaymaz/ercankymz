using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class EntityCommandArgs
{
	public string Command = "";

	public int ItemID = -1;

	public int EdgeIndex = -1;

	public int EntityOutsideIndex = -1;

	public int EntityInsideIndex = -1;

	public int EntityInsideSubIndex = -1;

	public string Info = "";

	public string Aux = "";

	public bool Result = false;
}
