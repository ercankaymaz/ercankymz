using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendMove : buSerilization5
{
	public double XPos = 0.0;

	public double YPos = 0.0;

	public double ZPos = 0.0;

	public double BendPos = 0.0;

	public double RotatePos = 0.0;

	public double UpDistance = 0.0;

	public PipeBendMoveCommand Command = PipeBendMoveCommand.None;

	public PipeBendMove()
	{
	}

	public PipeBendMove(double xpos, double ypos, double zpos, double bendpos, double rotatepos, PipeBendMoveCommand Cmd)
	{
		XPos = xpos;
		YPos = ypos;
		ZPos = zpos;
		BendPos = bendpos;
		RotatePos = rotatepos;
		Command = Cmd;
	}

	public PipeBendMove(RollerBendMove data)
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

	public static void Copy(RollerBendMove Base, ref RollerBendMove Copied)
	{
		Copied = new RollerBendMove(Base);
	}

	public static void Copy(List<RollerBendMove> RefList, ref List<RollerBendMove> CopyList)
	{
		CopyList.Clear();
		for (int i = 0; i <= RefList.Count - 1; i++)
		{
			CopyList.Add(new RollerBendMove(RefList[i]));
		}
	}

	public override string ToString()
	{
		return "X: " + XPos.ToString("f2") + " - YPos: " + YPos.ToString("f2") + " - ZPos: " + ZPos.ToString("f2") + " - BendPos: " + BendPos.ToString("f2") + " - RotatePos: " + RotatePos.ToString("f2") + " - Cmd: " + Command;
	}
}
