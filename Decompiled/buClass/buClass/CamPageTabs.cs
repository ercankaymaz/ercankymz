using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CamPageTabs : buSerilization
{
	public bool ShowOperation = true;

	public bool ShowDistance = true;

	public bool ShowVelocity = true;

	public bool ShowStep = false;

	public bool ShowLeadIn = false;

	public bool ShowLeadOut = false;

	public bool ShowMisc = false;

	public bool ShowOffset = false;

	public bool ShowTools = false;

	public int Width = 950;

	public int Height = 530;

	public CamPageTabs()
	{
	}

	public CamPageTabs(CamPageTabs data)
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
}
