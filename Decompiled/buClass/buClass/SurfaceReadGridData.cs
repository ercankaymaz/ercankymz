using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class SurfaceReadGridData : buSerilization
{
	public Pnt3D GridDistance = new Pnt3D(5.0, 5.0);

	public SurfaceReadGridData()
	{
	}

	public SurfaceReadGridData(SurfaceReadGridData data)
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
		return "X : " + GridDistance.X.ToString("f3") + " - Y : " + GridDistance.Y.ToString("f3");
	}
}
