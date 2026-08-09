using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class MacroItem : buSerilization5
{
	public planeNames ItemPlane = planeNames.Top;

	public CornerLocation Corner = CornerLocation.LeftTop;

	public ObjectAlignment Alignment = ObjectAlignment.MiddleCenter;

	public ShapeTypes ItemType = ShapeTypes.Rectangle;

	public UpDownLocationType UpDown = UpDownLocationType.Up;

	public FrontBackType FrontBack = FrontBackType.Front;

	public ProfileNotchOperationType NotchOPType = ProfileNotchOperationType.Side;

	public double NotchStart = 10.0;

	public Point3D BasePoint = new Point3D();

	public double Diameter = 10.0;

	public double Width = 20.0;

	public double Height = 20.0;

	public double Depth = 5.0;

	public double Radius = 0.0;

	public double Length = 20.0;

	public double Angle = 0.0;

	public int Side = 6;

	public bool ManuelZ = false;

	public string Option1 = "";

	public string Option2 = "";

	public string Option3 = "";

	public string Option4 = "";

	public MacroItem()
	{
	}

	public MacroItem(MacroItem data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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
}
