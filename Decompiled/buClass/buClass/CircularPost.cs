using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CircularPost : buSerilization
{
	public CircularPostType Type = CircularPostType.Arc;

	public CircularMode Mode = CircularMode.R;

	public CircularIJKMode IJKMode = CircularIJKMode.Center;

	public double DevideLength = 0.1;

	public CircularPost()
	{
	}

	public CircularPost(CircularPost data)
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

	public CircularPost(CircularPostType type, double devidelen)
	{
		Type = type;
		DevideLength = devidelen;
	}
}
