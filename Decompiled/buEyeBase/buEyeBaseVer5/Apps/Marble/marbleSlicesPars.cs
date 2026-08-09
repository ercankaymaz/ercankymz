using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSlicesPars : buSerilization5
{
	public double CutLengthSingle = 500.0;

	public double SliceLength = 0.0;

	public double SliceWidth = 0.0;

	public double SliceStartAngle = 0.0;

	public double SliceEndAngle = 0.0;

	public int SliceCount = 0;

	public double SliceOffset = 4.0;

	public double MaxSliceLength = 5000.0;

	public bool MoveLeftTopCornerToTopYPosition = true;

	public CamCuttingDirectionType SliceDirection = CamCuttingDirectionType.Forward;

	public bool RotateCForReverseDirection = false;

	public HorizontalVertical HorizontalVerticalSequence = HorizontalVertical.Horizontal;

	public static List<string> Captions = new List<string>();

	public marbleSlicesPars()
	{
	}

	public marbleSlicesPars(marbleSlicesPars data)
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

	public static void Copy(marbleSlicesPars Source, ref marbleSlicesPars Target)
	{
		Target = new marbleSlicesPars(Source);
	}

	public override string ToString()
	{
		return "SliceLength : " + SliceLength + " , SliceWidth : " + SliceWidth;
	}
}
