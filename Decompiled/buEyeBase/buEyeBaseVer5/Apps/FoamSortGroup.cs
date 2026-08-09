using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamSortGroup : buSerilization5
{
	public FoamPlaneType PlaneType = FoamPlaneType.XZ;

	public NormalReverse Direction = NormalReverse.Normal;

	public List<List<buEntity>> sortEntities = new List<List<buEntity>>();

	public Point3D MinPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public FoamSortGroup()
	{
	}

	public FoamSortGroup(FoamSortGroup data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null)
		{
			if (GetType() == CopiedClass.GetType())
			{
				FieldInfo[] fields = GetType().GetFields();
				if (fields != null)
				{
					for (int i = 0; i <= fields.Length - 1; i++)
					{
						_ = fields[i].Name;
						object value = fields[i].GetValue(CopiedClass);
						fields[i].SetValue(this, value);
					}
				}
			}
			MinPoint = buVector5.ToPoint3D(data.MinPoint);
			MaxPoint = buVector5.ToPoint3D(data.MaxPoint);
		}
		buEntity.Copy(data.sortEntities, ref sortEntities);
	}

	public override string ToString()
	{
		string text = "";
		string text2 = "";
		if (sortEntities.Count > 0)
		{
			buEntity buEntity2 = sortEntities[0][0];
			if (buEntity2.sortDirection != entitySortDirection.Normal)
			{
				if (PlaneType == FoamPlaneType.XZ)
				{
					text = " - SP- X: " + buEntity2.EndPoint.X.ToString("f1") + " , Z: " + buEntity2.EndPoint.Z.ToString("f1");
				}
				if (PlaneType == FoamPlaneType.YZ)
				{
					text = " - SP- Y: " + buEntity2.EndPoint.Y.ToString("f1") + " , Z: " + buEntity2.EndPoint.Z.ToString("f1");
				}
			}
			else
			{
				if (PlaneType == FoamPlaneType.XZ)
				{
					text = " - SP- X: " + buEntity2.StartPoint.X.ToString("f1") + " , Z: " + buEntity2.StartPoint.Z.ToString("f1");
				}
				if (PlaneType == FoamPlaneType.YZ)
				{
					text = " - SP- Y: " + buEntity2.StartPoint.Y.ToString("f1") + " , Z: " + buEntity2.StartPoint.Z.ToString("f1");
				}
			}
			buEntity buEntity3 = sortEntities[sortEntities.Count - 1][sortEntities[sortEntities.Count - 1].Count - 1];
			if (buEntity3.sortDirection != entitySortDirection.Normal)
			{
				if (PlaneType == FoamPlaneType.XZ)
				{
					text2 = " | EP- X: " + buEntity3.StartPoint.X.ToString("f1") + " , Z: " + buEntity2.StartPoint.Z.ToString("f1");
				}
				if (PlaneType == FoamPlaneType.YZ)
				{
					text2 = " | EP- Y: " + buEntity3.StartPoint.Y.ToString("f1") + " , Z: " + buEntity2.StartPoint.Z.ToString("f1");
				}
			}
			else
			{
				if (PlaneType == FoamPlaneType.XZ)
				{
					text2 = " | EP- X: " + buEntity3.EndPoint.X.ToString("f1") + " , Z: " + buEntity2.EndPoint.Z.ToString("f1");
				}
				if (PlaneType == FoamPlaneType.YZ)
				{
					text2 = " | EP- Y: " + buEntity3.EndPoint.Y.ToString("f1") + " , Z: " + buEntity2.EndPoint.Z.ToString("f1");
				}
			}
		}
		return Direction.ToString() + " - Cnt: " + sortEntities.Count + text + text2;
	}
}
