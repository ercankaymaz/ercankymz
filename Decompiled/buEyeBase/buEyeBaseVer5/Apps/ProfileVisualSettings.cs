using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileVisualSettings : buSerilization5
{
	public Color TreeItemColor = Color.Black;

	public Color TreeItemSelectedColor = Color.Green;

	public Color TreeOPColor = Color.Black;

	public Color TreeOPSelectedColor = Color.LimeGreen;

	public Color TreeOPWarningColor = Color.DarkOrange;

	public Color TreeOPErrorColor = Color.Red;

	public Color TreeOPInfoColor = Color.Red;

	public Color FreePlaneColor = Color.Green;

	public Color ProfileRefeanceColor = Color.Purple;

	public Color OnlineDrawCamColor = Color.Red;

	public Color OnlineDrawContourColor = Color.Blue;

	public Color OperationSelectedColor = Color.Gold;

	public Color OperationDisableColor = Color.Red;

	public double OnlineDrawThickness = 2.0;

	public int ProfileRefeanceTranparentLeft = 70;

	public int ProfileRefeanceTranparentBottom = 40;

	public int ProfileRefeanceTranparentBack = 40;

	public double TreeItemFontSize = 11.0;

	public double TreeOPFontSize = 9.0;

	public string TreeItemFontName = "Arial";

	public string TreeOPFontName = "Microsoft Sans Serif";

	public string TreeMessageFontName = "Microsoft Sans Serif";

	public ProfileVisualSettings()
	{
	}

	public ProfileVisualSettings(ProfileVisualSettings data)
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
