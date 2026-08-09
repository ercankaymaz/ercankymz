using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class DepthPosition : buSerilization
{
	public double Depth = 0.0;

	public double Position = 0.0;

	public List<List<Pnt3D>> BasePoints = new List<List<Pnt3D>>();

	public List<List<Pnt3D>> EventPoints = new List<List<Pnt3D>>();

	public bool StepEnable = false;

	public double StepDistance = 1.0;

	public DepthPosition()
	{
	}

	public DepthPosition(double depth, double position)
	{
		Depth = depth;
		Position = position;
	}

	public DepthPosition(double depth, double position, bool stepenable, double stepdis)
	{
		Depth = depth;
		Position = position;
		StepEnable = stepenable;
		StepDistance = stepdis;
	}

	public DepthPosition(DepthPosition data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		BasePoints.Clear();
		Pnt3D.Copy(data.BasePoints, ref BasePoints);
		EventPoints.Clear();
		Pnt3D.Copy(data.EventPoints, ref EventPoints);
	}

	public override string ToString()
	{
		return "Depth: " + Depth + " - Position: " + Position;
	}
}
