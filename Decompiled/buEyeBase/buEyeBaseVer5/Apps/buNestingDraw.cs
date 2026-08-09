using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingDraw : buSerilization5
{
	public bool PartInnerShow = true;

	public bool SheetUselessShow = true;

	public bool DrawAsSolid = true;

	public Color PartSolidColor = Color.WhiteSmoke;

	public Color SheetSolidColor = Color.MintCream;

	public Color PartEntityColor = Color.Blue;

	public Color SheetEntityColor = Color.Black;

	public Color PartInnerEntityColor = Color.Red;

	public Color SheetInnerColor = Color.DarkGray;

	public double PartEntityThickness = 2.0;

	public double PartInnerEntityThickness = 3.0;

	public double SheetEntityThickness = 2.0;

	public double SheetInnerThickness = 3.0;

	public int GridPartSheetHeight = 40;

	public int GridPartSheetPreviewWidth = 100;

	public bool ShowSheetFileNameColumb = false;

	public bool ShowSheetItemNoColumb = false;

	public bool ShowSheetThicknessColumb = false;

	public bool ShowSheetOtherColumb = false;

	public bool ShowSheetAuxColumb = false;

	public bool ShowPartFileNameColumb = false;

	public bool ShowPartItemNoColumb = false;

	public bool ShowPartOtherColumb = false;

	public bool ShowPartAuxColumb = false;

	public bool ShowPartThicknessColumb = false;

	public static List<string> Captions = new List<string>();

	public buNestingDraw()
	{
	}

	public buNestingDraw(buNestingDraw data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
