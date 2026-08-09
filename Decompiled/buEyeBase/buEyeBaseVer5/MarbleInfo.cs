using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.Apps.Marble;

namespace buEyeBaseVer5;

[Serializable]
public class MarbleInfo : buSerilization5
{
	public double ExtraAngleA = 0.0;

	public double Angle = 0.0;

	public double Depth = 0.0;

	public double CuttingSpeed = 0.0;

	public double CuttingStep = 0.0;

	public int indexShape = -1;

	public int indexEdge = -1;

	public int ItemID = -1;

	public int CommandID = -1;

	public bool Trimmed = false;

	public bool isInside = false;

	public bool isConcave = false;

	public double TrimDistance = 0.0;

	public double SlatWidth = 0.0;

	public double SlatStartAngle = 0.0;

	public double SlatEndAngle = 0.0;

	public CamSequence Sequence = CamSequence.None;

	public StartEndBothNoneType TrimSide = StartEndBothNoneType.None;

	public MarbleToolType ToolType = MarbleToolType.Saw;

	public MarbleCommandsEntity Command = MarbleCommandsEntity.None;

	public CamOpenContourType OffsetType = CamOpenContourType.Center;

	public marbleCollapsePars Collapse = null;

	public MarbleInfo()
	{
	}

	public MarbleInfo(MarbleInfo data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		if (data.Collapse != null)
		{
			Collapse = new marbleCollapsePars(data.Collapse);
		}
	}

	public ArrayList ToDef(int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + buSerilization5.ClassToString(this));
		return arrayList;
	}

	public static void Decode(List<string> SL, ref MarbleInfo Sewing)
	{
		try
		{
			object obj = null;
			if (SL.Count >= 1)
			{
				Sewing = new MarbleInfo();
				obj = Sewing;
				buSerilization5.StringToClass(ref obj, SL[0]);
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		string text = "Angle: " + Angle.ToString("f2");
		if (ExtraAngleA != 0.0)
		{
			text = text + " - Extra A: " + ExtraAngleA.ToString("f1");
		}
		if (isInside)
		{
			text += " - Inside";
		}
		if (Trimmed)
		{
			text += " - Trimmed";
		}
		if (TrimSide != StartEndBothNoneType.None)
		{
			text = text + " - " + TrimSide;
		}
		if (SlatWidth > 0.0)
		{
			text = text + " - Slat Width: " + SlatWidth;
		}
		if (indexEdge != -1)
		{
			text = text + " - index Edge: " + indexEdge;
		}
		if (indexShape != -1)
		{
			text = text + " - Index Shape: " + indexShape;
		}
		if (Command != MarbleCommandsEntity.None)
		{
			text = text + " - " + Command;
		}
		return text;
	}
}
