using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendJob : buSerilization
{
	public Pnt9D Position = new Pnt9D();

	public double OriginalC = 0.0;

	public double Radius = 0.0;

	public double PartWidth = 0.0;

	public double PartLength = 0.0;

	public int PartCount = 0;

	public int PartIndex = -1;

	public double PartThickness = 0.0;

	public int ToolNo = 0;

	public int Type = 0;

	public int Action = 0;

	public int BlockNo = 0;

	public int Index = 0;

	public int Mode = 0;

	public int Closed = 0;

	public int Direction = 0;

	public bool DontUse = false;

	public int Opt = 0;

	public TrimcutSequence TrimcutSequence = TrimcutSequence.Start;

	public BendJob()
	{
	}

	public BendJob(BendJob data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
		return "X:" + Position.X.ToString("f1") + " ; Action: " + Action + " ; Tool: " + ToolNo + "  ; C:" + Position.C.ToString("f1") + "  ; Mode: " + Mode + "  ; Part Index: " + PartIndex;
	}
}
