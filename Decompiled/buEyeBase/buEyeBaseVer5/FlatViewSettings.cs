using System;
using System.Drawing;
using System.Reflection;
using devDept.Eyeshot;

namespace buEyeBaseVer5;

[Serializable]
public class FlatViewSettings : buSerilization5
{
	public bool ShowEdges = true;

	public Color EdgeColor = Color.Black;

	public float EdgeThickness = 2f;

	public silhouettesDrawingType SilhouettesDrawingMode = silhouettesDrawingType.Never;

	public float SilhouetteThickness = 2f;

	public edgeColorMethodType EdgeColorMethod = edgeColorMethodType.SingleColor;

	public bool ShowInternalWires = false;

	public FlatViewSettings()
	{
	}

	public FlatViewSettings(FlatViewSettings data)
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
}
