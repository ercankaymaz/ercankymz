using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class camRadiusFeed : buSerilization5
{
	public double MinRadius = 0.0;

	public double MaxRadius = 0.0;

	public double Feed = 0.0;

	public camRadiusFeed()
	{
	}

	public camRadiusFeed(double minrad, double maxrad, double feed)
	{
		MinRadius = minrad;
		MaxRadius = maxrad;
		Feed = feed;
	}

	public camRadiusFeed(camRadiusFeed data)
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

	public override string ToString()
	{
		return "Min Rad: " + MinRadius.ToString("f2") + " - Max Rad: " + MaxRadius.ToString("f2") + " - Feed: " + Feed.ToString("f2");
	}
}
