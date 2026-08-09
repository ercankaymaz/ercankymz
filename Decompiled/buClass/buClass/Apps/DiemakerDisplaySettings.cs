using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerDisplaySettings : buSerilization
{
	public Color colorActive = Color.LightGreen;

	public Color colorPassive = Color.Red;

	public Color colorCutting = Color.Gray;

	public Color colorCreasing = Color.Gray;

	public Color colorPerfo = Color.Gray;

	public Color colorCutCrease = Color.Gray;

	public Color colorBridge = Color.Gold;

	public Color colorSameEntity = Color.BlueViolet;

	public Color colorMirrorEntity = Color.DarkOliveGreen;

	public Color colorText = Color.Black;

	public Color colorJobPageSmallPreviewTopColor = Color.DarkGray;

	public Color colorJobPageSmallPreviewBottomColor = Color.DarkGray;

	public Color colorJobPageBigPreviewTopColor = Color.DarkGray;

	public Color colorJobPageBigPreviewBottomColor = Color.DarkGray;

	public Color colorBreakMark = Color.Green;

	public Color colorPreviewActive = Color.LightGreen;

	public Color colorPreviewPassive = Color.Red;

	public Color colorInfo = Color.LightCyan;

	public Color colorForeJobDone = Color.Red;

	public Color colorForeJobNotDone = Color.LightGreen;

	public Color colorForeJobNext = Color.Blue;

	public Color colorGridNextJob = Color.AliceBlue;

	public Color colorGridActiveJob = Color.AliceBlue;

	public Color colorCuttingListAllEntitiy = Color.DarkGray;

	public static List<string> Captions = new List<string>();

	public DiemakerDisplaySettings()
	{
	}

	public DiemakerDisplaySettings(DiemakerDisplaySettings data)
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

	public static void Copy(DiemakerDisplaySettings Source, ref DiemakerDisplaySettings Target)
	{
		Target = new DiemakerDisplaySettings(Source);
	}

	public override string ToString()
	{
		return "colorActive : " + colorActive.ToString();
	}
}
