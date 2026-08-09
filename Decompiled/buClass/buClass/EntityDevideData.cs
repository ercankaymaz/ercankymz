using System.Reflection;

namespace buClass;

public class EntityDevideData : buSerilization
{
	public double LineLength = 1.0;

	public double PolylineLength = 1.0;

	public double ArcLength = 1.0;

	public double CircleLength = 1.0;

	public double CurveLength = 1.0;

	public double EllipseLength = 1.0;

	public bool DevideEnable = false;

	public bool Polyline = false;

	public bool Line = false;

	public bool Arc = false;

	public bool Circle = false;

	public bool Ellipse = false;

	public bool Curve = false;

	public bool CompositeCurve = false;

	public EntityDevideData()
	{
	}

	public EntityDevideData(EntityDevideData data)
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
