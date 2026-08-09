using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class Clamper : buSerilization5
{
	public double XPosition = 0.0;

	public double GeometrixMaxX = 0.0;

	public double GeometrixMinX = 0.0;

	public double XOffset = 0.0;

	public double Width = 100.0;

	public string Text = "";

	public double MaxPositionRange = 10000.0;

	public double MinPositionRange = 0.0;

	public bool Used = false;

	public bool Enable = true;

	public Clamper()
	{
	}

	public Clamper(double XPosition)
	{
		this.XPosition = XPosition;
	}

	public Clamper(Clamper data)
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

	public override string ToString()
	{
		return "XPosition: " + XPosition.ToString("f3") + " , Used: " + Used;
	}

	public static void Copy(List<Clamper> RefClamper, ref List<Clamper> CopiedClamper)
	{
		CopiedClamper.Clear();
		CopiedClamper = new List<Clamper>();
		for (int i = 0; i <= RefClamper.Count - 1; i++)
		{
			Clamper CopiedClamper2 = new Clamper();
			Copy(RefClamper[i], ref CopiedClamper2);
			CopiedClamper.Add(CopiedClamper2);
		}
	}

	public static void Copy(Clamper RefClamper, ref Clamper CopiedClamper)
	{
		CopiedClamper = new Clamper(RefClamper);
	}
}
