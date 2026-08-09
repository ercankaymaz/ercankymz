using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class camLengthFeed : buSerilization5
{
	public double MinLength = 0.0;

	public double MaxLength = 0.0;

	public double Feed = 0.0;

	public camLengthFeed()
	{
	}

	public camLengthFeed(double minlen, double maxlen, double feed)
	{
		MinLength = minlen;
		MaxLength = maxlen;
		Feed = feed;
	}

	public camLengthFeed(camLengthFeed data)
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
		return "Min Len: " + MinLength.ToString("f2") + "Max Len: " + MaxLength.ToString("f2") + " - Feed: " + Feed.ToString("f2");
	}
}
