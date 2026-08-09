using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileClamper : buSerilization5
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

	public bool isCollision = false;

	public ProfileClamper()
	{
	}

	public ProfileClamper(double XPosition)
	{
		this.XPosition = XPosition;
	}

	public ProfileClamper(bool used, bool enable, double width)
	{
		Used = used;
		Enable = enable;
		Width = width;
	}

	public ProfileClamper(double xPos, bool used, bool enable, double width)
	{
		XPosition = xPos;
		Used = used;
		Enable = enable;
		Width = width;
		GeometrixMaxX = XPosition + Width / 2.0;
		GeometrixMinX = XPosition - Width / 2.0;
	}

	public ProfileClamper(ProfileClamper data)
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
		string text = "XPos: " + XPosition.ToString("f3") + " , MinX: " + GeometrixMinX + " , MaxX: " + GeometrixMaxX + " , Used: " + Used;
		if (isCollision)
		{
			text += " Collision";
		}
		return text;
	}

	public static void Copy(List<ProfileClamper> RefClamper, ref List<ProfileClamper> CopiedClamper)
	{
		CopiedClamper.Clear();
		CopiedClamper = new List<ProfileClamper>();
		for (int i = 0; i <= RefClamper.Count - 1; i++)
		{
			ProfileClamper CopiedClamper2 = new ProfileClamper();
			Copy(RefClamper[i], ref CopiedClamper2);
			CopiedClamper.Add(CopiedClamper2);
		}
	}

	public static void Copy(ProfileClamper RefClamper, ref ProfileClamper CopiedClamper)
	{
		CopiedClamper = new ProfileClamper(RefClamper);
	}

	public static bool isClamperPositionsEqual(List<ProfileClamper> ClamperA, List<ProfileClamper> ClamperB)
	{
		try
		{
			if (ClamperA.Count == ClamperB.Count)
			{
				for (int i = 0; i <= ClamperA.Count - 1; i++)
				{
					if (!buCompare5.EQ(ClamperA[i].XPosition, ClamperB[i].XPosition, 0.01))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
