using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class IJK : buSerilization
{
	public double I;

	public double J;

	public double K;

	public IJK()
	{
	}

	public IJK(IJK Pnt)
	{
		I = Pnt.I;
		J = Pnt.J;
		K = Pnt.K;
	}

	public IJK(double i, double j, double k)
	{
		I = i;
		J = j;
		K = k;
	}

	public static bool Equal(IJK RefP1, IJK RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(IJK RefP1, IJK RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public bool Equal(IJK RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(IJK RefP, double Resolution)
	{
		double num = I - RefP.I;
		double num2 = J - RefP.J;
		double num3 = K - RefP.K;
		double num4 = Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		if (num4 < Resolution)
		{
			return true;
		}
		return false;
	}

	public static IJK Copy(IJK P)
	{
		return new IJK(P.I, P.J, P.K);
	}

	public static IJK[] Copy(IJK[] pts)
	{
		IJK[] array = new IJK[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<IJK> Copy(List<IJK> pts)
	{
		List<IJK> list = new List<IJK>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<IJK> pts, ref List<IJK> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new IJK(Copy(pts[i])));
		}
	}

	public static void Copy(List<IJK> pts, ref List<List<IJK>> CopiedPnt)
	{
		CopiedPnt.Clear();
		List<IJK> CopiedPnt2 = new List<IJK>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Copy(List<List<IJK>> pts, ref List<List<IJK>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<IJK> list = new List<IJK>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<IJK> pts, ref IJK[] CopiedPnt)
	{
		try
		{
			CopiedPnt = new IJK[pts.Count];
			if (pts.Count > 0)
			{
				for (int i = 0; i <= pts.Count - 1; i++)
				{
					CopiedPnt[i] = new IJK(pts[i]);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Copy(List<List<IJK>> SourceList, ref List<IJK> TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			TargetList = new List<IJK>();
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					TargetList.Add(new IJK(SourceList[i][j]));
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		return "I:" + I.ToString("") + "; J:" + J.ToString("") + "; K:" + K.ToString("");
	}

	public static IJK DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			IJK iJK = new IJK();
			Value = Value.Replace("I:", "");
			Value = Value.Replace("J:", "");
			Value = Value.Replace("K:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				iJK.I = double.Parse(array[0], provider);
				iJK.J = double.Parse(array[1], provider);
				iJK.K = 0.0;
			}
			if (array.Length > 2)
			{
				iJK.I = double.Parse(array[0], provider);
				iJK.J = double.Parse(array[1], provider);
				iJK.K = double.Parse(array[2], provider);
			}
			return iJK;
		}
		catch (Exception)
		{
			return new IJK();
		}
	}

	public string ToDef()
	{
		return "I:" + I.ToString("") + "; J:" + J.ToString("") + "; K:" + K.ToString("");
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "I:" + I.ToString("") + "; J:" + J.ToString("") + "; K:" + K.ToString("");
	}
}
