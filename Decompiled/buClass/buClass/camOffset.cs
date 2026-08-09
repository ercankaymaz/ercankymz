using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camOffset : buSerilization
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

	public camOffset()
	{
	}

	public camOffset(bool enable, double offset, double addtionalOffset, int offsetCount, double overlapDistance, CamClosedContourType flow, OffsetCornerType corner, CamOpenContourType2 openContour)
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

	public camOffset(camOffset offset)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(offset, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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

	public override string ToString()
	{
		return Enable + " , Offset: " + Offset + " , Flow: " + ClosedContour.ToString() + " , Open: " + OpenContourOld;
	}
}
