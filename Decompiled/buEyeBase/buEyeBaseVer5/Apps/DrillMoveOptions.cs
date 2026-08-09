using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillMoveOptions : buSerilization5
{
	public int Tool1 = 0;

	public int Tool2 = 0;

	public int Tool3 = 0;

	public int Tool4 = 0;

	public int Tool5 = 0;

	public int Tool6 = 0;

	public int Tool7 = 0;

	public int Tool8 = 0;

	public int Tool9 = 0;

	public int Tool10 = 0;

	public int Tool11 = 0;

	public int Tool12 = 0;

	public double DevideLen = 10.0;

	public double Feed = 0.0;

	public double ClamperMove = 0.0;

	public AxesEnable EnableAxes = new AxesEnable();

	public bool isG0 = true;

	public bool OnlyCode = false;

	public bool AddAxesCode = false;

	public Point3D pntCenter = null;

	public drillPlaneNames Plane = drillPlaneNames.Top;

	public DrillCNCMode Mode = DrillCNCMode.None;

	public DrillMoveAddType AddType = DrillMoveAddType.BothMoveAndSimulation;

	public DrillMoveCommand Cmd1 = DrillMoveCommand.None;

	public DrillMoveCommand Cmd2 = DrillMoveCommand.None;

	public DrillMoveCommand Cmd3 = DrillMoveCommand.None;

	public DrillMoveOptions()
	{
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode)
	{
		Plane = plane;
		Mode = mode;
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode, DrillMoveAddType addType)
	{
		Plane = plane;
		Mode = mode;
		AddType = addType;
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode, int t1)
	{
		Plane = plane;
		Mode = mode;
		Tool1 = t1;
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode, int t1, int t2)
	{
		Plane = plane;
		Mode = mode;
		Tool1 = t1;
		Tool2 = t2;
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode, int t1, int t2, int t3, int t4)
	{
		Plane = plane;
		Mode = mode;
		Tool1 = t1;
		Tool2 = t2;
		Tool3 = t3;
		Tool4 = t4;
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode, DrillMoveAddType addType, int t1, int t2, int t3, int t4, int t5, int t6)
	{
		Plane = plane;
		Mode = mode;
		AddType = addType;
		Tool1 = t1;
		Tool2 = t2;
		Tool3 = t3;
		Tool4 = t4;
		Tool5 = t5;
		Tool6 = t6;
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode, DrillMoveAddType addType, int t1, int t2, int t3, int t4, int t5, int t6, DrillMoveCommand Cmd2, DrillMoveCommand Cmd3)
	{
		Plane = plane;
		Mode = mode;
		AddType = addType;
		Tool1 = t1;
		Tool2 = t2;
		Tool3 = t3;
		Tool4 = t4;
		Tool5 = t5;
		Tool6 = t6;
		this.Cmd2 = Cmd2;
		this.Cmd3 = Cmd3;
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode, DrillMoveAddType addType, int t1, int t2, int t3, int t4, int t5, int t6, int t7, int t8, int t9, int t10, int t11, int t12)
	{
		Plane = plane;
		Mode = mode;
		AddType = addType;
		Tool1 = t1;
		Tool2 = t2;
		Tool3 = t3;
		Tool4 = t4;
		Tool5 = t5;
		Tool6 = t6;
		Tool7 = t7;
		Tool8 = t8;
		Tool9 = t9;
		Tool10 = t10;
		Tool11 = t11;
		Tool12 = t12;
	}

	public DrillMoveOptions(drillPlaneNames plane, DrillCNCMode mode, DrillMoveAddType addType, int t1, int t2, int t3, int t4, int t5, int t6, int t7, int t8, int t9, int t10, int t11, int t12, DrillMoveCommand Cmd2, DrillMoveCommand Cmd3)
	{
		Plane = plane;
		Mode = mode;
		AddType = addType;
		Tool1 = t1;
		Tool2 = t2;
		Tool3 = t3;
		Tool4 = t4;
		Tool5 = t5;
		Tool6 = t6;
		Tool7 = t7;
		Tool8 = t8;
		Tool9 = t9;
		Tool10 = t10;
		Tool11 = t11;
		Tool12 = t12;
		this.Cmd2 = Cmd2;
		this.Cmd3 = Cmd3;
	}

	public DrillMoveOptions(DrillMoveOptions data)
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

	public override string ToString()
	{
		string text = Plane.ToString() + " , Mode: " + Mode.ToString() + " , AddType : " + AddType;
		if (Tool1 > 0)
		{
			text = text + ", T1: " + Tool1;
		}
		if (Tool2 > 0)
		{
			text = text + ", T2: " + Tool2;
		}
		if (Tool3 > 0)
		{
			text = text + ", T3: " + Tool3;
		}
		if (Tool4 > 0)
		{
			text = text + ", T4: " + Tool4;
		}
		if (Tool5 > 0)
		{
			text = text + ", T5: " + Tool5;
		}
		if (Tool6 > 0)
		{
			text = text + ", T6: " + Tool6;
		}
		if (Tool7 > 0)
		{
			text = text + ", T7: " + Tool7;
		}
		if (Tool8 > 0)
		{
			text = text + ", T8: " + Tool8;
		}
		if (Tool9 > 0)
		{
			text = text + ", T9: " + Tool9;
		}
		if (Tool10 > 0)
		{
			text = text + ", T10: " + Tool10;
		}
		if (Tool11 > 0)
		{
			text = text + ", T11: " + Tool11;
		}
		if (Tool12 > 0)
		{
			text = text + ", T12: " + Tool12;
		}
		return text;
	}
}
