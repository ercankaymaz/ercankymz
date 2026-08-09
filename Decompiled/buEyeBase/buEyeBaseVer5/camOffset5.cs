using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camOffset5 : buSerilization5
{
	public bool Enable = true;

	public double Offset = 0.0;

	public double AdditionalOffset = 0.0;

	public double FinishOffset = 0.0;

	public int OffsetCount = 1;

	public double OverlapDistance = 0.0;

	public bool AddToolDiameterAsOffset = false;

	public double InCutSafeLength = 0.0;

	public CamClosedContourType ClosedContour = CamClosedContourType.Center;

	public OffsetCornerType Corner = OffsetCornerType.Line;

	public CamOpenContourType OpenContour = CamOpenContourType.Center;

	public CamOpenContourType2 OpenContourOld = CamOpenContourType2.Right;

	public static List<string> Captions = new List<string>();

	public camOffset5()
	{
	}

	public camOffset5(bool enable, double offset, double addtionalOffset, int offsetCount, double overlapDistance, CamClosedContourType flow, OffsetCornerType corner, CamOpenContourType2 openContour)
	{
		Enable = enable;
		Offset = offset;
		AdditionalOffset = addtionalOffset;
		OffsetCount = offsetCount;
		OverlapDistance = overlapDistance;
		ClosedContour = flow;
		Corner = corner;
		OpenContourOld = openContour;
	}

	public camOffset5(camOffset5 offset)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(offset, ref CopiedClass);
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
		return Enable + " , Offset: " + Offset + " , Flow: " + ClosedContour.ToString() + " , Open: " + OpenContour;
	}
}
