using System;
using System.Collections.Generic;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class SortbuAskMe : buSerilization5
{
	public bool Return = false;

	public bool ReturnNextGroup = false;

	public bool GetBack = false;

	public bool GetBackFromMultiSelection = false;

	public bool isPointOnEntity = false;

	public int SelectedIndex = 0;

	public Point3D CatchPoint = new Point3D();

	public List<int> FoundEntitiesIndex = new List<int>();

	public List<string> FoundEntitiesID = new List<string>();

	public List<buEntity> FoundEntities = new List<buEntity>();

	public List<buEntity> SortedEntities = new List<buEntity>();

	public List<buEntity> TempEntities = new List<buEntity>();

	public List<List<buEntity>> RemovedEntities = new List<List<buEntity>>();

	public List<Point3D> LastMarkPosition = new List<Point3D>();
}
