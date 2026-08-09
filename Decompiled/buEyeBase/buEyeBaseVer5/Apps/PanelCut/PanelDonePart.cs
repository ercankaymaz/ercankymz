using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelDonePart : buSerilization5
{
	public Rectangle2D Panel = new Rectangle2D();

	public int PartID = -1;

	public int Count = 0;

	public string Name = "";

	public PanelDonePart()
	{
	}

	public PanelDonePart(PanelDonePart data)
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
