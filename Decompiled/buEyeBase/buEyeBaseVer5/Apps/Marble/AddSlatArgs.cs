using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class AddSlatArgs
{
	public int IndexEntity = -1;

	public int IndexEdge = -1;

	public int ID = -1;

	public int EdgeID = -1;

	public int CamID = -1;

	public AddSlatArgs()
	{
	}

	public AddSlatArgs(int indexEntity, int indexEdge, int iD, int edgeID, int camID)
	{
		IndexEdge = indexEdge;
		IndexEntity = indexEntity;
		ID = iD;
		EdgeID = edgeID;
		CamID = camID;
	}
}
