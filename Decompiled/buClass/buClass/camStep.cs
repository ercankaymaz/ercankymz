using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camStep : buSerilization
{
	public bool Enable = false;

	public double StartValue = 20.0;

	public double EndValue = 0.0;

	public double Distance = 10.0;

	public int Count = 1;

	public double Step = 2.0;

	public double MoveUp = 1.0;

	public bool MoveUpEnable = false;

	public CamMoveUpType MoveUpType = CamMoveUpType.Absolute;

	public CamStepType StepType = CamStepType.StartToDistanceByCount;

	public CamMachiningSequenceType Sequence = CamMachiningSequenceType.Region;

	public static List<string> Captions = new List<string>();

	public camStep()
	{
	}

	public camStep(bool enable, double startValue, double endValue, double distance, int count, double step, CamStepType type)
	{
		Enable = enable;
		StartValue = startValue;
		EndValue = endValue;
		Distance = distance;
		Count = count;
		Step = step;
		StepType = type;
	}

	public camStep(camStep step)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(step, ref CopiedClass);
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
		return Enable + " , Cnt: " + Count + " , Start: " + StartValue + " , Dis: " + Distance;
	}
}
