using System;
using System.Collections.Generic;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class SortbuResult : buSerilization5
{
	public Point3D FirstPoint = new Point3D();

	public Point3D LastPoint = new Point3D();

	public SortingResultType ResultType = SortingResultType.None;

	public List<int> SelectedEntitiesIndex = new List<int>();

	public List<buEntity> LastCalculatedEntities = new List<buEntity>();

	public List<buEntity> AskMeEntites = new List<buEntity>();

	public List<int> LastSelectedEntitiesIndex = new List<int>();
}
