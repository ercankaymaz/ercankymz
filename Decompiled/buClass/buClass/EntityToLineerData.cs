using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class EntityToLineerData : buSerilization
{
	public double LineLength = -1.0;

	public double CircleLength = -1.0;

	public double ArcLength = -1.0;

	public double PolylineLength = -1.0;

	public double EllipseLength = -1.0;

	public double CurveLength = -1.0;

	public EntityToLineerData()
	{
	}

	public EntityToLineerData(double lineLength, double circleLength, double arcLength, double polylineLength, double ellipseLength, double curveLength)
	{
		LineLength = lineLength;
		CircleLength = circleLength;
		ArcLength = arcLength;
		PolylineLength = polylineLength;
		EllipseLength = ellipseLength;
		CurveLength = curveLength;
	}

	public EntityToLineerData(DevideData data)
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
