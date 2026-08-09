using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleSelection
{
	public List<MarbleSelectionItems> SelectionItems = new List<MarbleSelectionItems>();

	public MarbleSelectionItems ActiveItem = new MarbleSelectionItems();

	public Point3D pntTotalMin = new Point3D();

	public Point3D pntTotalMax = new Point3D();
}
