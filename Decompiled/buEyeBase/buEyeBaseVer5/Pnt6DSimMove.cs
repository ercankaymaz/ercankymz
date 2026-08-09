using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class Pnt6DSimMove
{
	public double X;

	public double Y;

	public double Z;

	public double A;

	public double B;

	public double C;

	public double R;

	public double FeedRate;

	public double SpindleRpm;

	public double ToolNo;

	public string ToolName;

	public Point3D Offset = new Point3D();

	public int GCode = -1;

	public int Index = -1;

	public bool isMCode = false;

	public int MCode = -1;

	public double Aux1 = 0.0;

	public double Aux2 = 0.0;

	public string Command = "";

	public List<double> Clampers = null;

	public Pnt6DSimMove()
	{
	}

	public Pnt6DSimMove(Pnt6DSimMove Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
		R = Pnt.R;
		FeedRate = Pnt.FeedRate;
		SpindleRpm = Pnt.SpindleRpm;
		ToolNo = Pnt.ToolNo;
		ToolName = Pnt.ToolName;
		Offset = new Point3D(Pnt.Offset.X, Pnt.Offset.Y, Pnt.Offset.Z);
		Index = Pnt.Index;
		isMCode = Pnt.isMCode;
		MCode = Pnt.MCode;
		GCode = Pnt.GCode;
		Aux1 = Pnt.Aux1;
		Aux2 = Pnt.Aux2;
		if (Pnt.Clampers != null)
		{
			Clampers = new List<double>();
			for (int i = 0; i <= Pnt.Clampers.Count - 1; i++)
			{
				Clampers.Add(Pnt.Clampers[i]);
			}
		}
	}

	public Pnt6DSimMove(Pnt6D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
	}

	public Pnt6DSimMove(Pnt9D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
	}

	public Pnt6DSimMove(Pnt9DCam Pnt)
	{
		X = Pnt.P9.X;
		Y = Pnt.P9.Y;
		Z = Pnt.P9.Z;
		A = Pnt.P9.A;
		B = Pnt.P9.B;
		C = Pnt.P9.C;
		FeedRate = Pnt.Feed;
		SpindleRpm = Pnt.SpindleSpeed;
		ToolNo = Pnt.ToolNo;
	}

	public Pnt6DSimMove(Pnt3D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = 0.0;
		B = 0.0;
		C = 0.0;
	}

	public Pnt6DSimMove(Point3D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = 0.0;
		B = 0.0;
		C = 0.0;
	}

	public Pnt6DSimMove(Pnt3D Pnt, double a, double b, double c)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = a;
		B = b;
		C = c;
	}

	public Pnt6DSimMove(Pnt3D Pnt, OrientationAngle Angles)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Angles.A;
		B = Angles.B;
		C = Angles.C;
	}

	public Pnt6DSimMove(double x, double y, double z, double a, double b, double c)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
	}

	public Pnt6DSimMove(double x, double y, double z, double a, double b, double c, double f, double t, double s, Pnt3D offset)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
		FeedRate = f;
		SpindleRpm = s;
		ToolNo = t;
		Offset = new Point3D(offset.X, offset.Y, offset.Z);
	}

	public Pnt6DSimMove(double x, double y, double z, double a, double b, double c, double f, double t, double s, Pnt3D offset, int index, string toolname)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
		FeedRate = f;
		SpindleRpm = s;
		ToolNo = t;
		Offset = new Point3D(offset.X, offset.Y, offset.Z);
		Index = index;
		ToolName = toolname;
	}

	public Pnt6DSimMove(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
		A = 0.0;
		B = 0.0;
		C = 0.0;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Pnt6DSimMove Copy(Pnt6DSimMove P)
	{
		return new Pnt6DSimMove(P);
	}

	public static Pnt6DSimMove[] Copy(Pnt6DSimMove[] pts)
	{
		Pnt6DSimMove[] array = new Pnt6DSimMove[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt6DSimMove> Copy(List<Pnt6DSimMove> pts)
	{
		List<Pnt6DSimMove> list = new List<Pnt6DSimMove>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pnt6DSimMove> pts, ref List<Pnt6DSimMove> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DSimMove(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt3D> pts, ref List<Pnt6DSimMove> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DSimMove(pts[i]));
		}
	}

	public static void Copy(List<List<Pnt6DSimMove>> pts, ref List<List<Pnt6DSimMove>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt6DSimMove> list = new List<Pnt6DSimMove>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt6DSimMove>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt6DSimMove> CopiedPnt2 = new List<Pnt6DSimMove>();
			Copy(pts[i], ref CopiedPnt2);
			CopiedPnt.Add(CopiedPnt2);
		}
	}

	public static void Copy(List<Pnt3D> pts, OrientationAngle Orientation, ref List<Pnt6DSimMove> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DSimMove(new Pnt3D(pts[i]), new OrientationAngle(Orientation)));
		}
	}

	public static void Add(List<Pnt6DSimMove> pts, ref List<Pnt6DSimMove> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Pnt6DSimMove> pts, ref List<List<Pnt6DSimMove>> CopiedPnt)
	{
		List<Pnt6DSimMove> CopiedPnt2 = new List<Pnt6DSimMove>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Add(List<List<Pnt6DSimMove>> SourceList, ref List<List<Pnt6DSimMove>> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					List<Pnt6DSimMove> CopiedPnt = new List<Pnt6DSimMove>();
					Copy(SourceList[i], ref CopiedPnt);
					TargetList.Add(CopiedPnt);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		string text = "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4") + "; A:" + A.ToString("f4") + "; B:" + B.ToString("f4") + "; C:" + C.ToString("f4") + "; F:" + FeedRate.ToString("f2") + "; S:" + SpindleRpm.ToString("f2") + "; T:" + ToolNo.ToString("f0");
		text = (isMCode ? (text + " ; M: " + MCode) : (text + " ; G: " + GCode));
		if (Index >= 0)
		{
			text = text + " ; Index: " + Index;
		}
		if (Clampers != null && Clampers.Count > 0)
		{
			text = text + " ; Clmaps: " + Clampers.Count;
		}
		return text;
	}

	public static Pnt6DSimMove DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("A:", "");
			Value = Value.Replace("B:", "");
			Value = Value.Replace("C:", "");
			Value = Value.Replace("F:", "");
			Value = Value.Replace("S:", "");
			Value = Value.Replace("T:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt6DSimMove.X = double.Parse(array[0], provider);
				pnt6DSimMove.Y = double.Parse(array[1], provider);
				pnt6DSimMove.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pnt6DSimMove.X = double.Parse(array[0], provider);
				pnt6DSimMove.Y = double.Parse(array[1], provider);
				pnt6DSimMove.Z = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				pnt6DSimMove.X = double.Parse(array[0], provider);
				pnt6DSimMove.Y = double.Parse(array[1], provider);
				pnt6DSimMove.Z = double.Parse(array[2], provider);
				pnt6DSimMove.A = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				pnt6DSimMove.X = double.Parse(array[0], provider);
				pnt6DSimMove.Y = double.Parse(array[1], provider);
				pnt6DSimMove.Z = double.Parse(array[2], provider);
				pnt6DSimMove.A = double.Parse(array[3], provider);
				pnt6DSimMove.B = double.Parse(array[4], provider);
			}
			if (array.Length >= 6)
			{
				pnt6DSimMove.X = double.Parse(array[0], provider);
				pnt6DSimMove.Y = double.Parse(array[1], provider);
				pnt6DSimMove.Z = double.Parse(array[2], provider);
				pnt6DSimMove.A = double.Parse(array[3], provider);
				pnt6DSimMove.B = double.Parse(array[4], provider);
				pnt6DSimMove.C = double.Parse(array[5], provider);
			}
			if (array.Length >= 7)
			{
				pnt6DSimMove.X = double.Parse(array[0], provider);
				pnt6DSimMove.Y = double.Parse(array[1], provider);
				pnt6DSimMove.Z = double.Parse(array[2], provider);
				pnt6DSimMove.A = double.Parse(array[3], provider);
				pnt6DSimMove.B = double.Parse(array[4], provider);
				pnt6DSimMove.C = double.Parse(array[5], provider);
				pnt6DSimMove.FeedRate = double.Parse(array[6], provider);
			}
			if (array.Length >= 8)
			{
				pnt6DSimMove.X = double.Parse(array[0], provider);
				pnt6DSimMove.Y = double.Parse(array[1], provider);
				pnt6DSimMove.Z = double.Parse(array[2], provider);
				pnt6DSimMove.A = double.Parse(array[3], provider);
				pnt6DSimMove.B = double.Parse(array[4], provider);
				pnt6DSimMove.C = double.Parse(array[5], provider);
				pnt6DSimMove.FeedRate = double.Parse(array[6], provider);
				pnt6DSimMove.SpindleRpm = double.Parse(array[7], provider);
			}
			if (array.Length >= 9)
			{
				pnt6DSimMove.X = double.Parse(array[0], provider);
				pnt6DSimMove.Y = double.Parse(array[1], provider);
				pnt6DSimMove.Z = double.Parse(array[2], provider);
				pnt6DSimMove.A = double.Parse(array[3], provider);
				pnt6DSimMove.B = double.Parse(array[4], provider);
				pnt6DSimMove.C = double.Parse(array[5], provider);
				pnt6DSimMove.FeedRate = double.Parse(array[6], provider);
				pnt6DSimMove.SpindleRpm = double.Parse(array[7], provider);
				pnt6DSimMove.ToolNo = double.Parse(array[8], provider);
			}
			return pnt6DSimMove;
		}
		catch (Exception)
		{
			return new Pnt6DSimMove();
		}
	}

	public string ToDef()
	{
		return "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; F:" + FeedRate + "; S:" + SpindleRpm + "; T:" + ToolNo;
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; F:" + FeedRate + "; S:" + SpindleRpm + "; T:" + ToolNo;
	}
}
