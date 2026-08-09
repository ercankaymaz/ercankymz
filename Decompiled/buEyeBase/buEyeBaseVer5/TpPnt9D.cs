using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class TpPnt9D
{
	public ArrayList PreCodes = new ArrayList();

	public ArrayList AfterCodes = new ArrayList();

	public double Feed = 0.0;

	public double Radius = 0.0;

	public double ToolNo = 1.0;

	public string ToolName = "";

	public string OverWriteString = null;

	public double SpindleSpeed = 0.0;

	public double PlungeValue = 0.0;

	public double SimDevideLen = 0.0;

	public int Type = 0;

	public int ArcType = 0;

	public bool IsArc = false;

	public bool IsMark = false;

	public bool IsLimit = false;

	public bool IsSafePosition = false;

	public bool LeaveAxisMovement = false;

	public bool PlungeAxisMovement = false;

	public bool DontUseAdditionalCommand = false;

	public string PlungeAxis = "Z";

	public string LeaveAxis = "Z";

	public string GCodeExtraLine = "";

	public CamPlungeActionType PlungeAction = CamPlungeActionType.None;

	public CamMoveType MoveType = CamMoveType.G0;

	public AxesEnableWithUVW EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: true, c: true, u: false, v: false, w: false);

	public TpArcData ArcData = new TpArcData();

	public Pnt9D P9 = new Pnt9D();

	public Pnt9D Offsets = new Pnt9D();

	public Pnt9D PostOffsets = new Pnt9D();

	public string XChar = null;

	public string YChar = null;

	public string ZChar = null;

	public TpPnt9D()
	{
	}

	public TpPnt9D(double x, double y, double z)
	{
		P9 = new Pnt9D(x, y, z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
	}

	public TpPnt9D(double x, double y, double z, double feed, int type)
	{
		P9 = new Pnt9D(x, y, z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public TpPnt9D(double x, double y, double z, double a, double feed, int type)
	{
		P9 = new Pnt9D(x, y, z, a, 0.0, 0.0, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public TpPnt9D(double x, double y, double z, double a, double b, double c)
	{
		P9 = new Pnt9D(x, y, z, a, b, c, 0.0, 0.0, 0.0);
	}

	public TpPnt9D(double x, double y, double z, double a, double b, double c, double feed, int type)
	{
		P9 = new Pnt9D(x, y, z, a, b, c, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public TpPnt9D(double x, double y, double z, double a, double b, double c, double u, double v, double w)
	{
		P9 = new Pnt9D(x, y, z, a, b, c, u, v, w);
	}

	public TpPnt9D(Pnt3D P, OrientationAngle Orientation, double feed, int type)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, Orientation.A, Orientation.B, Orientation.C, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public TpPnt9D(Point3D P, double feed, int type)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public TpPnt9D(Pnt6D P)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
	}

	public TpPnt9D(Pnt6D P, double feed, int type)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
	}

	public TpPnt9D(Pnt6D P, double feed, int type, bool plungemove)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
		PlungeAxisMovement = plungemove;
	}

	public TpPnt9D(Pnt6D P, double feed, int type, bool plungemove, bool Leavemove)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
		Feed = feed;
		Type = type;
		PlungeAxisMovement = plungemove;
		LeaveAxisMovement = Leavemove;
	}

	public TpPnt9D(Pnt9D P)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
	}

	public TpPnt9D(Pnt9D P, double feed, int type)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
		Feed = feed;
		Type = type;
	}

	public TpPnt9D(Pnt9D P, double feed, int type, bool plungemove)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
		Feed = feed;
		Type = type;
		PlungeAxisMovement = plungemove;
	}

	public TpPnt9D(Pnt9D P, double feed, int type, bool plungemove, bool Leavemove)
	{
		P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
		Feed = feed;
		Type = type;
		PlungeAxisMovement = plungemove;
		LeaveAxisMovement = Leavemove;
	}

	public TpPnt9D(TpPnt9D Pnt, bool CopyClass = false)
	{
		if (!CopyClass)
		{
			if (Pnt != null)
			{
				ArcType = Pnt.ArcType;
				DontUseAdditionalCommand = Pnt.DontUseAdditionalCommand;
				Feed = Pnt.Feed;
				GCodeExtraLine = Pnt.GCodeExtraLine;
				IsArc = Pnt.IsArc;
				IsMark = Pnt.IsMark;
				IsLimit = Pnt.IsLimit;
				IsSafePosition = Pnt.IsSafePosition;
				LeaveAxis = Pnt.LeaveAxis;
				MoveType = Pnt.MoveType;
				Offsets = new Pnt9D(Pnt.Offsets);
				PlungeAction = Pnt.PlungeAction;
				PlungeAxis = Pnt.PlungeAxis;
				PlungeAxisMovement = Pnt.PlungeAxisMovement;
				PlungeValue = Pnt.PlungeValue;
				LeaveAxisMovement = Pnt.LeaveAxisMovement;
				Radius = Pnt.Radius;
				SimDevideLen = Pnt.SimDevideLen;
				SpindleSpeed = Pnt.SpindleSpeed;
				Type = Pnt.Type;
				ToolName = Pnt.ToolName;
				ToolNo = Pnt.ToolNo;
				P9 = new Pnt9D(Pnt.P9);
				ArcData = new TpArcData(Pnt.ArcData);
				AfterCodes.Clear();
				PreCodes.Clear();
				for (int i = 0; i <= Pnt.AfterCodes.Count - 1; i++)
				{
					AfterCodes.Add(Pnt.AfterCodes[i]);
				}
				for (int j = 0; j <= Pnt.PreCodes.Count - 1; j++)
				{
					PreCodes.Add(Pnt.PreCodes[j]);
				}
				EnableAxes = new AxesEnableWithUVW(Pnt.EnableAxes);
			}
			return;
		}
		object CopiedClass = new object();
		buSerilization5.CopyClass(Pnt, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int k = 0; k <= fields.Length - 1; k++)
			{
				_ = fields[k].Name;
				object value = fields[k].GetValue(CopiedClass);
				fields[k].SetValue(this, value);
			}
		}
	}

	public static TpPnt9D Copy(TpPnt9D P)
	{
		return new TpPnt9D(P);
	}

	public static TpPnt9D[] Copy(TpPnt9D[] pts)
	{
		TpPnt9D[] array = new TpPnt9D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<TpPnt9D> Copy(List<TpPnt9D> pts)
	{
		List<TpPnt9D> list = new List<TpPnt9D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static Pnt6DSimMove ToPnt6DSim(TpPnt9D pnt)
	{
		Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove(pnt.P9.X, pnt.P9.Y, pnt.P9.Z, pnt.P9.A, pnt.P9.B, pnt.P9.C);
		pnt6DSimMove.FeedRate = pnt.Feed;
		pnt6DSimMove.SpindleRpm = pnt.SpindleSpeed;
		pnt6DSimMove.ToolNo = pnt.ToolNo;
		pnt6DSimMove.ToolName = pnt.ToolName;
		pnt6DSimMove.GCode = pnt.Type;
		return pnt6DSimMove;
	}

	public override string ToString()
	{
		string text = "X:" + P9.X.ToString("f4") + " ; Y:" + P9.Y.ToString("f4") + " ; Z:" + P9.Z.ToString("f4");
		if (EnableAxes.A | (P9.A != 0.0))
		{
			text = text + " ; A:" + P9.A.ToString("f4");
		}
		if (EnableAxes.B | (P9.B != 0.0))
		{
			text = text + " ; B:" + P9.B.ToString("f4");
		}
		if (EnableAxes.C | (P9.C != 0.0))
		{
			text = text + " ; C:" + P9.C.ToString("f4");
		}
		if (EnableAxes.U | (P9.U != 0.0))
		{
			text = text + " ; U:" + P9.U.ToString("f4");
		}
		if (EnableAxes.V | (P9.V != 0.0))
		{
			text = text + "; V:" + P9.V.ToString("f4");
		}
		if (EnableAxes.V | (P9.W != 0.0))
		{
			text = text + "; W:" + P9.W.ToString("f4");
		}
		if (Radius != 0.0)
		{
			text = text + "; R:" + Radius.ToString("f3");
		}
		text = text + "; Feed: " + Feed + " ; Type: " + Type;
		string text2 = "";
		if (EnableAxes.X)
		{
			text2 += "X";
		}
		if (EnableAxes.Y)
		{
			text2 += "Y";
		}
		if (EnableAxes.Z)
		{
			text2 += "Z";
		}
		if (EnableAxes.A)
		{
			text2 += "A";
		}
		if (EnableAxes.B)
		{
			text2 += "B";
		}
		if (EnableAxes.C)
		{
			text2 += "C";
		}
		if (EnableAxes.U)
		{
			text2 += "U";
		}
		if (EnableAxes.V)
		{
			text2 += "V";
		}
		if (EnableAxes.W)
		{
			text2 += "W";
		}
		if (text2.Length > 0)
		{
			text = text + " ; " + text2;
		}
		if (PlungeAxisMovement)
		{
			text = text + "; Plunge: " + PlungeAxis;
		}
		if (LeaveAxisMovement)
		{
			text = text + "; Leave: " + LeaveAxis;
		}
		if (PreCodes.Count > 0)
		{
			text = text + "; Pre: " + PreCodes[0].ToString();
		}
		if (AfterCodes.Count > 0)
		{
			text = text + "; After: " + AfterCodes[0].ToString();
		}
		if (IsSafePosition)
		{
			text += "; isSafePos";
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
