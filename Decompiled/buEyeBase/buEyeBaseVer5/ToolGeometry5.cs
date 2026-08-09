using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ToolGeometry5 : buSerilization5
{
	public double Diameter = 2.0;

	public double SocketThickness = 4.0;

	public double DiameterLeft = 10.0;

	public double DiameterRight = 10.0;

	public double DiameterBody = 10.0;

	public double ShoulderThickness = 0.0;

	public double ShoulderDiameter = 0.0;

	public double ShoulderLength = 0.0;

	public double BottomDiameter = 10.0;

	public double TopDiameter = 10.0;

	public double RoundRadius = 2.0;

	public double Length = 50.0;

	public double TotalLength = 0.0;

	public double LengthLeft = 50.0;

	public double LengthRigth = 50.0;

	public double LengthDiameter = 10.0;

	public double CutLength = 20.0;

	public double CutLengthLeft = 20.0;

	public double CutLengthRight = 20.0;

	public double ArborLength = 50.0;

	public double ArborTopDiameter = 78.0;

	public double ArborBottomDiameter = 45.0;

	public double HolderLength = 30.0;

	public double HolderDiameter = 100.0;

	public double HolderInDiameter = 90.0;

	public double TaperAngle = 8.0;

	public double LowerRadius = 2.0;

	public double UpperRadius = 2.0;

	public double UpperDiameter = 10.0;

	public double ProfileRadius = 12.0;

	public double OutsideDiameter = 10.0;

	public double ProfileDiameter = 10.0;

	public double MaxDiameter = 10.0;

	public double FlatnessDiameter = 0.0;

	public double ConvexTipRadius = 2.0;

	public double Thickness = 4.0;

	public double MinLength = 0.0;

	public double SizeWidth = 0.0;

	public double SizeDepth = 0.0;

	public double SizeHeight = 0.0;

	public double PositionAngle = 0.0;

	public bool AddHalfOfToolThicknessToDistance = true;

	public Vec3D PlaneDirection = new Vec3D(0.0, 0.0, 1.0);

	public Vec3D ToolDirection = new Vec3D(0.0, 0.0, -1.0);

	public Vec3D DistanceForOrientation = new Vec3D(0.0, 0.0, 0.0);

	public ToolType GeometryType = ToolType.Flat;

	public ToolFlatGeometryType FlatGeometry = ToolFlatGeometryType.None;

	public ToolCornerRadiusType CornerRadiusType = ToolCornerRadiusType.None;

	public bool LengthReverseDirection = false;

	public bool DrawHolder = true;

	public bool DrawArbor = true;

	public bool DrawLength = true;

	public bool AgregateLeftEnable = true;

	public bool AgregateRightEnable = true;

	public double AgregateVerticalLength = 150.0;

	public double AgregateToolCenterLength = 100.0;

	public bool AgregateCircleBody = true;

	public bool FromFileEnable = false;

	public string FromFileFileName = Application.StartupPath;

	public double FromFileAngle = 0.0;

	public List<Pnt3D> ArborPoints = new List<Pnt3D>
	{
		new Pnt3D(0.0, 0.0),
		new Pnt3D(15.0, 0.0),
		new Pnt3D(17.5, 8.0),
		new Pnt3D(17.5, 25.0),
		new Pnt3D(20.0, 30.0),
		new Pnt3D(0.0, 30.0)
	};

	public List<Pnt3D> HolderPoints = new List<Pnt3D>
	{
		new Pnt3D(0.0, 0.0),
		new Pnt3D(30.0, 0.0),
		new Pnt3D(30.0, 4.0),
		new Pnt3D(25.0, 8.0),
		new Pnt3D(25.0, 28.0),
		new Pnt3D(30.0, 32.0),
		new Pnt3D(30.0, 36.0),
		new Pnt3D(0.0, 36.0)
	};

	public ToolGeometry5()
	{
	}

	public ToolGeometry5(ToolGeometry5 geo)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(geo, ref CopiedClass);
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

	public ToolGeometry5(ToolGeometry geo)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(geo, ref CopiedClass);
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

	public override string ToString()
	{
		return GeometryType.ToString() + " - Dia: " + Diameter + " - Len: " + Length + " - Thickness: " + Thickness;
	}
}
