using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt9DCam
{
	public ArrayList PreCodes = new ArrayList();

	public ArrayList AfterCodes = new ArrayList();

	public double Feed;

	public int Type = 0;

	public double Radius = 0.0;

	public geoArc ArcData = new geoArc();

	public bool IsArc = false;

	public int ArcType = 0;

	public double ToolNo = 1.0;

	public double SpindleSpeed = 0.0;

	public bool LeaveAxisMovement = false;

	public bool PlungeAxisMovement = false;

	public string PlungeAxis = "Z";

	public double PlungeValue = 0.0;

	public CamPlungeActionType PlungeAction = CamPlungeActionType.None;

	public bool DontUseAdditionalCommand = false;

	public AxesEnableWithUVW EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: true, c: true, u: true, v: true, w: true);

	public Pnt9D P9 = new Pnt9D();

	public Pnt9D Offsets = new Pnt9D();

	public Pnt9DCam()
	{
	}

	public Pnt9DCam(double x, double y, double z)
	{
		P9 = new Pnt9D(x, y, z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
	}

	public Pnt9DCam(double x, double y, double z, double feed, int type)
	{
		P9 = new Pnt9D(x, y, z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public Pnt9DCam(double x, double y, double z, double a, double b, double c)
	{
		P9 = new Pnt9D(x, y, z, a, b, c, 0.0, 0.0, 0.0);
	}

	public Pnt9DCam(double x, double y, double z, double a, double b, double c, double feed, int type)
	{
		P9 = new Pnt9D(x, y, z, a, b, c, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public Pnt9DCam(double x, double y, double z, double a, double b, double c, double u, double v, double w)
	{
		P9 = new Pnt9D(x, y, z, a, b, c, u, v, w);
	}

	public Pnt9DCam(Pnt3D P, OrientationAngle Orientation, double feed, int type)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, Orientation.A, Orientation.B, Orientation.C, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public Pnt9DCam(Pnt6D P)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
	}

	public Pnt9DCam(Pnt6D P, double feed, int type)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public Pnt9DCam(Pnt6D P, double feed, int type, bool plungemove)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
		PlungeAxisMovement = plungemove;
	}

	public Pnt9DCam(Pnt6D P, double feed, int type, bool plungemove, bool Leavemove)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
		PlungeAxisMovement = plungemove;
		LeaveAxisMovement = Leavemove;
	}

	public Pnt9DCam(Pnt9D P)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
	}

	public Pnt9DCam(Pnt9D P, double feed, int type)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
		Feed = feed;
		Type = type;
	}

	public Pnt9DCam(Pnt9D P, double feed, int type, bool plungemove)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
		Feed = feed;
		Type = type;
		PlungeAxisMovement = plungemove;
	}

	public Pnt9DCam(Pnt9D P, double feed, int type, bool plungemove, bool Leavemove)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
		Feed = feed;
		Type = type;
		PlungeAxisMovement = plungemove;
		LeaveAxisMovement = Leavemove;
	}

	public Pnt9DCam(Pnt9DCam Pnt)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Pnt, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		P9 = new Pnt9D(Pnt.P9);
		ArcData = new geoArc(Pnt.ArcData);
		AfterCodes.Clear();
		PreCodes.Clear();
		for (int j = 0; j <= Pnt.AfterCodes.Count - 1; j++)
		{
			AfterCodes.Add(Pnt.AfterCodes[j]);
		}
		for (int k = 0; k <= Pnt.PreCodes.Count - 1; k++)
		{
			PreCodes.Add(Pnt.PreCodes[k]);
		}
	}

	public static Pnt9DCam Copy(Pnt9DCam P)
	{
		return new Pnt9DCam(P);
	}

	public static Pnt9DCam[] Copy(Pnt9DCam[] pts)
	{
		Pnt9DCam[] array = new Pnt9DCam[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt9DCam> Copy(List<Pnt9DCam> pts)
	{
		List<Pnt9DCam> list = new List<Pnt9DCam>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public override string ToString()
	{
		string text = "X:" + P9.X.ToString("f4") + " ; Y:" + P9.Y.ToString("f4") + " ; Z:" + P9.Z.ToString("f4");
		if (P9.A != 0.0)
		{
			text = text + " ; A:" + P9.A.ToString("f4");
		}
		if (P9.B != 0.0)
		{
			text = text + " ; B:" + P9.B.ToString("f4");
		}
		if (P9.C != 0.0)
		{
			text = text + " ; C:" + P9.C.ToString("f4");
		}
		if (P9.U != 0.0)
		{
			text = text + " ; U:" + P9.U.ToString("f4");
		}
		if (P9.V != 0.0)
		{
			text = text + "; V:" + P9.V.ToString("f4");
		}
		if (P9.W != 0.0)
		{
			text = text + "; W:" + P9.W.ToString("f4");
		}
		if (Radius != 0.0)
		{
			text = text + "; R:" + Radius.ToString("f3");
		}
		text = text + "; Feed: " + Feed + " ; Type: " + Type;
		if (PlungeAxisMovement)
		{
			text = text + "; Plunge: " + PlungeAxis;
		}
		return text;
	}

	public static Pnt9D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt9D pnt9D = new Pnt9D();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
			}
			if (array.Length == 6)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
				pnt9D.C = double.Parse(array[5], provider);
			}
			if (array.Length == 7)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
				pnt9D.C = double.Parse(array[5], provider);
				pnt9D.U = double.Parse(array[6], provider);
			}
			if (array.Length == 8)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
				pnt9D.C = double.Parse(array[5], provider);
				pnt9D.U = double.Parse(array[6], provider);
				pnt9D.V = double.Parse(array[7], provider);
			}
			if (array.Length >= 9)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
				pnt9D.C = double.Parse(array[5], provider);
				pnt9D.U = double.Parse(array[6], provider);
				pnt9D.V = double.Parse(array[7], provider);
				pnt9D.W = double.Parse(array[8], provider);
			}
			return pnt9D;
		}
		catch (Exception)
		{
			return new Pnt9D();
		}
	}

	public string ToDef()
	{
		return "X:" + P9.X + "; Y:" + P9.Y + "; Z:" + P9.Z + "; A:" + P9.A + "; B:" + P9.B + "; C:" + P9.C + "; U:" + P9.U + "; V:" + P9.V + "; W:" + P9.W;
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + P9.X + "; Y:" + P9.Y + "; Z:" + P9.Z + "; A:" + P9.A + "; B:" + P9.B + "; C:" + P9.C + "; U:" + P9.U + "; V:" + P9.V + "; W:" + P9.W;
	}
}
