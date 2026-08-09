using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendSimulationMove : buSerilization5
{
	public double Length = 0.0;

	public double XBendingPos = 0.0;

	public double ExecutedStep = 0.0;

	public double ExecutedPipe = 0.0;

	public double YPos = 0.0;

	public double YPreasurePos = 0.0;

	public double ZPos = 0.0;

	public double APos = 0.0;

	public double CPos = 0.0;

	public double BendPos = 0.0;

	public double RotatePos = 0.0;

	public double UpDistance = 0.0;

	public double Radius = 0.0;

	public bool MovePipe = false;

	public int IndexMove = -1;

	public int RowIndex = -1;

	public PipeBendMoveCommand Command = PipeBendMoveCommand.None;

	public PipeBendSimulationMove()
	{
	}

	public PipeBendSimulationMove(double xpos, double ypos, double zpos, double bendpos, double rotatepos, PipeBendMoveCommand Cmd)
	{
		Length = xpos;
		YPos = ypos;
		ZPos = zpos;
		BendPos = bendpos;
		RotatePos = rotatepos;
		Command = Cmd;
	}

	public PipeBendSimulationMove(double xpos, double ypos, double zpos, double apos, double cpos, double bendpos, double rotatepos, double ypreasure, double xbending, double rad, PipeBendMoveCommand Cmd)
	{
		Length = xpos;
		YPos = ypos;
		ZPos = zpos;
		BendPos = bendpos;
		RotatePos = rotatepos;
		CPos = cpos;
		APos = apos;
		YPreasurePos = ypreasure;
		XBendingPos = xbending;
		Command = Cmd;
		Radius = rad;
	}

	public PipeBendSimulationMove(double xpos, double ypos, double zpos, double apos, double cpos, double bendpos, double rotatepos, double ypreasure, double xbending, double rad, bool movepipe, int indexmove, PipeBendMoveCommand Cmd)
	{
		Length = xpos;
		YPos = ypos;
		ZPos = zpos;
		BendPos = bendpos;
		RotatePos = rotatepos;
		CPos = cpos;
		APos = apos;
		YPreasurePos = ypreasure;
		XBendingPos = xbending;
		Command = Cmd;
		Radius = rad;
		MovePipe = movepipe;
		IndexMove = indexmove;
	}

	public PipeBendSimulationMove(PipeBendSimulationMove data)
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

	public static bool EQ(PipeBendSimulationMove A, PipeBendSimulationMove B)
	{
		if (!(buCompare5.EQ(A.Length, B.Length) & buCompare5.EQ(A.YPos, B.YPos) & buCompare5.EQ(A.ZPos, B.ZPos)) || !(buCompare5.EQ(A.APos, B.APos) & buCompare5.EQ(A.CPos, B.CPos) & buCompare5.EQ(A.BendPos, B.BendPos)) || !(buCompare5.EQ(A.RotatePos, B.RotatePos) & buCompare5.EQ(A.XBendingPos, B.XBendingPos) & buCompare5.EQ(A.YPreasurePos, B.YPreasurePos)) || A.Command != B.Command)
		{
			return false;
		}
		return true;
	}

	public static void Copy(PipeBendSimulationMove Base, ref PipeBendSimulationMove Copied)
	{
		Copied = new PipeBendSimulationMove(Base);
	}

	public static void Copy(List<PipeBendSimulationMove> RefList, ref List<PipeBendSimulationMove> CopyList)
	{
		CopyList.Clear();
		for (int i = 0; i <= RefList.Count - 1; i++)
		{
			CopyList.Add(new PipeBendSimulationMove(RefList[i]));
		}
	}

	public override string ToString()
	{
		string text = "Len: " + Length.ToString("f2") + " - Y: " + YPos.ToString("f2") + " - Z: " + ZPos.ToString("f2") + " - A: " + APos.ToString("f2") + " - C: " + CPos.ToString("f2") + " - Bend: " + BendPos.ToString("f2") + " - Rot: " + RotatePos.ToString("f2") + " - YPres: " + YPreasurePos.ToString("f2");
		text = text + " - Index: " + IndexMove;
		text = text + " - ExecStep: " + ExecutedStep.ToString("f1") + " - ExecLen: " + ExecutedPipe.ToString("f1");
		if (MovePipe)
		{
			text = text + " - MovePipe: " + MovePipe;
		}
		if (Command != PipeBendMoveCommand.None)
		{
			text = text + " - Cmd: " + Command;
		}
		return text;
	}
}
