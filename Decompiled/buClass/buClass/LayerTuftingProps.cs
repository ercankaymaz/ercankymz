using System;
using System.Drawing;
using System.Reflection;
using buClass.Apps;

namespace buClass;

[Serializable]
public class LayerTuftingProps : buSerilization
{
	public string PileExplanation = "";

	public double PileHeight = 10.0;

	public double StitchLength = 4.0;

	public double YarnWidth = 4.0;

	public double TuftingThickness = 4.0;

	public int YarnID = -1;

	public string ColorCode = "";

	public bool isDirectionArrow = false;

	public Color RealColor = Color.Black;

	public tuftingStitchModeType StitchMode = tuftingStitchModeType.Cut;

	public tuftingMixerModeType MixerMode = tuftingMixerModeType.None;

	public TuftingYarn YarnType = new TuftingYarn();

	public LayerTuftingProps()
	{
	}

	public LayerTuftingProps(LayerTuftingProps data)
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
		return "Pile Height : " + PileHeight + " -  Stitch Length : " + StitchLength;
	}
}
