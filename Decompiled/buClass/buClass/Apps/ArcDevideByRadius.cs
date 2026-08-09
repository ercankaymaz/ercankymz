using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ArcDevideByRadius : buSerilization
{
	public double Radius;

	public double DevideLength;

	public ArcDevideByRadius()
	{
	}

	public ArcDevideByRadius(double Radius_, double DevideLength_)
	{
		Radius = Radius_;
		DevideLength = DevideLength_;
	}

	public ArcDevideByRadius(ArcDevideByRadius data)
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
		return "Radius: " + Radius.ToString("f2") + " -  DevideLength: " + DevideLength.ToString("f4");
	}
}
