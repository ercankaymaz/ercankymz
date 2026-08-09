using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class DrillItemBase : buSerilization5
{
	public string ItemName = "";

	public Vector3D CornerDirection = new Vector3D(0.0, 0.0, 1.0);

	public planeBoxNames planeName = planeBoxNames.Top;

	public DrillItemType Type = DrillItemType.Drill;

	public drillCommands Command = drillCommands.SingleHole;

	public CornerLocation Corner = CornerLocation.RightTop;

	public ShapeTypes ShapeType = ShapeTypes.Rectangle;

	public DrillProfilingType ProfilingType = DrillProfilingType.CornerRectangle;

	public Plane planeOperation = new Plane();

	public int HorizontalCount = 0;

	public int VerticalCount = 0;

	public double HorizontalDistance = 0.0;

	public double VerticalDistance = 0.0;

	public double StartDistance = 0.0;

	public double EndDistance = 0.0;

	public Point3D BaseCenter = new Point3D();

	public Point3D BoxBoundingMin = new Point3D(0.0, 0.0, 0.0);

	public Point3D BoxBoundingMax = new Point3D(0.0, 0.0, 0.0);

	public Point3D CornerPoint = new Point3D(0.0, 0.0, 0.0);

	public int ID = -1;

	public int Index = -1;

	public DrillShapeData ShapeCommonData = new DrillShapeData();

	public DrillRuntimeSettings Parameter = new DrillRuntimeSettings();

	public List<DrillItem> Items = new List<DrillItem>();

	public DrillItemBase()
	{
	}

	public DrillItemBase(DrillItemBase data)
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
		CornerDirection = new Vector3D(data.CornerDirection.X, data.CornerDirection.Y, data.CornerDirection.Z);
		BaseCenter = new Point3D(data.BaseCenter.X, data.BaseCenter.Y, data.BaseCenter.Z);
		planeOperation = (Plane)data.planeOperation.Clone();
		DrillItem.Copy(data.Items, ref Items);
		ShapeCommonData = new DrillShapeData(data.ShapeCommonData);
		Parameter = new DrillRuntimeSettings(data.Parameter);
	}

	public static void Copy(List<DrillItemBase> refItem, ref List<DrillItemBase> copyItem)
	{
		copyItem = new List<DrillItemBase>();
		for (int i = 0; i <= refItem.Count - 1; i++)
		{
			copyItem.Add(new DrillItemBase(refItem[i]));
		}
	}

	public override string ToString()
	{
		return Type.ToString() + " - " + planeName;
	}
}
