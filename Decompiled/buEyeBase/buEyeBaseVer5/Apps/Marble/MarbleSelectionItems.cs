using System;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleSelectionItems
{
	public int ItemID = -1;

	public int indexItem = -1;

	public int indexCam = -1;

	public int indexEdge = -1;

	public int indexEdgeSub = -1;

	public int indexCamList = -1;

	public Point3D pntMin = new Point3D();

	public Point3D pntMax = new Point3D();

	public MarbleItem MI = null;

	public MarbleOperationSelectionCommand SelectionCommand = MarbleOperationSelectionCommand.None;
}
