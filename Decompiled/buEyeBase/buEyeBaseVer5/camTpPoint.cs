using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camTpPoint : buSerilization5
{
	public ArrayList PreCodes = new ArrayList();

	public ArrayList AfterCodes = new ArrayList();

	public List<TpPnt9D> PrePoints = new List<TpPnt9D>();

	public List<TpPnt9D> AfterPoints = new List<TpPnt9D>();

	public List<TpPnt9D> Points = new List<TpPnt9D>();

	public Pnt9D GCodeOffset = new Pnt9D();

	public string Command = "";

	public int Type = 0;

	public int Mode = 0;

	public int NumberOfPlungeMovement = 0;

	public int NumberOfLeaveMovement = 0;

	public double Feed = 0.0;

	public bool ForceWriteAllCoordinate = false;

	public bool isInside = false;

	public bool Used = false;

	public bool isAngleAvailable = false;

	public bool isSecondHead = false;

	public ToolBase5 ToolCam = null;

	public planeNames PlaneName = planeNames.Top;

	public CamSequence SubSequence = CamSequence.None;

	public camTpPoint()
	{
	}

	public camTpPoint(camTpPoint campoint, bool CopyClass = true)
	{
		if (CopyClass)
		{
			object CopiedClass = new object();
			buSerilization5.CopyClass(campoint, ref CopiedClass);
			if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		}
		if (campoint.ToolCam != null)
		{
			ToolCam = new ToolBase5(campoint.ToolCam);
		}
		Mode = campoint.Mode;
		Type = campoint.Type;
		Command = campoint.Command;
		GCodeOffset = new Pnt9D(campoint.GCodeOffset);
		AfterPoints = new List<TpPnt9D>();
		PrePoints = new List<TpPnt9D>();
		Points = new List<TpPnt9D>();
		for (int j = 0; j <= campoint.Points.Count - 1; j++)
		{
			Points.Add(new TpPnt9D(campoint.Points[j]));
		}
		for (int k = 0; k <= campoint.AfterPoints.Count - 1; k++)
		{
			AfterPoints.Add(new TpPnt9D(campoint.AfterPoints[k]));
		}
		for (int l = 0; l <= campoint.PrePoints.Count - 1; l++)
		{
			PrePoints.Add(new TpPnt9D(campoint.PrePoints[l]));
		}
		PreCodes = new ArrayList();
		for (int m = 0; m <= campoint.PreCodes.Count - 1; m++)
		{
			PreCodes.Add(campoint.PreCodes[m]);
		}
		AfterCodes = new ArrayList();
		for (int n = 0; n <= campoint.AfterCodes.Count - 1; n++)
		{
			AfterCodes.Add(campoint.AfterCodes[n]);
		}
	}

	public override string ToString()
	{
		string text = "";
		if (Points.Count > 0)
		{
			text = " - X: " + Points[0].P9.X.ToString("f3") + " , Y: " + Points[0].P9.Y.ToString("f3") + " , Z: " + Points[0].P9.Z.ToString("f3");
			if (Points[0].P9.A != 0.0)
			{
				text = text + " - A: " + Points[0].P9.A.ToString("f3");
			}
			if (Points[0].P9.B != 0.0)
			{
				text = text + " - B: " + Points[0].P9.B.ToString("f3");
			}
			if (Points[0].P9.C != 0.0)
			{
				text = text + " - C: " + Points[0].P9.C.ToString("f3");
			}
			if (PreCodes.Count > 0)
			{
				text = text + " - Pre: " + PreCodes[0].ToString();
			}
			if (AfterCodes.Count > 0)
			{
				text = text + " - After: " + AfterCodes[0].ToString();
			}
			if (SubSequence != CamSequence.None)
			{
				text = text + " - Seq: " + SubSequence;
			}
		}
		return "Cnt: " + Points.Count + " , Type: " + Type + text;
	}
}
