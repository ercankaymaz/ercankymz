using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5;
using devDept.Geometry;

namespace buMarble;

[Serializable]
public class clsAppMarbleRuntimeVar : buSerilization5
{
	public bool isMainTab = true;

	public bool isSingleTab = false;

	public bool isHorizontalTab = false;

	public bool isVerticalTab = false;

	public bool isDryRunActivated = false;

	public bool isHorizontalVerticalTab = false;

	public bool isWarmUpVisible = false;

	public bool isMaintanenceVisible = false;

	public bool SpindleDown = false;

	public bool WarmUpMillingDone = false;

	public bool PointerArcMode = false;

	public bool WarmUpSawDone = false;

	public bool VacuumNotAllowDown = false;

	public bool APositiveMoveNotAllow = false;

	public bool OnlineSimulationAllow = true;

	public bool SpindleDiameterTooBigForMoveUp = false;

	public bool ZLimitControlDisable = false;

	public double G54ExtraOffsetX = 0.0;

	public double G54ExtraOffsetY = 0.0;

	public int AxX = 0;

	public int AxY = 1;

	public int AxZ = 2;

	public int AxC = 3;

	public int AxA = 4;

	public int AxX2 = -1;

	public int AxY2 = 5;

	public int AxZ2 = -1;

	public int AxC2 = -1;

	public int AxA2 = -1;

	public int MaterialIndex = -1;

	public int MarbleWarningCount = 0;

	public int OperationIndex = -1;

	public double MaterialMeasuredThickness = 0.0;

	public Point3D pntG54Offset = new Point3D();

	public List<int> SimMovePartIndex = new List<int>();

	public Pnt6DSimMove pntSim = new Pnt6DSimMove();

	public clsAppMarbleRuntimeVar()
	{
	}

	public clsAppMarbleRuntimeVar(clsAppMarbleRuntimeVar data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
