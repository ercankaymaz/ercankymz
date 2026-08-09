using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt6DSim : Pnt6D
{
	public double FeedRate;

	public double SpindleRpm;

	public double ToolNo;

	public string ToolName;

	public new Pnt3D Offset = new Pnt3D();

	public int Index = -1;

	public bool isMCode = false;

	public int MCode = -1;

	public Pnt6DSim()
	{
	}

	public Pnt6DSim(Pnt6DSim Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
		FeedRate = Pnt.FeedRate;
		SpindleRpm = Pnt.SpindleRpm;
		ToolNo = Pnt.ToolNo;
		ToolName = Pnt.ToolName;
		Offset = new Pnt3D(Pnt.Offset);
		Index = Pnt.Index;
	}

	public Pnt6DSim(Pnt6D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
	}

	public Pnt6DSim(Pnt9D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
	}

	public Pnt6DSim(Pnt9DCam Pnt)
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

	public Pnt6DSim(Pnt3D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = 0.0;
		B = 0.0;
		C = 0.0;
	}

	public Pnt6DSim(Pnt3D Pnt, double a, double b, double c)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = a;
		B = b;
		C = c;
	}

	public Pnt6DSim(Pnt3D Pnt, OrientationAngle Angles)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Angles.A;
		B = Angles.B;
		C = Angles.C;
	}

	public Pnt6DSim(double x, double y, double z, double a, double b, double c)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
	}

	public Pnt6DSim(double x, double y, double z, double a, double b, double c, double f, double t, double s, Pnt3D offset)
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
		Offset = new Pnt3D(offset);
	}

	public Pnt6DSim(double x, double y, double z, double a, double b, double c, double f, double t, double s, Pnt3D offset, int index, string toolname)
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
		Offset = new Pnt3D(offset);
		Index = index;
		ToolName = toolname;
	}

	public Pnt6DSim(double x, double y, double z)
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

	public static Pnt6DSim Copy(Pnt6DSim P)
	{
		return new Pnt6DSim(P.X, P.Y, P.Z, P.A, P.B, P.C, P.FeedRate, P.ToolNo, P.SpindleRpm, P.Offset, P.Index, P.ToolName);
	}

	public static Pnt6DSim[] Copy(Pnt6DSim[] pts)
	{
		Pnt6DSim[] array = new Pnt6DSim[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt6DSim> Copy(List<Pnt6DSim> pts)
	{
		List<Pnt6DSim> list = new List<Pnt6DSim>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pnt6DSim> pts, ref List<Pnt6DSim> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DSim(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt3D> pts, ref List<Pnt6DSim> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DSim(pts[i]));
		}
	}

	public static void Copy(List<List<Pnt6DSim>> pts, ref List<List<Pnt6DSim>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt6DSim> list = new List<Pnt6DSim>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt6DSim>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt6DSim> CopiedPnt2 = new List<Pnt6DSim>();
			Copy(pts[i], ref CopiedPnt2);
			CopiedPnt.Add(CopiedPnt2);
		}
	}

	public static void Copy(List<Pnt3D> pts, OrientationAngle Orientation, ref List<Pnt6DSim> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DSim(new Pnt3D(pts[i]), new OrientationAngle(Orientation)));
		}
	}

	public static void Add(List<Pnt6DSim> pts, ref List<Pnt6DSim> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Pnt6DSim> pts, ref List<List<Pnt6DSim>> CopiedPnt)
	{
		List<Pnt6DSim> CopiedPnt2 = new List<Pnt6DSim>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Add(List<List<Pnt6DSim>> SourceList, ref List<List<Pnt6DSim>> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					List<Pnt6DSim> CopiedPnt = new List<Pnt6DSim>();
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
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4") + "; A:" + A.ToString("f4") + "; B:" + B.ToString("f4") + "; C:" + C.ToString("f4") + "; F:" + FeedRate.ToString("f2") + "; S:" + SpindleRpm.ToString("f2") + "; T:" + ToolNo.ToString("f0");
	}

	public new static Pnt6DSim DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt6DSim pnt6DSim = new Pnt6DSim();
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
				pnt6DSim.X = double.Parse(array[0], provider);
				pnt6DSim.Y = double.Parse(array[1], provider);
				pnt6DSim.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pnt6DSim.X = double.Parse(array[0], provider);
				pnt6DSim.Y = double.Parse(array[1], provider);
				pnt6DSim.Z = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				pnt6DSim.X = double.Parse(array[0], provider);
				pnt6DSim.Y = double.Parse(array[1], provider);
				pnt6DSim.Z = double.Parse(array[2], provider);
				pnt6DSim.A = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				pnt6DSim.X = double.Parse(array[0], provider);
				pnt6DSim.Y = double.Parse(array[1], provider);
				pnt6DSim.Z = double.Parse(array[2], provider);
				pnt6DSim.A = double.Parse(array[3], provider);
				pnt6DSim.B = double.Parse(array[4], provider);
			}
			if (array.Length >= 6)
			{
				pnt6DSim.X = double.Parse(array[0], provider);
				pnt6DSim.Y = double.Parse(array[1], provider);
				pnt6DSim.Z = double.Parse(array[2], provider);
				pnt6DSim.A = double.Parse(array[3], provider);
				pnt6DSim.B = double.Parse(array[4], provider);
				pnt6DSim.C = double.Parse(array[5], provider);
			}
			if (array.Length >= 7)
			{
				pnt6DSim.X = double.Parse(array[0], provider);
				pnt6DSim.Y = double.Parse(array[1], provider);
				pnt6DSim.Z = double.Parse(array[2], provider);
				pnt6DSim.A = double.Parse(array[3], provider);
				pnt6DSim.B = double.Parse(array[4], provider);
				pnt6DSim.C = double.Parse(array[5], provider);
				pnt6DSim.FeedRate = double.Parse(array[6], provider);
			}
			if (array.Length >= 8)
			{
				pnt6DSim.X = double.Parse(array[0], provider);
				pnt6DSim.Y = double.Parse(array[1], provider);
				pnt6DSim.Z = double.Parse(array[2], provider);
				pnt6DSim.A = double.Parse(array[3], provider);
				pnt6DSim.B = double.Parse(array[4], provider);
				pnt6DSim.C = double.Parse(array[5], provider);
				pnt6DSim.FeedRate = double.Parse(array[6], provider);
				pnt6DSim.SpindleRpm = double.Parse(array[7], provider);
			}
			if (array.Length >= 9)
			{
				pnt6DSim.X = double.Parse(array[0], provider);
				pnt6DSim.Y = double.Parse(array[1], provider);
				pnt6DSim.Z = double.Parse(array[2], provider);
				pnt6DSim.A = double.Parse(array[3], provider);
				pnt6DSim.B = double.Parse(array[4], provider);
				pnt6DSim.C = double.Parse(array[5], provider);
				pnt6DSim.FeedRate = double.Parse(array[6], provider);
				pnt6DSim.SpindleRpm = double.Parse(array[7], provider);
				pnt6DSim.ToolNo = double.Parse(array[8], provider);
			}
			return pnt6DSim;
		}
		catch (Exception)
		{
			return new Pnt6DSim();
		}
	}

	public new string ToDef()
	{
		return "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; F:" + FeedRate + "; S:" + SpindleRpm + "; T:" + ToolNo;
	}

	public new string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; F:" + FeedRate + "; S:" + SpindleRpm + "; T:" + ToolNo;
	}
}
