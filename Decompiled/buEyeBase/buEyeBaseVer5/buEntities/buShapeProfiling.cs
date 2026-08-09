using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeProfiling : buShape
{
	public double Radius = 10.0;

	public double Length = 200.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public ProfilingTypes ProfilingType = ProfilingTypes.ProfilingRectangle;

	public buShapeProfiling()
	{
		ShapeGroup = ShapeGroup.Profiling;
	}

	public buShapeProfiling(ProfilingTypes profilingType, double radius, double depth, double length, double width, double height)
	{
		Radius = radius;
		Length = length;
		Width = width;
		Height = height;
		Depth = depth;
		ProfilingType = profilingType;
		ShapeGroup = ShapeGroup.Profiling;
	}

	public buShapeProfiling(buShape data)
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
		string text = "Profiling | " + planeName.ToString() + " -";
		if (ProfilingType == ProfilingTypes.ProfilingRectangle)
		{
			text = text + " Width: " + Width.ToString("f2") + " , Height: " + Height.ToString("f2");
		}
		if (ProfilingType == ProfilingTypes.ProfilingRound)
		{
			text = text + " Radius: " + Radius.ToString("f2");
		}
		if (ProfilingType == ProfilingTypes.ProfilingChamfer)
		{
			text = text + " Len: " + Length.ToString("f2");
		}
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		return text;
	}
}
