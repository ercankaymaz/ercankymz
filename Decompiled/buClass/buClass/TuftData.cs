using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class TuftData : buSerilization
{
	public double PileHeight = 0.0;

	public double StitchLength = 0.0;

	public tuftingStitchModeType StitchMode = tuftingStitchModeType.Cut;

	public TuftData()
	{
	}

	public TuftData(double pileH, double stitchLen, tuftingStitchModeType stitchMode)
	{
		PileHeight = pileH;
		StitchLength = stitchLen;
		StitchMode = stitchMode;
	}

	public TuftData(TuftData data)
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
		return StitchMode.ToString() + " - SL: " + StitchLength + " - PH: " + PileHeight;
	}
}
