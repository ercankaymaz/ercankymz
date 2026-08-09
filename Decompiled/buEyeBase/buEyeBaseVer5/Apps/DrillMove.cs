using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillMove : buSerilization5
{
	public Point3D DrillPosition = new Point3D();

	public double XPosition = 0.0;

	public double X1Clamper = 0.0;

	public double X2Clamper = 0.0;

	public double Y1Position = 0.0;

	public double Y2Position = 0.0;

	public double Y3Position = 0.0;

	public double Z1Position = 0.0;

	public double Z2Position = 0.0;

	public double Z3Position = 0.0;

	public double SPosition = 0.0;

	public bool X1ClamperDown = false;

	public bool X2ClamperDown = false;

	public bool MaterialZeroDown = false;

	public int LineIndex = -1;

	public int Tool1 = 0;

	public Point3D Tool1OriginalPos = new Point3D();

	public int Tool2 = 0;

	public Point3D Tool2OriginalPos = new Point3D();

	public int Tool3 = 0;

	public Point3D Tool3OriginalPos = new Point3D();

	public int Tool4 = 0;

	public Point3D Tool4OriginalPos = new Point3D();

	public int Tool5 = 0;

	public Point3D Tool5OriginalPos = new Point3D();

	public int Tool6 = 0;

	public Point3D Tool6OriginalPos = new Point3D();

	public int Tool7 = 0;

	public Point3D Tool7OriginalPos = new Point3D();

	public int Tool8 = 0;

	public Point3D Tool8OriginalPos = new Point3D();

	public int Tool9 = 0;

	public Point3D Tool9OriginalPos = new Point3D();

	public int Tool10 = 0;

	public Point3D Tool10OriginalPos = new Point3D();

	public int Tool11 = 0;

	public Point3D Tool11OriginalPos = new Point3D();

	public int Tool12 = 0;

	public Point3D Tool12OriginalPos = new Point3D();

	public DrillMoveCommand Command = DrillMoveCommand.AxisMove;

	public DrillMoveCommand Command2 = DrillMoveCommand.None;

	public DrillMoveCommand Command3 = DrillMoveCommand.None;

	public drillPlaneNames Plane = drillPlaneNames.Top;

	public DrillCNCMode Mode = DrillCNCMode.Fast;

	public bool isActive = false;

	public Point3D pntCenter = null;

	public AxesEnable EnableAxes = null;

	public List<string> CodeLines = null;

	public bool isG0 = false;

	public double Feed = 0.0;

	public double ClamperMove = 0.0;

	public DrillMove()
	{
	}

	public DrillMove(DrillMove data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
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
		if (data.pntCenter != null)
		{
			pntCenter = new Point3D(data.pntCenter.X, data.pntCenter.Y, data.pntCenter.Z);
		}
		if (data.EnableAxes != null)
		{
			EnableAxes = new AxesEnable(data.EnableAxes);
		}
		if (data.CodeLines != null)
		{
			CodeLines = new List<string>();
			for (int j = 0; j <= data.CodeLines.Count - 1; j++)
			{
				CodeLines.Add(data.CodeLines[j]);
			}
		}
		DrillPosition = buVector5.ToPoint3D(data.DrillPosition);
		Tool1OriginalPos = buVector5.ToPoint3D(data.Tool1OriginalPos);
		Tool2OriginalPos = buVector5.ToPoint3D(data.Tool2OriginalPos);
		Tool3OriginalPos = buVector5.ToPoint3D(data.Tool3OriginalPos);
		Tool4OriginalPos = buVector5.ToPoint3D(data.Tool4OriginalPos);
		Tool5OriginalPos = buVector5.ToPoint3D(data.Tool5OriginalPos);
		Tool6OriginalPos = buVector5.ToPoint3D(data.Tool6OriginalPos);
		Tool7OriginalPos = buVector5.ToPoint3D(data.Tool7OriginalPos);
		Tool8OriginalPos = buVector5.ToPoint3D(data.Tool8OriginalPos);
		Tool9OriginalPos = buVector5.ToPoint3D(data.Tool9OriginalPos);
		Tool10OriginalPos = buVector5.ToPoint3D(data.Tool10OriginalPos);
		Tool11OriginalPos = buVector5.ToPoint3D(data.Tool11OriginalPos);
		Tool12OriginalPos = buVector5.ToPoint3D(data.Tool12OriginalPos);
	}

	public DrillMove(double X1, double X2, double Y1, double Y2, double Y3, double Z1, double Z2, double Z3, DrillMoveCommand Cmd, double XPos)
	{
		X1Clamper = X1;
		X2Clamper = X2;
		Y1Position = Y1;
		Y2Position = Y2;
		Y3Position = Y3;
		Z1Position = Z1;
		Z2Position = Z2;
		Z3Position = Z3;
		Command = Cmd;
		XPosition = XPos;
	}

	public DrillMove(double X1, double X2, double Y1, double Z1, DrillMoveCommand Cmd, double XPos)
	{
		X1Clamper = X1;
		X2Clamper = X2;
		Y1Position = Y1;
		Z1Position = Z1;
		Command = Cmd;
		XPosition = XPos;
	}

	public DrillMove(double X1, double X2, double Y1, double Y2, double Y3, double Z1, double Z2, double Z3, DrillMoveCommand Cmd, double XPos, DrillCNCMode Mode, drillPlaneNames Plane, int T1, int T2, int T3, int T4, int T5, int T6, int T7, int T8, int T9, int T10, int T11, int T12)
	{
		X1Clamper = X1;
		X2Clamper = X2;
		Y1Position = Y1;
		Y2Position = Y2;
		Y3Position = Y3;
		Z1Position = Z1;
		Z2Position = Z2;
		Z3Position = Z3;
		Command = Cmd;
		XPosition = XPos;
		this.Mode = Mode;
		this.Plane = Plane;
		Tool1 = T1;
		Tool2 = T2;
		Tool3 = T3;
		Tool4 = T4;
		Tool5 = T5;
		Tool6 = T6;
		Tool7 = T7;
		Tool8 = T8;
		Tool9 = T9;
		Tool10 = T10;
		Tool11 = T11;
		Tool12 = T12;
	}

	public static ArrayList ToDef(List<DrillMove> Items, int Space)
	{
		new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(ToDef(Items[i], Space).ToArray());
			arrayList.AddRange(arrayList2);
		}
		return arrayList;
	}

	public static ArrayList ToDef(DrillMove Item, int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(Item.ToDefAll("", 2, SerilizationMode5.MultiLine).ToArray());
		arrayList.RemoveAt(arrayList.Count - 1);
		arrayList.Add(text + "</DrillJob>");
		return arrayList;
	}

	public static void Decode(List<string> AL, ref DrillMove Job)
	{
		Job = new DrillMove();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<DrillJob>", "</DrillJob>", AddStartEndKey: true, AL, ref CalcList);
		if (CalcList.Count > 0)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[0].ToArray());
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, Job);
			List<List<string>> CalcList2 = new List<List<string>>();
			buStatics.ListToSpecificList("<DrillItem>", "</DrillItem>", AddStartEndKey: true, arrayList, ref CalcList2);
		}
	}

	public override string ToString()
	{
		string text = Command.ToString() + " | X : " + XPosition.ToString("f1") + " , X1 : " + X1Clamper.ToString("f1") + " , X2 : " + X2Clamper.ToString("f1") + " , Y1 : " + Y1Position.ToString("f1") + " , Y2 : " + Y2Position.ToString("f1") + " , Y3 : " + Y3Position.ToString("f1") + " , Z1 : " + Z1Position.ToString("f1") + " , Z2 : " + Z2Position.ToString("f1") + " , Z3 : " + Z3Position.ToString("f1");
		if (Command2 != DrillMoveCommand.None)
		{
			text = text + " , Cmd2: " + Command2;
		}
		if (Command3 != DrillMoveCommand.None)
		{
			text = text + " , Cmd3: " + Command3;
		}
		if (pntCenter != null)
		{
			text = text + " , ( " + pntCenter.X.ToString("f1") + " , " + pntCenter.Y.ToString("f1") + " , " + pntCenter.Z.ToString("f1") + " )";
		}
		return text;
	}
}
