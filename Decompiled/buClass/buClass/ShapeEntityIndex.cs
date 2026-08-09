using System;

namespace buClass;

[Serializable]
public class ShapeEntityIndex : buSerilization
{
	public int indexEntitySub = -1;

	public int indexEntity = -1;

	public int indexCam = -1;

	public int indexInside = -1;

	public int CamID = -1;

	public int ItemID = -1;

	public int EdgeID = -1;

	public int indexEdge = -1;

	public bool Outside = false;

	public int ID = -1;

	public double Value = 0.0;

	public ShapeEntityIndex()
	{
	}

	public ShapeEntityIndex(int indexentitysub, int indexentity)
	{
		indexEntitySub = indexentitysub;
		indexEntity = indexentity;
	}

	public ShapeEntityIndex(int indexentitysub, int indexentity, int id, bool outside)
	{
		indexEntitySub = indexentitysub;
		indexEntity = indexentity;
		Outside = outside;
		ID = id;
	}

	public ShapeEntityIndex(int indexentitysub, int indexentity, int id, bool outside, double value)
	{
		indexEntitySub = indexentitysub;
		indexEntity = indexentity;
		Outside = outside;
		ID = id;
		Value = value;
	}

	public ShapeEntityIndex(int indexentitysub, int indexentity, int id, bool outside, double value, int indexedge)
	{
		indexEntitySub = indexentitysub;
		indexEntity = indexentity;
		Outside = outside;
		ID = id;
		Value = value;
		indexEdge = indexedge;
	}

	public ShapeEntityIndex(int indexentitysub, int indexentity, int id, bool outside, double value, int indexedge, int indexcam)
	{
		indexEntitySub = indexentitysub;
		indexEntity = indexentity;
		Outside = outside;
		ID = id;
		Value = value;
		indexEdge = indexedge;
		indexCam = indexcam;
	}

	public override string ToString()
	{
		return "Entity: " + indexEntity + " - EntitySub: " + indexEntitySub;
	}
}
