using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class AddCollapseArgs
{
	public int IndexInsideEntity = -1;

	public int ItemID = -1;

	public AddCollapseArgs()
	{
	}

	public AddCollapseArgs(int indexInsideEntity, int itemID)
	{
		IndexInsideEntity = indexInsideEntity;
		ItemID = itemID;
	}
}
