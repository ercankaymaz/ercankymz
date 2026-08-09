using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class SortOptions : buSerilization5
{
	public double Resolution = 0.001;

	public bool UsePlane = false;

	public bool UseCamSelectedProps = false;

	public bool UseEntitySelectedProps = false;

	public bool UseStopPoint = false;

	public bool isFirstPointCatchFromStartPointForDrawSequence = false;

	public bool WhenFoundClosedCurveThenFinish = false;

	public Point3D StartPoint = new Point3D();

	public Point3D EndPoint = new Point3D();

	public Point3D StopPoint = null;

	public Point3D ConstantPoint = new Point3D();

	public bool AlwaysUseZeroPointAfterJump = false;

	public bool If2PointAtFirstPointUseSecondOne = false;

	public SortingIntersectionRulesType IntersectionRules = SortingIntersectionRulesType.LowerIndex;

	public SortingNextGroupFindRulesType NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;

	public SortingFirstCatchRulesType FirstRules = SortingFirstCatchRulesType.LowerIndex;

	public bool AngleLimitation = false;

	public bool UseBoxBoundingForMinMax = false;

	public double AngleMinLimit = -360.0;

	public double AngleMaxLimit = 360.0;

	public List<Point3D> ClickList = new List<Point3D>();

	public SortOptions()
	{
	}

	public SortOptions(SortOptions data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		if (data.StartPoint != null)
		{
			StartPoint = new Point3D(data.StartPoint.X, data.StartPoint.Y, data.StartPoint.Z);
		}
		if (data.EndPoint != null)
		{
			EndPoint = new Point3D(data.EndPoint.X, data.EndPoint.Y, data.EndPoint.Z);
		}
		if (data.StopPoint != null)
		{
			StopPoint = new Point3D(data.StopPoint.X, data.StopPoint.Y, data.StopPoint.Z);
		}
		if (data.ConstantPoint != null)
		{
			ConstantPoint = new Point3D(data.ConstantPoint.X, data.ConstantPoint.Y, data.ConstantPoint.Z);
		}
		ClickList = new List<Point3D>();
		for (int j = 0; j <= data.ClickList.Count - 1; j++)
		{
			ClickList.Add(new Point3D(data.ClickList[j].X, data.ClickList[j].Y, data.ClickList[j].Z));
		}
	}
}
