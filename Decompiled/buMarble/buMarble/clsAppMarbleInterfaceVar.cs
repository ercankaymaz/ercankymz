using System;
using System.Reflection;
using buClass;
using buEyeBaseVer5;

namespace buMarble;

[Serializable]
public class clsAppMarbleInterfaceVar : buSerilization5
{
	public double OperationSpeed = 100.0;

	public double QuickSpeed = 100.0;

	public double SpindleSpeed = 1000.0;

	public double SawSpeed = 1000.0;

	public double SpindleSpeedOverride = 100.0;

	public double SawSpeedOverride = 100.0;

	public bool IncrementalMode = false;

	public bool AbsoluteMode = false;

	public bool PartZeroMode = false;

	public bool AddSawThicknessToMove = false;

	public double JogGantryY2Move = 10.0;

	public double JogMoveValue = 10.0;

	public double JogMoveXValue = 10.0;

	public double JogMoveYValue = 10.0;

	public double JogMoveZValue = 1.0;

	public double JogMoveAValue = 0.0;

	public double JogMoveCValue = 0.0;

	public double KinCalcMatThickness = 20.0;

	public double KinCalcOperationZ = 0.0;

	public double KinCalcRectWidth = 300.0;

	public double KinCalcRectHeight = 300.0;

	public double KinCalcRectAngle = 0.0;

	public double DataLimitSoftLimitDiff = 2.0;

	public int IndexG54 = -1;

	public int IndexToolSaw = -1;

	public int IndexToolMilling = -1;

	public int IndexToolMillingHead = -1;

	public double PointerCircleDia = 10.0;

	public bool MachineInstallationAxesCalib = false;

	public bool MachineInstallationKinematic = false;

	public bool MachineInstallationSpeeds = false;

	public bool MachineInstallationPositions = false;

	public bool MachineInstallationSpindle = false;

	public bool MachineInstallationLimits = false;

	public int AutoProgramSaveDays = 3;

	public MarblePartZeroType PartZeroType = MarblePartZeroType.Saw;

	public int ZoomX1 = 0;

	public int ZoomY1 = 0;

	public int ZoomX2 = 0;

	public int ZoomY2 = 0;

	public double ZoomRatio = 1.0;

	public clsAppMarbleInterfaceVar()
	{
	}

	public clsAppMarbleInterfaceVar(clsAppMarbleInterfaceVar data)
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
