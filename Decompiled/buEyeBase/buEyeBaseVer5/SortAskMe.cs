using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class SortAskMe : buSerilization5
{
	public bool Return = false;

	public bool ReturnNextGroup = false;

	public bool GetBack = false;

	public bool GetBackFromMultiSelection = false;

	public int SelectedIndex = 0;

	public Point3D CatchPoint = new Point3D();

	public List<int> EntitiesIndex = new List<int>();

	public List<Entity> FoundEntities = new List<Entity>();

	public List<Entity> SortedEntities = new List<Entity>();

	public List<Entity> TempEntities = new List<Entity>();

	public List<List<Entity>> RemovedEntities = new List<List<Entity>>();

	public List<Point3D> LastMarkPosition = new List<Point3D>();
}
